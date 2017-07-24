using System;
using System.Collections.Generic;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly ITokensParser _tokensParser;
		private readonly HeadingParser _headingParser;

		public Parser(ITokensParser tokensParser)
		{
			_tokensParser = tokensParser;
			_headingParser = new HeadingParser (tokensParser);
		}

		public Node Parse()
		{
			return new Node ("Pascal")
				.Add (_headingParser.Parse ())
				.Add (ParseConstantsDeclaration ())
				.Add (ParseVariablesDeclaration ());
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
			var result = new Node (Consts.CONSTANTS_DECLARATION);
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
