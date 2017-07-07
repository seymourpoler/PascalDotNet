namespace PascalDotNet.Lexer.Tokens
{
	public class NotEqualToken : IToken
	{
		public string Value{ get; private set;}

		public NotEqualToken (string value)
		{
			Value = value;
		}
	}
}
