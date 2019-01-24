using System;

namespace PascalDotNet.Lexer.Extensions
{
	public static class StringExtensions
	{
		public static bool IsEqualsTo(this string strA, string strB)
		{
			return String.Compare (strA, strB, StringComparison.OrdinalIgnoreCase) == 0;
		}
	}
}
