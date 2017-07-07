namespace PascalDotNet.Lexer.Tokens
{
	public class AndToken : IToken
	{
		public string Value{ get; private set;}

		public AndToken (string value)
		{
			Value = value;
		}
	}
}
