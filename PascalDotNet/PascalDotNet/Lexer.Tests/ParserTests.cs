using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;
using System.Linq;
using System;
using PascalDotNet.Lexer.Extensions;

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
		public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsMissing()
		{
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ("VAR"));

			Action action = () => parser.Parse ();

			action.ShouldThrow<UnExpectedTokenException> ();
		}

		[Test]
		public void ParseHeadingProgramWithOnlyIdentificator()
		{
			const string programHeaderIdentificator = "Test";
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken (programHeaderIdentificator))
				.Returns (new SemiColonToken ());

			var result = parser.Parse ();

			result.Nodes.First().Name.Should ().Be (Consts.PROGRAM_HEADING);
			result.Nodes.First ().Nodes.First().Name.Should ().Be (programHeaderIdentificator);
		}

		[Test]
		public void ParseConstDefinition()
		{
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ())
				.Returns(new KeyWordToken("CONST"))
				.Returns(new IdentifierToken("PI"))
				.Returns(new EqualToken())
				.Returns(new DecimalToken("3.14"))
				.Returns (new SemiColonToken ());

			var result = parser.Parse ();

			result.Nodes.Second ().Name.Should ().Be (Consts.CONST_DECLARATION);
			result.Nodes.Second ().Nodes.First().Name.Should ().Be ("PI");
			result.Nodes.Second ().Nodes.First().Nodes.First().Name.Should ().Be ("3.14");
		}

		[Test]
		public void ParseTwoConstDefinitions()
		{
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ())
				.Returns(new KeyWordToken("CONST"))
				.Returns(new IdentifierToken("PI"))
				.Returns(new EqualToken())
				.Returns(new DecimalToken("3.14"))
				.Returns (new SemiColonToken ())
				.Returns(new IdentifierToken("MESSAGE"))
				.Returns(new EqualToken())
				.Returns(new DecimalToken("'error in'"))
				.Returns (new SemiColonToken ());

			var result = parser.Parse ();

			result.Nodes.Second ().Name.Should ().Be (Consts.CONST_DECLARATION);
			result.Nodes.Second ().Nodes.Second().Name.Should ().Be ("MESSAGE");
			result.Nodes.Second ().Nodes.Second().Nodes.First().Name.Should ().Be ("'error in'");
		}
	}
}
