<Query Kind="Program" />

void Main()
{

	var actualGen = new MyActualGen();
	foreach(var v in actualGen)
	{
		v.Dump("value");
	}

	return;
	
	var simpleGen = new MySimpleGen();
	while(simpleGen.HasValue())
	{
		var value = simpleGen.Value;
		value.Dump("value");
	}
}

public class MySimpleGen
{
	int _value = 1;
	public int Value => _value++;
	
	public bool HasValue(){
		_value.Dump();
		if(_value>2)
		{
			return false;
		}
		return true;
	}
}

public class MyActualGen: IEnumerable<int>, IEnumerator<int>
{
	int _value = 1;
	
	public int Current => _value++;
	object IEnumerator.Current =>  Current;
	
	public bool MoveNext()
	{
		_value.Dump();
		if(_value>2)
		{
			return false;
		}
		return true;
	}
	public void Reset()
	{
		 _value = 1;
	}
	
	public void Dispose()
	{
	
	}
	
	public IEnumerator<int> GetEnumerator()
	{
	 return this;
	}
	
	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
