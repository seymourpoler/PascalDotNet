namespace PascalDotNet.Lexer.Tokens
{
	public class LeftSquareBracketToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public LeftSquareBracketToken (string value)
		{
			Value = value;
		}
	}
}
