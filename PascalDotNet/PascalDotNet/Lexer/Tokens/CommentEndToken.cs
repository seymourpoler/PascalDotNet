namespace PascalDotNet.Lexer.Tokens
{
	public class CommentEndToken : IToken
	{
		public string Value { get; private set;}

		public CommentEndToken (string value)
		{
			Value = value;
		}
	}
}
