namespace PascalDotNet.Lexer.Tokens
{
	public class EqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Equals;}}

		public EqualToken (string value)
		{
			Value = value;
		}
	}
}
