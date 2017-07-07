namespace PascalDotNet.Lexer.Tokens
{
	public class KeyWordToken : IToken
	{
		public string Value{ get;}

		public KeyWordToken(string value)
		{
			Value = value;
		}
	}
}
