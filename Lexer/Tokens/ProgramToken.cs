﻿using System;
using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
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

		public bool IsEqualsTo (IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
		
		public bool IsNotEqualsTo(IToken token)
		{
			return !TokenComparator.Equals(this, token);
		}
		
		public bool IsTypeOf<T>()
		{
			return this.GetType() == typeof(T);
		}

		public bool IsNotTypeOf<T>()
		{
			return this.GetType() != typeof(T);
		}
	}
}
