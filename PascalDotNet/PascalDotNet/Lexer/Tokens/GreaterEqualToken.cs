namespace PascalDotNet.Lexer.Tokens
{
	public class GreaterEqualToken : IToken
	{
		public string Value{ get; private set;}

		public GreaterEqualToken (string value)
		{
			Value = value;
		}
	}
}
