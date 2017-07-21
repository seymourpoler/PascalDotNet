namespace PascalDotNet.Lexer.Tokens
{
    public class ConstToken : IToken
    {
        public string Value{ get;}
        public bool IsAnOperator{get{return false;}}
        public Operator Operator{get{throw new NotAnOperatorException ();}}

        public ConstToken()
        {
            Value = "CONST";
        }

        public bool Equals(IToken token)
        {
            return TokenComparator.Equals(this, token);
        }
    }
}