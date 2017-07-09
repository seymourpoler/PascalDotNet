namespace PascalDotNet.Lexer.Tokens
{
	public class GreaterEqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.GreaterEqual;}}

		public GreaterEqualToken (string value)
		{
			Value = value;
		}
	}
}
