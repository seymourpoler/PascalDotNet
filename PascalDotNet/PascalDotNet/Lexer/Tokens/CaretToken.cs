﻿namespace PascalDotNet.Lexer.Tokens
{
	public class CaretToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public CaretToken (string value)
		{
			Value = value;
		}
	}
}
