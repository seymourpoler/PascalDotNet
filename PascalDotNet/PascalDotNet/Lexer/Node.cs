using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PascalDotNet.Lexer
{
	public class Node
	{
		private List<Node> _nodes;

		public ReadOnlyCollection<Node> Nodes{get{return _nodes.AsReadOnly ();}}
		public string Name { get; private set;}

		public Node (string name)
		{
			_nodes = new List<Node> ();
			Name = name;
		}
	}
}
