namespace PascalDotNet.Lexer.Tokens
{
	public class CommentStartToken : IToken
	{
		public string Value{ get; private set;}

		public CommentStartToken (string value)
		{
			Value = value;
		}
	}
}
