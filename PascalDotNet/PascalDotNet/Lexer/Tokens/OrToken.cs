namespace PascalDotNet.Lexer.Tokens
{
	public class OrToken : IToken
	{
		public string Value{ get; private set;}

		public OrToken (string value)
		{
			Value = value;
		}
	}
}
