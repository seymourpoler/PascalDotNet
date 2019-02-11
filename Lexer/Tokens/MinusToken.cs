﻿namespace PascalDotNet.Lexer.Tokens
{
	public class MinusToken : IToken
	{
		public string Value {get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Sub;}}

		public MinusToken (string value)
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
	}
}
