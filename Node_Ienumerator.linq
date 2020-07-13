<Query Kind="Program" />

void Main()
{

	var node1 = new LinkNode("node_1");	
	var node2 = new LinkNode("node_2");
	var node3 = new LinkNode("node_3");
	var node4 = new LinkNode("node_4");
	var node5 = new LinkNode("node_5");
	var node6 = new LinkNode("node_6");
	var node7 = new LinkNode("node_7");
	
	node1.SetChild(node2);
	node2.SetChild(node3);
	node3.SetChild(node4);
	node4.SetChild(node5);
	node5.SetChild(node6);
	node6.SetChild(node7);
	
	var com  = new Common();
	foreach(var name in com.ChildList(node1))
	{
		name.GetName().Dump();
	}
}



public class LinkNode
{
	public LinkNode(string NodeName)
	{
		_NodeName = NodeName;
	}
	private string _NodeName {get;set;}
	private LinkNode _child {get;set;}
	
	public void SetChild(LinkNode child)
	{		
		_child = child;
	}
	
	public string GetName()
	{
		return _NodeName;
	}
	
	public LinkNode GetChild()
	{		
		return _child;
	}
}

public class Common
{
	public IEnumerable<LinkNode> ChildList(LinkNode node)
	{
		LinkNode next_node;
		var nodes = new List<LinkNode>();
		if(node is null)
		{
			yield return null;
		}
		
		next_node = node;
	
		while(!(next_node.GetChild() is null))
		{
			next_node = next_node.GetChild();
			if(next_node.Equals(next_node.GetChild()))
			{
			    nodes.Add(next_node);
				break;
			}
			else
			{
				nodes.Add(next_node);
			}
						
		}	
		
		
		foreach(var nod in nodes)
		{
			yield return nod;
		}
		
	}
}

// Define other methods, classes and namespaces here
