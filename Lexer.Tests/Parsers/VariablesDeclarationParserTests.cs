﻿using System;
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
        public void ReturnEmptyVariableDeclaration()
        {
            tokensParser
                .SetupSequence(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
                .Returns(false);

            var result = parser.Parse();

            result.Name.Should().Be(Consts.VARIABLES_DECLARATION);
            result.Nodes.Should().BeEmpty();
        }

        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenIdentifierTokenIsNotFound()
        {
            tokensParser
                .Setup(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
                .Returns(true);
            tokensParser.SetupSequence(x => x.NextToken)
                .Returns(new VarToken())
                .Returns(new ColonToken());
            
            Action action = () => parser.Parse();

            action.Should().Throw<UnExpectedTokenException>();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenVarTokenIsNotFound()
        {
            tokensParser
                .SetupSequence (x => x.WhereTheNextToken (It.IsAny<Func<IToken, bool>>()))
                .Returns (true);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new IdentifierToken("position"));
            
            Action action = () =>  parser.Parse();

            action.Should().Throw<UnExpectedTokenException>();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenColonTokenIsNotFound()
        {
            tokensParser
                .SetupSequence(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
                .Returns(true)
                .Returns(true);
            tokensParser.SetupSequence(x => x.NextToken)
                .Returns(new VarToken())
                .Returns(new IdentifierToken("position"))
                .Returns(new EndOfFileToken());
            
            Action action = () =>  parser.Parse();

            action.Should().Throw<UnExpectedTokenException>();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenKeyWordTokenIsNotFound()
        {
            tokensParser
                .SetupSequence(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
                .Returns(true)
                .Returns(true);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new VarToken())
                .Returns(new IdentifierToken("position"))
                .Returns(new ColonToken())
                .Returns(new VarToken())
                .Returns(new EndOfFileToken());
            
            Action action = () =>  parser.Parse();

            action.Should().Throw<UnExpectedTokenException>();
        }
        
        [Test]
        public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsNotFound()
        {
            tokensParser
                .SetupSequence(x => x.WhereTheNextToken(It.IsAny<Func<IToken, bool>>()))
                .Returns(true)
                .Returns(true);
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns(new VarToken())
                .Returns(new IdentifierToken("position"))
                .Returns(new ColonToken())
                .Returns(new KeyWordToken("INTEGER"))
                .Returns(new ConstToken())
                .Returns(new EndOfFileToken());
            
            Action action = () =>  parser.Parse();

            action.Should().Throw<UnExpectedTokenException>();
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