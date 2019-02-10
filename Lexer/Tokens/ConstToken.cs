using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tokens
{
    public class ConstToken : IToken
    {
    	public string Value{ get; private set;}
        public bool IsAnOperator{get{return false;}}
        public Operator Operator{get{throw new NotAnOperatorException ();}}

        public ConstToken()
        {
            Value = "CONST";
        }

        public bool IsEqualsTo(IToken token)
        {
            return TokenComparator.Equals(this, token);
        }
        
        public bool IsNotEqualsTo(IToken token)
        {
            return !TokenComparator.Equals(this, token);
        }
    }
}