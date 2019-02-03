using Moq;
using NUnit.Framework;
using PascalDotNet.Lexer.Parsers;

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
    }
}
