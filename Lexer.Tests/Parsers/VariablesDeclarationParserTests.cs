using System;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Parsers;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer.Tests.Parsers
{
    [TestFixture]
    public class VariablesDeclarationParserTests
    {
        private Mock<ITokensParser> tokensParser;
        private VariablesDeclarationParser parser;

        [SetUp]
        public void SetUp()
        {
            tokensParser = new Mock<ITokensParser>();
            parser = new VariablesDeclarationParser(tokensParser.Object);
        }
        
        [Test]
        public void ParseVariablesDeclaration()
        {
            tokensParser
                .SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
                .Returns (true)
                .Returns (true)
                .Returns (false);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new VarToken())
                .Returns(new IdentifierToken("position"))
                .Returns(new ColonToken())
                .Returns(new KeyWordToken("INTEGER"))
                .Returns(new SemiColonToken ())
                .Returns(new EndOfFileToken());

            var result = parser.Parse ();

            result.Name.Should ().Be (Consts.VARIABLES_DECLARATION);
            result.Nodes.First().Name.Should ().Be ("position");
            result.Nodes.First().Nodes.First().Name.Should ().Be ("INTEGER");
        }
    }
}