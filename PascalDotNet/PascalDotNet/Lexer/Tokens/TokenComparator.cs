using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class TokenComparator
	{
		public static bool Equals(IToken tokenFirst, IToken tokenSecond)
		{
			if(tokenFirst == null && tokenSecond == null)
			{
				return true;
			}
			if(tokenFirst == null || tokenSecond == null)
			{
				return false;
			}
			if(tokenFirst.Value != tokenSecond.Value)
			{
				return false;
			}
			return true;
		}
	}
}
