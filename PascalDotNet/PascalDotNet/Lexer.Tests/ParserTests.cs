using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;
using System.Linq;
using System;

namespace PascalDotNet.Lexer.Tests
{
	[TestFixture]
	public class ParserTests
	{
		private Mock<ITokenizer> tokenizer;
		private Parser parser;

		[SetUp]
		public void SetUp()
		{
			tokenizer = new Mock<ITokenizer> ();
			parser = new Parser (
				tokenizer: tokenizer.Object);
		}

		[Test]
		public void ThrowsUnExpectedTokenExceptionWhenKeyWordTokenIsWrong()
		{
			tokenizer.SetupSequence (x => x.NextToken)
				.Returns (new KeyWordToken ("Progra"))
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken (";"));

			Action action = () => parser.Parse ();

			action.ShouldThrow<UnExpectedTokenException> ();
		}

		[Test]
		public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsMissing()
		{
			tokenizer.SetupSequence (x => x.NextToken)
				.Returns (new KeyWordToken ("Progra"))
				.Returns (new IdentifierToken ("Test"))
				.Returns (new SemiColonToken ("VAR"));

			Action action = () => parser.Parse ();

			action.ShouldThrow<UnExpectedTokenException> ();
		}

		[Test]
		public void ParseHeadingProgramWithOnlyIdentificator()
		{
			const string programHeaderIdentificator = "Test";
			tokenizer.SetupSequence (x => x.NextToken)
				.Returns (new KeyWordToken ("Program"))
				.Returns (new IdentifierToken (programHeaderIdentificator))
				.Returns (new SemiColonToken (";"));

			var result = parser.Parse ();

			result.Name.Should ().Be (Consts.PROGRAM_HEADING);
			result.Nodes.First ().Name.Should ().Be (programHeaderIdentificator);
		}
	}
}
