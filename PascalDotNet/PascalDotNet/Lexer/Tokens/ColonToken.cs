namespace PascalDotNet.Lexer.Tokens
{
	public class ColonToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public ColonToken (string value)
		{
			Value = value;
		}
	}
}
