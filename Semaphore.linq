<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

//The procces gate

SemaphoreSlim _gate = new SemaphoreSlim(1);
HttpClient _client = new HttpClient{

	Timeout = TimeSpan.FromSeconds(5)
};

async Task Main()
{
	//await Example();
   Task.WaitAll(CreateCalls().ToArray());
}


public async Task Example() 
{

	for(int i = 0;i<10;i++)
	{
		"Start".Dump();
	 	await _gate.WaitAsync();
		"Do Some Work".Dump();
		_gate.Release();
		"Finish".Dump();
	}
	
}

public IEnumerable<Task> CreateCalls()
{
	for(int i=0;i<500;i++)
	{
		yield return CallGoogle();
	}
}

public async Task CallGoogle()
{
	try
	{
		await _gate.WaitAsync();
		var response = await _client.GetAsync("https://ya.ru");
		_gate.Release();
		response.StatusCode.Dump("StatusCode");		
		//response.Dump("response");
	}
	catch(Exception e)
	{
		e.Message.Dump();
	}
}


