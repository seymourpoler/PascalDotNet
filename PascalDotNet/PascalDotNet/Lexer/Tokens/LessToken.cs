namespace PascalDotNet.Lexer.Tokens
{
	public class LessToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Less;}}

		public LessToken (string value)
		{
			Value = value;
		}
	}
}
