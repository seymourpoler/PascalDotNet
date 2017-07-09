namespace PascalDotNet.Lexer.Tokens
{
	public class KeyWordToken : IToken
	{
		public string Value{ get;}
		public bool IsAnOperator{get{return false;}}

		public KeyWordToken(string value)
		{
			Value = value;
		}
	}
}
