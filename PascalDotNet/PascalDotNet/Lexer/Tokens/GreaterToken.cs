namespace PascalDotNet.Lexer.Tokens
{
	public class GreaterToken : IToken
	{
		public string Value{ get; private set;}

		public GreaterToken (string value)
		{
			Value = value;
		}
	}
}
