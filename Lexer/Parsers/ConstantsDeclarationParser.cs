﻿using System.Collections.Generic;
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
			if(!_tokensParser.WhereTheNextToken(x => x.IsNotTypeOf(typeof(ConstToken))))
			{
				return result;
			}
			var token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(ConstToken)));

			while(_tokensParser.WhereTheNextToken (x => x.IsNotTypeOf(typeof(IdentifierToken))))
			{
				var identifierToken = _tokensParser.NextToken;
				if(identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)))
				{
					throw new UnExpectedTokenException ();
				}

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(EqualToken)));

				var valueToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => 
					valueToken.IsNotTypeOf(typeof(DecimalToken)) && 
					valueToken.IsNotTypeOf(typeof(IntegerToken)) &&
					valueToken.IsNotTypeOf(typeof(LiteralToken)));

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(SemiColonToken)));

				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (valueToken.Value) }));
			}
			return result;
		}
	}
}
