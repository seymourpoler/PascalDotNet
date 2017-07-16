﻿using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer
{
	public class ProgramToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator {get {return false;}}
		public Operator Operator{get{throw new NotAnOperatorException ();}}

		public ProgramToken ()
		{
			Value = "PROGRAM";
		}

		public bool Equals (IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}