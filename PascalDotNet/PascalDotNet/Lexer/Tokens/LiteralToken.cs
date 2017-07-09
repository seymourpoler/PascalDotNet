
namespace PascalDotNet.Lexer.Tokens
{
	public class LiteralToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}

		public LiteralToken (string value)
		{
			Value = value;
		}
	}
}

