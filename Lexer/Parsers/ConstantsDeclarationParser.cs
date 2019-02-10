using System.Collections.Generic;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Tokens;
using System;

namespace PascalDotNet.Lexer.Parsers
{
	public class ConstantsDeclarationParser
	{
		private readonly ITokensParser _tokensParser;

		public ConstantsDeclarationParser (ITokensParser tokensParser)
		{
			_tokensParser = tokensParser;
		}

		public Node Parse()
		{
			var result = new Node (Consts.CONSTANTS_DECLARATION);
			if(!_tokensParser.WhereTheNextToken(x => x.IsEqualsTo(new ConstToken())))
			{
				return result;
			}
			var token = _tokensParser.NextToken;
			if(token.IsNotEqualsTo(new ConstToken()))
			{
				throw new UnExpectedTokenException ();
			}

			while(_tokensParser.WhereTheNextToken (x => x is IdentifierToken))
			{
				var identifierToken = _tokensParser.NextToken;
				if(identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)))
				{
					throw new UnExpectedTokenException ();
				}

				token = _tokensParser.NextToken;
				if(token.IsNotEqualsTo(new EqualToken()))
				{
					throw new UnExpectedTokenException ();
				}

				var valueToken = _tokensParser.NextToken;
				token = _tokensParser.NextToken;
				if(token.IsNotEqualsTo(new SemiColonToken()))
				{
					throw new UnExpectedTokenException ();
				}
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (valueToken.Value) }));
			}
			return result;
		}
	}
}
