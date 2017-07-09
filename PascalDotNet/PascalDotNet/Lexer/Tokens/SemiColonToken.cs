namespace PascalDotNet.Lexer.Tokens
{
	public class SemiColonToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public SemiColonToken (string value)
		{
			Value = value;
		}
	}
}
