namespace PascalDotNet.Lexer.Tokens
{
	public class DecimalToken : IToken
	{
		public string Value {get;}

		public DecimalToken (string value)
		{
			Value = value;
		}
	}
}

