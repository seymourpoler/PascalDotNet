using Moq;
using NUnit.Framework;

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
	}
}
