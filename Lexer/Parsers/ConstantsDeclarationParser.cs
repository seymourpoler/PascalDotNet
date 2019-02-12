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
			if(!_tokensParser.WhereTheNextToken(x => x.IsNotTypeOf<ConstToken>()))
			{
				return result;
			}
			var token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<ConstToken>());

			while(_tokensParser.WhereTheNextToken (x => x.IsNotTypeOf<IdentifierToken>()))
			{
				var identifierToken = _tokensParser.NextToken;
				if(identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)))
				{
					throw new UnExpectedTokenException ();
				}

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<EqualToken>());

				var valueToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => 
					valueToken.IsNotTypeOf<DecimalToken>() && 
					valueToken.IsNotTypeOf<IntegerToken>() &&
					valueToken.IsNotTypeOf<LiteralToken>());

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<SemiColonToken>());

				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (valueToken.Value) }));
			}
			return result;
		}
	}
}
