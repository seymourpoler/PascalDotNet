﻿namespace PascalDotNet.Lexer.Tokens
{
	public class DecimalToken : IToken
	{
		public string Value {get;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public DecimalToken (string value)
		{
			Value = value;
		}

		public bool Equals(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}

