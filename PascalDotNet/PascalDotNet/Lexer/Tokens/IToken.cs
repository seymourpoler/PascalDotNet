namespace PascalDotNet.Lexer.Tokens
{
	public interface IToken
	{
		string Value{get;}
		bool IsAnOperator{get;}
		Operator Operator{get;}
	}
}