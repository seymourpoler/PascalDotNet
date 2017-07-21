﻿namespace PascalDotNet.Lexer.Tokens
{
	public class SemiColonToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public SemiColonToken (string value)
		{
			Value = value;
		}

		public SemiColonToken ()
		{
			Value = ";";
		} 

		public bool IsEqualsTo(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
