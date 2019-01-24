﻿namespace PascalDotNet.Lexer.Tokens
{
	public class StarToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Mul;}}

		public StarToken (string value)
		{
			Value = value;
		}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}