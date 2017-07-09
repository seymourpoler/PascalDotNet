namespace PascalDotNet.Lexer.Tokens
{
	public class GreaterToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Greater;}}

		public GreaterToken (string value)
		{
			Value = value;
		}
	}
}
