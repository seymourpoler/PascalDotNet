using System;
using PascalDotNet.Lexer.Tokens;
using PascalDotNet.Lexer.Extensions;

namespace PascalDotNet.Lexer
{
	public class TokenBuilder
	{
		static string[] keywords = { 
			"program",
			"const",
			"user",
			"type",
			"var",
			"begin",
			"end",
			"integer",
			"boolean",
			"string",
			"character",
			"real",
			"null",
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
			"of",
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
			if(IsAKeyWord(value) && ("program".IsEqualsTo(value)))
			{
				return new ProgramToken ();
			}
			if(IsAKeyWord(value) && ("const".IsEqualsTo(value)))
			{
				return new ConstToken ();
			}
			if(IsAKeyWord(value) && ("var".IsEqualsTo(value)))
			{
				return new VarToken ();
			}
			if(IsAKeyWord(value) && ("or".IsEqualsTo(value)))
			{
				return new OrToken (value);
			}
			if(IsAKeyWord(value) && ("and".IsEqualsTo(value)))
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
				if(token.IsEqualsTo(keywords[i]))
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
