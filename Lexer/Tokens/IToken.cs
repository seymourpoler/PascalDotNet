using System;

namespace PascalDotNet.Lexer.Tokens
{
	public interface IToken
	{
		string Value{get;}
		bool IsAnOperator{get;}
		Operator Operator{get;}
		bool IsEqualsTo (IToken token);
		bool IsNotEqualsTo (IToken token);
		bool IsTypeOf(Type type);
		bool IsNotTypeOf(Type type);
	}
}