namespace PascalDotNet.Lexer.Tokens
{
	public class StarToken : IToken
	{
		public string Value { get; private set;}
		public bool IsAnOperator{get{return true;}}

		public StarToken (string value)
		{
			Value = value;
		}
	}
}
