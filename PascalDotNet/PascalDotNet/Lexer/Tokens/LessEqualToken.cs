namespace PascalDotNet.Lexer.Tokens
{
	public class LessEqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public LessEqualToken (string value)
		{
			Value = value;
		}
	}
}
