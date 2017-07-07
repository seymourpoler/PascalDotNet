namespace PascalDotNet.Lexer.Tokens
{
	public class MinusToken : IToken
	{
		public string Value {get; private set;}

		public MinusToken (string value)
		{
			Value = value;
		}
	}
}
