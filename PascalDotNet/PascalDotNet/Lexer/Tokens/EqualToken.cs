namespace PascalDotNet.Lexer.Tokens
{
	public class EqualToken : IToken
	{
		public string Value{ get; private set;}

		public EqualToken (string value)
		{
			Value = value;
		}
	}
}
