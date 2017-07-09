﻿namespace PascalDotNet.Lexer.Tokens
{
	public class AndToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public AndToken (string value)
		{
			Value = value;
		}
	}
}
