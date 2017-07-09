namespace PascalDotNet.Lexer.Tokens
{
	public class CommentEndToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator{get{return false;}}

		public CommentEndToken (string value)
		{
			Value = value;
		}
	}
}
