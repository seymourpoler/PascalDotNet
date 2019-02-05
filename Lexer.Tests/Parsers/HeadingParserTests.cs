﻿using System;
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
        public void ThrowsUnExpectedTokenExceptionWhenSemiColonTokenIsMissingInProgramDeclaration()
        {
            tokensParser.SetupSequence (x => x.NextToken)
                .Returns (new ProgramToken ())
                .Returns (new IdentifierToken ("Test"))
                .Returns (new EndOfFileToken ());

            Action action = () => parser.Parse ();

            action.Should().Throw<UnExpectedTokenException> ();
        }
    }
}