namespace PascalDotNet.Lexer.Tokens
{
	public class CaretToken : IToken
	{
		public string Value{ get; private set;}

		public CaretToken (string value)
		{
			Value = value;
		}
	}
}
