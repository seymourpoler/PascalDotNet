using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class PlusToken : IToken
	{
		public string Value { get; private set;}

		public PlusToken (string value)
		{
			Value = value;
		}
	}
}

