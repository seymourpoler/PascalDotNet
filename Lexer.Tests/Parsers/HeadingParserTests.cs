using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Exceptions;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests.Parsers
{
    [TestFixture]
    public class HeadingParserTests
    {
        private Mock<ITokensParser> tokensParser;
        private HeadingParser parser;

        [SetUp]
        public void SetUp()
        {
            tokensParser = new Mock<ITokensParser>();
            parser = new HeadingParser(tokensParser.Object);
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenProgramTokenIsMissingInProgramDeclaration()
        {
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns (new IdentifierToken ("Test"))
                .Returns (new EndOfFileToken ());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenIdentifierTokenIsMissingInProgramDeclaration()
        {
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns (new ProgramToken ())
                .Returns (new EndOfFileToken ());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
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

            result.Name.Should ().Be (Consts.PROGRAM_HEADING);
            result.Nodes.First().Name.Should ().Be (programHeaderIdentificator);
        }
    }
}