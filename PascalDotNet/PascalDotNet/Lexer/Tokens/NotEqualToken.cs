namespace PascalDotNet.Lexer.Tokens
{
	public class NotEqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.NotEquals;}}

		public NotEqualToken (string value)
		{
			Value = value;
		}
	}
}
