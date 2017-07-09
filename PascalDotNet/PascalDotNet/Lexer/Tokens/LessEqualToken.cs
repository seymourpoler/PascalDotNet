namespace PascalDotNet.Lexer.Tokens
{
	public class LessEqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.LessEqual;}}

		public LessEqualToken (string value)
		{
			Value = value;
		}
	}
}
