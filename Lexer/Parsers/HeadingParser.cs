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
			if(token.IsNotTypeOf(typeof(ProgramToken)))
			{
				throw new UnExpectedTokenException ();
			}

			token = _tokensParser.NextToken;
			if(token.IsNotEqualsTo(new IdentifierToken(token.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			var result = new Node(
				name: Consts.PROGRAM_HEADING,
				nodes: new List<Node> {new Node(token.Value)});

			token = _tokensParser.NextToken;
			if(token.IsNotTypeOf(typeof(SemiColonToken)))
			{
				throw new UnExpectedTokenException ();
			}

			return result;
		}
	}
}
