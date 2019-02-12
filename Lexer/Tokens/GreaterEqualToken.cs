using System;

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

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
		
		public bool IsNotEqualsTo(IToken token)
		{
			return !TokenComparator.Equals(this, token);
		}
		
		public bool IsTypeOf<T>()
		{
			return this.GetType() == typeof(T);
		}

		public bool IsNotTypeOf<T>()
		{
			return this.GetType() != typeof(T);
		}
	}
}
