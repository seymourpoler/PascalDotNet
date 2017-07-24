using System;
using System.Collections.Generic;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Parsers
{
	public class VariablesDeclarationParser
	{
		private readonly ITokensParser _tokensParser;

		public VariablesDeclarationParser (ITokensParser tokensParser)
		{
			_tokensParser = tokensParser;
		}

		public Node Parse()
		{
			var result = new Node (Consts.VARIABLES_DECLARATION);
			//TODO: extract class VarToken
			if(!_tokensParser.WhereTheNextToken(x => x.IsEqualsTo(new KeyWordToken("VAR"))))
			{
				return result;
			}
			IToken token;
			token = _tokensParser.NextToken;
			if(!token.IsEqualsTo(new KeyWordToken("VAR")))
			{
				throw new UnExpectedTokenException ();
			}

			while(_tokensParser.WhereTheNextToken (x => x.GetType ().Name.Equals(new IdentifierToken (String.Empty).GetType ().Name)))
			{
				var identifierToken = _tokensParser.NextToken;
				if(!identifierToken.IsEqualsTo(new IdentifierToken(identifierToken.Value)))
				{
					throw new UnExpectedTokenException ();
				}

				token = _tokensParser.NextToken;
				if(!token.IsEqualsTo(new KeyWordToken(":")))
				{
					throw new UnExpectedTokenException ();
				}

				var variableTypeToken = _tokensParser.NextToken;
				token = _tokensParser.NextToken;
				if(!token.IsEqualsTo(new SemiColonToken()))
				{
					throw new UnExpectedTokenException ();
				}
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (variableTypeToken.Value) }));
			}
			return result;
		}
	}
}
