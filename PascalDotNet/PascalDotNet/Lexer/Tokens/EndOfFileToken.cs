using System;

namespace PascalDotNet.Lexer.Tokens
{
	public class EndOfFileToken : IToken
	{
		public string Value {get {throw new NotImplementedException ();	}}
		public bool IsAnOperator{get{throw new NotImplementedException ();}}
		public Operator Operator{get{throw new NotImplementedException ();}}

		public bool Equals(IToken token)
		{
			return TokenComparator.Equals(this, token);
		}
	}
}
