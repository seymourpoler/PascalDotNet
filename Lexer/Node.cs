using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PascalDotNet.Lexer
{
	public class Node
	{
		private List<Node> _nodes;

<<<<<<< HEAD
		public IReadOnlyCollection<Node> Nodes{ get { return _nodes.AsReadOnly (); } }
=======
		public ReadOnlyCollection<Node> Nodes{ get{ return _nodes.AsReadOnly (); } }
>>>>>>> 702552a597e84b96fca545aec7cf9cc8bba89608
		public string Name { get; private set;}

		public Node (string name, List<Node> nodes)
		{
			_nodes = nodes;
			Name = name;
		}

		public Node (string name)
		{
			_nodes = new List<Node>();
			Name = name;
		}

		public Node Add(Node node)
		{
			_nodes.Add (node);
			return new Node (name: Name, nodes: _nodes);
		}
	}
}
