namespace PascalDotNet.Lexer.Tokens
{
	public class DotToken : IToken
	{
		public string Value{ get; private set;}

		public DotToken (string value)
		{
			Value = value;
		}
	}
}
