﻿using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Extensions;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests
{
	[TestFixture]
	public class ParserTests
	{
		private Mock<ITokensParser> tokensParser;
		private Parser parser;

		[SetUp]
		public void SetUp()
		{
			tokensParser = new Mock<ITokensParser> ();
			parser = new Parser (
				tokensParser: tokensParser.Object);
		}

		[Test]
		public void ParseVariablesDeclaration()
		{
			tokensParser
				.SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
				.Returns (false)
				.Returns (true)
				.Returns (true);

			tokensParser.SetupSequence (x => x.NextToken)
				.Returns(new ProgramToken ())
				.Returns(new IdentifierToken ("Test"))
				.Returns(new SemiColonToken ())
				.Returns(new VarToken())
				.Returns(new IdentifierToken("position"))
				.Returns(new ColonToken())
				.Returns(new KeyWordToken("INTEGER"))
				.Returns(new SemiColonToken ())
				.Returns(new EndOfFileToken());

			var result = parser.Parse ();

			result.Nodes.Third ().Name.Should ().Be (Consts.VARIABLES_DECLARATION);
			result.Nodes.Third ().Nodes.First().Name.Should ().Be ("position");
			result.Nodes.Third ().Nodes.First().Nodes.First().Name.Should ().Be ("INTEGER");
		}
	}
}
