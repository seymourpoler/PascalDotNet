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
			if(!_tokensParser.WhereTheNextToken(x => x.IsTypeOf(typeof(VarToken))))
			{
				return result;
			}
			var token = _tokensParser.NextToken;
			if(token.IsNotTypeOf(typeof(VarToken)))
			{
				throw new UnExpectedTokenException ();
			}

			while(_tokensParser.WhereTheNextToken (x => x.IsTypeOf(typeof(IdentifierToken))))
			{
				var identifierToken = _tokensParser.NextToken;
				if(identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)))
				{
					throw new UnExpectedTokenException();
				}

				token = _tokensParser.NextToken;
				if(token.IsNotTypeOf(typeof(ColonToken)))
				{
					throw new UnExpectedTokenException();
				}

				var variableTypeToken = _tokensParser.NextToken;
				if(variableTypeToken.IsNotTypeOf(typeof(KeyWordToken)))
				{
					throw new UnExpectedTokenException();
				}
				token = _tokensParser.NextToken;
				if(token.IsNotTypeOf(typeof(SemiColonToken)))
				{
					throw new UnExpectedTokenException();
				}
				
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (variableTypeToken.Value) }));
			}
			return result;
		}
	}
}
