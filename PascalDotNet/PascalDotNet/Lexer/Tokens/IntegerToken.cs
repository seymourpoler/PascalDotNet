namespace PascalDotNet.Lexer.Tokens
{
	public class IntegerToken : IToken
	{
		public string Value {get;}

		public IntegerToken (string value)
		{
			Value = value;
		}
	}
}
