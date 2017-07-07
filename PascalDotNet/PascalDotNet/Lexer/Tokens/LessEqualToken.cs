namespace PascalDotNet.Lexer.Tokens
{
	public class LessEqualToken : IToken
	{
		public string Value{ get; private set;}

		public LessEqualToken (string value)
		{
			Value = value;
		}
	}
}
