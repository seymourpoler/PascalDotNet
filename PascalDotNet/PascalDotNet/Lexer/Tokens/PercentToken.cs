﻿namespace PascalDotNet.Lexer.Tokens
{
	public class PercentToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public PercentToken (string value)
		{
			Value = value;
		}
	}
}
