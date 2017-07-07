namespace PascalDotNet.Lexer.Tokens
{
	public class PercentToken : IToken
	{
		public string Value{ get; private set;}

		public PercentToken (string value)
		{
			Value = value;
		}
	}
}
