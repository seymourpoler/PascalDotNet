namespace PascalDotNet.Lexer.Tokens
{
	public class RigthParenthesisToken : IToken
	{
		public string Value{ get; private set;}

		public RigthParenthesisToken (string value)
		{
			Value = value;
		}
	}
}
