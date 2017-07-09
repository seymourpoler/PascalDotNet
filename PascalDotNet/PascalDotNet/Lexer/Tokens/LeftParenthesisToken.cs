namespace PascalDotNet.Lexer.Tokens
{
	public class LeftParenthesisToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public LeftParenthesisToken (string value)
		{
			Value = value;
		}
	}
}
