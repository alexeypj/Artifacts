<Query Kind="Program" />

void Main()
{
	Func<int,int> fib_delegate= null;
	fib_delegate = n=>n>1?fib_delegate(n-1) + fib_delegate(n-2):n;
	
	
	GetFib(10,fib_recursion).Dump("Recursion");
	"------------".Dump();
	GetFib(10,fib_delegate).Dump("Delegate");
	
}

public int fib_recursion(int numb)
{
	if(numb == 0 )
	{
		return 0;
	}
	if(numb ==1)
	{
		return 1;
	}
	else
	{
		return fib_recursion(numb-1) + fib_recursion(numb-2);
	}
}

public IEnumerable<int> GetFib (int numb, Func<int,int> fn)
{
	for(var i =0;i<numb;i++)
	{
		yield return fn(i);
	}
}


// Define other methods, classes and namespaces here
