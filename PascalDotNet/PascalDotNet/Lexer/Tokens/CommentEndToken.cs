using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
{
	public class CommentEndToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public CommentEndToken (string value)
		{
			Value = value;
		}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
