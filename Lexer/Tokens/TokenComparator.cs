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

			if(tokenFirst.GetType() != tokenSecond.GetType())
			{
				return false;
			}

			if(String.IsNullOrWhiteSpace(tokenFirst.Value) && String.IsNullOrWhiteSpace(tokenSecond.Value))
			{
				return true;
			}

			if(tokenFirst.Value.ToLower() != tokenSecond.Value.ToLower())
			{
				return false;
			}

			return true;
		}
	}
}
