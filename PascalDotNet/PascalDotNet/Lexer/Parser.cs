using System.Collections.Generic;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly ITokenizer _tokenizer;

		public Parser(ITokenizer tokenizer)
		{
			_tokenizer = tokenizer;
		}

		public Node Parse()
		{
			var headingParsed = ParseHeading ();
			return headingParsed;
		}

		private Node ParseHeading()
		{
			IToken token;
			token = _tokenizer.NextToken;
			if(!token.Equals(new KeyWordToken(token.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			token = _tokenizer.NextToken;
			if(!token.Equals(new IdentifierToken(token.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			var result = new Node (
				name: Consts.PROGRAM_HEADING,
				nodes: new List<Node> {new Node(token.Value)});
			
			token = _tokenizer.NextToken;
			if(!token.Equals(new SemiColonToken(token.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			return result;
		}
	}
}
