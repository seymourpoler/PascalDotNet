using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
{
    public class TypeToken : IToken
    {
        public string Value { get; private set; }
        public bool IsAnOperator { get { return false; } }
        public Operator Operator { get { throw new NotAnOperatorException(); } }

        public TypeToken()
        {
            Value = "TYPE";
        }

        public bool IsEqualsTo(IToken token)
        {
            return TokenComparator.Equals(this, token);
        }
    }
}
