﻿namespace PascalDotNet.Lexer.Tokens
{
	public class RigthParenthesisToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public RigthParenthesisToken (string value)
		{
			Value = value;
		}
	}
}
