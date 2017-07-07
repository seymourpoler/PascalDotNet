using System;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer
{
	public class TokenBuilder
	{
		static string[] keywords = new [] { 
			"program",
			"user",
			"type",
			"var",
			"begin",
			"end",
			"Integer",
			"Boolean",
			"String",
			"Character",
			"NULL",
			"record",
			"array",
			"set",
			"of",
			"case",
			"goto",
			"label",
			"and",
			"or",
			"not",
			"if",
			"else",
			"then",
			"while",
			"do",
			"for",
			"repeat",
			"until",
			"procedure",
			"function"
		};

		public static IToken Build(string value)
		{
			if(IsAKeyWord(value) && ("or".IsEqualTo(value)))
			{
				return new OrToken (value);
			}
			if(IsAKeyWord(value) && ("and".IsEqualTo(value)))
			{
				return new AndToken (value);
			}
			if(IsAKeyWord(value))
			{
				return new KeyWordToken (value);
			}
			if(IsAnInteger(value))
			{
				return new IntegerToken (value);
			}
			if(IsADecimal(value))
			{
				return new DecimalToken (value);
			}

			return new IdentifierToken (value);
		}

		static bool IsAKeyWord (string token)
		{
			for(int i = 0; i < keywords.Length; i++)
			{
				if(token.IsEqualTo(keywords[i]))
				{
					return true;
				}
			}
			return false;

		}

		static bool IsAnInteger(string token)
		{
			int number;
			return Int32.TryParse (token, out number);
		}

		static bool IsADecimal(string token)
		{
			decimal number;
			return Decimal.TryParse (token, out number);
		}
	}
}

