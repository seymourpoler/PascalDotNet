using PascalDotNet.Lexer.Tokens;
using PascalDotNet.Lexer.Exceptions;

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
            var result = new Node(Consts.TYPES_DECLARATION);
            if (!_tokensParser.WhereTheNextToken(x => x is TypeToken))
            {
                return result;
            }
            var token = _tokensParser.NextToken;
            if (token.IsNotEqualsTo(new TypeToken()))
            {
                throw new UnExpectedTokenException();
            }

            throw new System.NotImplementedException();
        }
    }
}
