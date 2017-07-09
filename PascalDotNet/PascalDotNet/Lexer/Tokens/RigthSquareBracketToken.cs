namespace PascalDotNet.Lexer.Tokens
{
	public class RigthSquareBracketToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public RigthSquareBracketToken (string value)
		{
			Value = value;
		}
	}
}
