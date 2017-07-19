using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests
{
	[TestFixture]
	public class TokensParserTests
	{
		private Mock<ITokenizer> _tokenizer;
		private TokensParser _tokenParser;

		[SetUp]
		public void SetUp()
		{
			_tokenizer = new Mock<ITokenizer> ();
		}

		[Test]
		public void ReturnsTheNextToken()
		{
			_tokenizer
				.Setup (x => x.Tokens)
				.Returns (new List<IToken>{ new ProgramToken(), new IdentifierToken("Test"), new SemiColonToken() }.AsReadOnly ());
			_tokenParser = new TokensParser (_tokenizer.Object);

			var result = _tokenParser.NextToken;

			result.Equals (new ProgramToken ()).Should ().BeTrue ();
		}

		[Test]
		public void ReturnsEndOfFileTokenWhenThereIsNoMoreTokens()
		{
			IToken result;
			_tokenizer
				.Setup (x => x.Tokens)
				.Returns (new List<IToken>{ new ProgramToken(), new IdentifierToken("Test"), new SemiColonToken() }.AsReadOnly ());
			_tokenParser = new TokensParser (_tokenizer.Object);
			result = _tokenParser.NextToken;
			result = _tokenParser.NextToken;
			result = _tokenParser.NextToken;
			result = _tokenParser.NextToken;

			result = _tokenParser.NextToken;

			result.Equals (new EndOfFileToken ()).Should ().BeTrue ();
		}
	}
}
