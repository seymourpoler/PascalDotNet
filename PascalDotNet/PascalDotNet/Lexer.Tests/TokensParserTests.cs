using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;

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
	}
}
