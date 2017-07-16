using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;
using System.Linq;

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
