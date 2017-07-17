using System.Collections.Generic;
using PascalDotNet.Lexer.Tokens;
using System;

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
			return new Node ("Pascal")
				.Add (ParseHeading ())
				.Add (ParseConstantsDeclaration ());
		}

		private Node ParseHeading()
		{
			IToken token;
			token = _tokenizer.NextToken;
			if(!token.Equals(new ProgramToken()))
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
			if(!token.Equals(new SemiColonToken()))
			{
				throw new UnExpectedTokenException ();
			}

			return result;
		}

		private Node ParseConstantsDeclaration()
		{
			IToken token;
			token = _tokenizer.NextToken;
			//TODO: ConstToken
			if(!token.Equals(new KeyWordToken("CONST")))
			{
				throw new UnExpectedTokenException ();
			}
			var identifierToken = _tokenizer.NextToken;
			if(!identifierToken.Equals(new IdentifierToken(identifierToken.Value)))
			{
				throw new UnExpectedTokenException ();
			}

			token = _tokenizer.NextToken;
			if(!token.Equals(new EqualToken()))
			{
				throw new UnExpectedTokenException ();
			}

			var valueToken = _tokenizer.NextToken;
			token = _tokenizer.NextToken;
			if(!token.Equals(new SemiColonToken()))
			{
				throw new UnExpectedTokenException ();
			}

			return new Node (
				name: Consts.CONST_DECLARATION,
				nodes: new List<Node> {
					new Node (name: identifierToken.Value,
						nodes: new List<Node>{ new Node (valueToken.Value) }),
				});
		}
	}
}
