using System;
using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
{
	public class IdentifierToken : IToken
	{
		public string Value{get;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public IdentifierToken (string value)
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

