namespace PascalDotNet.Lexer.Tokens
{
	public class ColonToken : IToken
	{
		public string Value{ get; private set;}

		public ColonToken (string value)
		{
			Value = value;
		}
	}
}
