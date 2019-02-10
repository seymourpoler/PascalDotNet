using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Extensions;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests.Parsers
{
    [TestFixture]
    public class ConstantsDeclarationParserTests
    {
        private Mock<ITokensParser> tokensParser;
        private ConstantsDeclarationParser parser;

        [SetUp]
        public void SetUp()
        {
            tokensParser = new Mock<ITokensParser>();
            parser = new ConstantsDeclarationParser(tokensParser.Object);   
        }

        [Test]
        public void ParseOnlyConstsDeclaration()
        {
            tokensParser
                .SetupSequence(x => x.NextToken)
                .Returns(new ConstToken())
                .Returns(new EqualToken());

            var result = parser.Parse();

            result.Name.Should().Be(Consts.CONSTANTS_DECLARATION);
            result.Nodes.Should().BeEmpty();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenIdentifierIsNotFound()
        {
            tokensParser
                .Setup (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
                .Returns (true);
            tokensParser.SetupSequence(x => x.NextToken)
                .Returns(new ConstToken())
                .Returns(new EqualToken());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenEqualTokenIsNotFound()
        {
            tokensParser
                .Setup(x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
                .Returns (true);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new ConstToken())
                .Returns(new IdentifierToken("PI"))
                .Returns(new EndOfFileToken());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenSemiColonIsNotFound()
        {
            tokensParser
                .Setup (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
                .Returns (true);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new ConstToken())
                .Returns(new IdentifierToken("PI"))
                .Returns(new EqualToken())
                .Returns(new DecimalToken("3.14"))
                .Returns(new EndOfFileToken());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
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
                .Returns(new ConstToken())
                .Returns(new IdentifierToken("PI"))
                .Returns(new EqualToken())
                .Returns(new DecimalToken("3.14"))                
                .Returns(new SemiColonToken ())
                .Returns(new EndOfFileToken());

            var result = parser.Parse ();

            result.Name.Should ().Be (Consts.CONSTANTS_DECLARATION);
            result.Nodes.First().Name.Should ().Be ("PI");
            result.Nodes.First().Nodes.First().Name.Should ().Be ("3.14");
        }
    }
}