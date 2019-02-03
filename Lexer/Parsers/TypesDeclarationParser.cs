using System;

namespace PascalDotNet.Lexer.Parsers
{
    public class TypesDeclarationParser
    {
        private readonly ITokensParser _tokensParser;

        public TypesDeclarationParser(ITokensParser tokensParser)
        {
            _tokensParser = tokensParser;
        }

        public Node Parse()
        {
            throw new System.NotImplementedException();
        }
    }
}
