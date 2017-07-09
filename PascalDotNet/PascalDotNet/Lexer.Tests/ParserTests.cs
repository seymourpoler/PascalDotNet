using NUnit.Framework;
using Moq;

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
	}
}
