using PascalDotNet.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PascalDotNet.Lexer
{
	public interface ITokensParser
	{
		IToken NextToken{ get;}
		bool WhereTheNextToken (Func<IToken, bool> predicate);
	}

	public class TokensParser : ITokensParser
	{
		private int _position;
		private IReadOnlyCollection<IToken> _tokens;

		public TokensParser (ITokenizer tokenizer)
		{
			_tokens = tokenizer.Tokens;
			_position = 0;
		}

		public IToken NextToken
		{
			get 
			{
				if((_position)>= _tokens.Count)
				{
					return new EndOfFileToken ();
				}
				var tokenResult = _tokens.ElementAt(_position);
				_position++;
				return tokenResult;
			}
		}

		private IToken FutureToken
		{
			get 
			{
				if(_position >= _tokens.Count)
				{
					return new EndOfFileToken ();
				}
				return _tokens.ElementAt(_position);
			}
		}

		public bool WhereTheNextToken (Func<IToken, bool> predicate)
		{
			return predicate(FutureToken);
		}
	}
}
