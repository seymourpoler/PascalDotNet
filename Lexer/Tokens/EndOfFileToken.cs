using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class EndOfFileToken : IToken
	{
		public string Value {get { return String.Empty;}}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotImplementedException ();}}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
		
		public bool IsNotEqualsTo(IToken token)
		{
			return !TokenComparator.Equals(this, token);
		}
		
		public bool IsTypeOf(Type type)
		{
			return this.GetType() == type;
		}

		public bool IsNotTypeOf(Type type)
		{
			return this.GetType() != type;
		}
	}
}
