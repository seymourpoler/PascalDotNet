using System;
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
		public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsMissingInProgramDeclaration()
		{
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new EndOfFileToken ());

			Action action = () => parser.Parse ();

			action.Should().Throw<UnExpectedTokenException> ();
		}

		[Test]
		public void ParseHeadingProgramWithOnlyIdentificator()
		{
			const string programHeaderIdentificator = "Test";
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken (programHeaderIdentificator))
				.Returns (new SemiColonToken ())
				.Returns(new EndOfFileToken());

			var result = parser.Parse ();

			result.Nodes.First().Name.Should ().Be (Consts.PROGRAM_HEADING);
			result.Nodes.First ().Nodes.First().Name.Should ().Be (programHeaderIdentificator);
		}

		[Test]
		public void ParseConstDefinition()
		{
			tokensParser
				.SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
				.Returns (true)
				.Returns (true)
				.Returns (false);
			
			tokensParser.SetupSequence (x => x.NextToken)
				.Returns(new ProgramToken ())
				.Returns(new IdentifierToken ("Test"))
				.Returns(new SemiColonToken ())
				.Returns(new ConstToken())
				.Returns(new IdentifierToken("PI"))
				.Returns(new EqualToken())
				.Returns(new DecimalToken("3.14"))
				.Returns(new SemiColonToken ())
				.Returns(new EndOfFileToken());

			var result = parser.Parse ();

			result.Nodes.Second ().Name.Should ().Be (Consts.CONSTANTS_DECLARATION);
			result.Nodes.Second ().Nodes.First().Name.Should ().Be ("PI");
			result.Nodes.Second ().Nodes.First().Nodes.First().Name.Should ().Be ("3.14");
		}

		[Test]
		public void ParseDefinitionOfTwoConstants()
		{
			tokensParser
				.SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
				.Returns (true)
				.Returns (true)
				.Returns (true)
				.Returns(false);

			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ())
				.Returns(new ConstToken())
				.Returns(new IdentifierToken("PI"))
				.Returns(new EqualToken())
				.Returns(new DecimalToken("3.14"))
				.Returns (new SemiColonToken ())
				.Returns(new IdentifierToken("MESSAGE"))
				.Returns(new EqualToken())
				.Returns(new LiteralToken("'error in'"))
				.Returns (new SemiColonToken ());

			var result = parser.Parse ();

			result.Nodes.Second ().Name.Should ().Be (Consts.CONSTANTS_DECLARATION);
			result.Nodes.Second ().Nodes.Second().Name.Should ().Be ("MESSAGE");
			result.Nodes.Second ().Nodes.Second().Nodes.First().Name.Should ().Be ("'error in'");
		}

		[Test]
		public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsMissingInVariablesDeclaration()
		{
			tokensParser
				.SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
				.Returns (true)
				.Returns (true)
				.Returns (false);

			tokensParser.SetupSequence (x => x.NextToken)
				.Returns (new ProgramToken ())
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ())
				.Returns (new VarToken ())
				.Returns (new IdentifierToken ("position"))
				.Returns (new ColonToken ());

			Action action = () => parser.Parse ();

			action.Should().Throw<UnExpectedTokenException> ();
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
