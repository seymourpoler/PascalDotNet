namespace PascalDotNet.Lexer.Tokens
{
	public class CommaToken : IToken
	{
		public string  Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public CommaToken (string value)
		{
			Value = value;
		}
	}
}
