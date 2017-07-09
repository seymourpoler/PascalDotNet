namespace PascalDotNet.Lexer.Tokens
{
	public class ColonToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public ColonToken (string value)
		{
			Value = value;
		}
	}
}
