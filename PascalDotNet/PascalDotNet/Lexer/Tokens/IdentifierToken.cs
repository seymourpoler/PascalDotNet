namespace PascalDotNet.Lexer.Tokens
{
	public class IdentifierToken : IToken
	{
		public string Value{get;}

		public IdentifierToken (string value)
		{
			Value = value;
		}
	}
}

