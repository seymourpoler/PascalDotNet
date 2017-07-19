using System.Collections.ObjectModel;
using PascalDotNet.Lexer.Tokens;
using System;

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
		private ReadOnlyCollection<IToken> _tokens;

		public TokensParser (ITokenizer tokenizer)
		{
			_tokens = tokenizer.Tokens;
			_position = 0;
		}

		public IToken NextToken
		{
			get 
			{
				return _tokens [_position];
			}
		}

		public bool WhereTheNextToken (Func<IToken, bool> predicate)
		{
			return predicate(_tokens[_position+1]);
		}
	}
}
