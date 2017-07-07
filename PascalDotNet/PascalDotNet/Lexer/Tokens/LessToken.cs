namespace PascalDotNet.Lexer.Tokens
{
	public class LessToken : IToken
	{
		public string Value{ get; private set;}

		public LessToken (string value)
		{
			Value = value;
		}
	}
}
