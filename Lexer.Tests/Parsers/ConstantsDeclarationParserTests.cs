using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests.Parsers
{
    [TestFixture]
    public class ConstantsDeclarationParserTests
    {
        private Mock<ITokensParser> tokensParse;
        private ConstantsDeclarationParser parser;

        [SetUp]
        public void SetUp()
        {
            tokensParse = new Mock<ITokensParser>();
            parser = new ConstantsDeclarationParser(tokensParse.Object);   
        }

        [Test]
        public void ParseOnlyConstsDeclaration()
        {
            tokensParse
                .SetupSequence(x => x.NextToken)
                .Returns(new ConstToken())
                .Returns(new EqualToken());

            var result = parser.Parse();

            result.Name.Should().Be(Consts.CONSTANTS_DECLARATION);
            result.Nodes.Should().BeEmpty();
        }
    }
}