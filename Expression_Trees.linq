<Query Kind="Program" />

void Main()
{
	Func<int> five =()=> 5;
	five().Dump();
	
	//This is information about function. Not a function! Expression does not have a return values
	//This notation showes, how to EF reads the expression
	Expression<Func<int>> five_exp =()=>5;
	five_exp.Dump("expression");
	//To run a function under expression you shuld Compile...
	five_exp.Compile()().Dump();
	//or
	five_exp.Compile().Invoke().Dump("compiled");
	
	var user = new User().Dump("User");
	Expression<Func<User, object>> exp = user => user.Name;
	exp.Dump("expression with user");
	
	var body = exp.Body.Dump("Body");
	
	if(body is MemberExpression me)
	{
		me.Member.Name.ToLower().Dump();
	}
	else if(body is UnaryExpression ue)
	{
		((MemberExpression)ue.Operand).Member.Name.ToLower().Dump();
	}
}
public class User
{
	public string Name { get; set; }
	public int Age { get; set; }
}