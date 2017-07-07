namespace PascalDotNet.Lexer.Tokens
{
	public class LeftSquareBracketToken : IToken
	{
		public string Value{ get; private set;}

		public LeftSquareBracketToken (string value)
		{
			Value = value;
		}
	}
}
