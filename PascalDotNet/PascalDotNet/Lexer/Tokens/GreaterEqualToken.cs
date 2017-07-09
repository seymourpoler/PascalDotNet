namespace PascalDotNet.Lexer.Tokens
{
	public class GreaterEqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public GreaterEqualToken (string value)
		{
			Value = value;
		}
	}
}
