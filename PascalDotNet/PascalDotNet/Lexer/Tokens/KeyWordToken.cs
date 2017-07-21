﻿namespace PascalDotNet.Lexer.Tokens
{
	public class KeyWordToken : IToken
	{
		public string Value{ get;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public KeyWordToken(string value)
		{
			Value = value;
		}

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
