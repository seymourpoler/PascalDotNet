namespace PascalDotNet.Lexer.Tokens
{
	public class EqualToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Equals;}}

		public EqualToken ()
		{
			Value = "=";
		}


		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
