namespace PascalDotNet.Lexer.Tokens
{
	public class IntegerToken : IToken
	{
		public string Value {get;}
		public bool IsAnOperator{get{return false;}}

		public IntegerToken (string value)
		{
			Value = value;
		}
	}
}
