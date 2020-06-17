<Query Kind="Program" />

void Main()
{
	// value coming from query/header/body
	//var selectProperty = "word";
	var selectProperty = "number";

	var someClass = new SomeClass { 
		Word = "Hello World", 
		Number = 1234 
	};

	// hard coded, not scalable
	if (selectProperty == "word")
	{
		someClass.Word.Dump();
	}
	else if (selectProperty == "number")
	{
	 	someClass.Number.Dump();
	}
	
	// solution: ???
	
	//parameter
	var parameter = Expression.Parameter(typeof(SomeClass)).Dump("parameter");
	var accessor = Expression.PropertyOrField(parameter, selectProperty).Dump("accessor");
	
	var lambda = Expression.Lambda(accessor, false, parameter).Dump("lambda");
	lambda.Compile().DynamicInvoke(someClass).Dump("1");
}


public class SomeClass
{
	public string Word { get; set; }
	public int Number { get; set; }
}