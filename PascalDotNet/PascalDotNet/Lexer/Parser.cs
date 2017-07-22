using System.Collections.Generic;
using PascalDotNet.Lexer.Tokens;
using System;
using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly ITokensParser _tokensParser;

		public Parser(ITokensParser tokensParser)
		{
			_tokensParser = tokensParser;
		}

		public Node Parse()
		{
			return new Node ("Pascal")
				.Add (ParseHeading ())
				.Add (ParseConstantsDeclaration ());
				//.Add (ParseVariablesDeclaration ());
		}

		//TODO: extract class
		private Node ParseHeading()
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

		private Node ParseConstantsDeclaration()
		{
			var result = new Node (Consts.CONSTANT_DECLARATION);
			if(!_tokensParser.WhereTheNextToken(x => x.IsEqualsTo(new ConstToken())))
			{
				return result;
			}
			IToken token;
			token = _tokensParser.NextToken;
			if(!token.IsEqualsTo(new ConstToken()))
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
				if(!token.IsEqualsTo(new EqualToken()))
				{
					throw new UnExpectedTokenException ();
				}

				var valueToken = _tokensParser.NextToken;
				token = _tokensParser.NextToken;
				if(!token.IsEqualsTo(new SemiColonToken()))
				{
					throw new UnExpectedTokenException ();
				}
				result.Add (new Node (
					name: identifierToken.Value,
					nodes: new List<Node>{ new Node (valueToken.Value) }));
			}
			return result;
		}

		private Node ParseVariablesDeclaration()
		{
			throw new NotImplementedException ();
		}
	}
}
