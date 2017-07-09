namespace PascalDotNet.Lexer.Tokens
{
	public class LessToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public LessToken (string value)
		{
			Value = value;
		}
	}
}
