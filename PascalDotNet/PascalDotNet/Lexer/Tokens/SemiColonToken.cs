namespace PascalDotNet.Lexer.Tokens
{
	public class SemiColonToken : IToken
	{
		public string Value{ get; private set;}

		public SemiColonToken (string value)
		{
			Value = value;
		}
	}
}
