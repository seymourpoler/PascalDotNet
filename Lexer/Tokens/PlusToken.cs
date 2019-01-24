using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class PlusToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Add;}}

		public PlusToken (string value)
		{
			Value = value;
		}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}

