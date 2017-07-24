using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
{
	public class VarToken : IToken
	{
		public string Value{ get;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public VarToken()
		{
			Value = "VAR";
		}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
