<Query Kind="Program" />

void Main()
{




	Get()
		.Where(num=>num.Dump("where") < 10)
		.Select(num=>num.Dump("select"))
		.Count();
	
	return;
	
	var enumerable = Get();
	enumerable.Dump();
	
	var count = enumerable.Count();
	count.Dump("count");
	
	foreach(var e in enumerable)
	{
		e.Dump("vlaue");
	}
}

public IEnumerable<int> Get()
{
	"1".Dump();
	yield return 1;
	"2".Dump();
	yield return 2;
	"3".Dump();
	yield return 3;
	"42".Dump();
	yield return 42;
	"100500".Dump();
	yield return 100500;
}
