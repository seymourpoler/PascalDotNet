namespace PascalDotNet.Lexer.Tokens
{
	public class CommaToken : IToken
	{
		public string  Value{ get; private set;}

		public CommaToken (string value)
		{
			Value = value;
		}
	}
}
