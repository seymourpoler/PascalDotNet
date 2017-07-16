namespace PascalDotNet.Lexer.Tokens
{
	public class AssignmentToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Assign;}}

		public AssignmentToken (string value)
		{
			Value = value;
		}

		public bool Equals(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
