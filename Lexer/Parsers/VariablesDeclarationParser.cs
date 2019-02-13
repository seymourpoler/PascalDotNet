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
			if(!_tokensParser.WhereTheNextToken(x => x.IsTypeOf<VarToken>()))
			{
				return result;
			}
			var token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<VarToken>());

			while(_tokensParser.WhereTheNextToken (x => x.IsTypeOf<IdentifierToken>()))
			{
				var identifierToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => 
					identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)));

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<ColonToken>());

				var variableTypeToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => variableTypeToken.IsNotTypeOf<KeyWordToken>());

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<SemiColonToken>());
				
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (variableTypeToken.Value) }));
			}
			return result;
		}
	}
}
