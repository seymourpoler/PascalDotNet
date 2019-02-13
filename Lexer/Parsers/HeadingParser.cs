using System.Collections.Generic;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Parsers
{
	public class HeadingParser
	{
		private readonly ITokensParser _tokensParser;

		public HeadingParser (ITokensParser tokensParser)
		{
			_tokensParser = tokensParser;
		}

		public Node Parse()
		{
			var token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<ProgramToken>());

			token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotEqualsTo(new IdentifierToken(token.Value)));

			var result = new Node(
				name: Consts.PROGRAM_HEADING,
				nodes: new List<Node> {new Node(token.Value)});

			token = _tokensParser.NextToken;
			Check.ThrowIf<UnExpectedTokenException>(() => token.IsNotTypeOf<SemiColonToken>());

			return result;
		}
	}
}
