namespace PascalDotNet.Lexer.Tokens
{
	public class LeftSquareBracketToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public LeftSquareBracketToken (string value)
		{
			Value = value;
		}

		public bool Equals(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
