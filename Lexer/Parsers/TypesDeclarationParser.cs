using PascalDotNet.Lexer.Tokens;

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
            if (!_tokensParser.WhereTheNextToken(token => token is TypeToken))
            {
                return result;
            }

            throw new System.NotImplementedException();
        }
    }
}
