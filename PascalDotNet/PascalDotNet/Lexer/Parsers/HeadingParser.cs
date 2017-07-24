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
			IToken token;
			token = _tokensParser.NextToken;
			if(!token.IsEqualsTo(new ProgramToken()))
			{
				throw new UnExpectedTokenException ();
			}

			token = _tokensParser.NextToken;
			if(!token.IsEqualsTo(new IdentifierToken(token.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			var result = new Node (
				name: Consts.PROGRAM_HEADING,
				nodes: new List<Node> {new Node(token.Value)});

			token = _tokensParser.NextToken;
			if(!token.IsEqualsTo(new SemiColonToken()))
			{
				throw new UnExpectedTokenException ();
			}

			return result;
		}
	}
}
