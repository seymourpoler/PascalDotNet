using Moq;
using System;
using NUnit.Framework;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;

namespace PascalDotNet.Lexer.Tests.Parsers
{
    [TestFixture]
    public class TypesDeclarationParserTests
    {
        Mock<ITokensParser> tokensParser;
        TypesDeclarationParser parser;

        [SetUp]
        public void SetUp()
        {
            tokensParser = new Mock<ITokensParser>();
            parser = new TypesDeclarationParser(tokensParser.Object);
        }

        [Test]
        public void ReturnNodeWithTypeDeclarationWhenTheresIsNoTypeDeclaration()
        {
            tokensParser
            .Setup(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
            .Returns(false);

            var node = parser.Parse();

            node.Name.Should().Be(Consts.TYPES_DECLARATION);
        }
    }
}
