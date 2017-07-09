namespace PascalDotNet.Lexer.Tokens
{
	public class DotToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public DotToken (string value)
		{
			Value = value;
		}
	}
}
