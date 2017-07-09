namespace PascalDotNet.Lexer.Tokens
{
	public class EqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public EqualToken (string value)
		{
			Value = value;
		}
	}
}
