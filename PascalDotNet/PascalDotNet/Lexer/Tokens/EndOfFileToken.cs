using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class EndOfFileToken : IToken
	{
		public string Value {get { return String.Empty;}}
		public bool IsAnOperator{get{return false;}}
		public Operator Operator{get{throw new NotImplementedException ();}}

		public bool Equals(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
