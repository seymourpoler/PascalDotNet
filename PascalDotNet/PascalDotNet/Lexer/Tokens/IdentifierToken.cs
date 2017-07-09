namespace PascalDotNet.Lexer.Tokens
{
	public class IdentifierToken : IToken
	{
		public string Value{get;}
		public bool IsAnOperator{get{return false;}}

		public IdentifierToken (string value)
		{
			Value = value;
		}
	}
}

