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
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(VarToken)));

			while(_tokensParser.WhereTheNextToken (x => x.IsTypeOf(typeof(IdentifierToken))))
			{
				var identifierToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => 
					identifierToken.IsNotEqualsTo(new IdentifierToken(identifierToken.Value)));

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(ColonToken)));

				var variableTypeToken = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => variableTypeToken.IsNotTypeOf(typeof(KeyWordToken)));

				token = _tokensParser.NextToken;
				Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf(typeof(SemiColonToken)));
				
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (variableTypeToken.Value) }));
			}
			return result;
		}
	}
}
