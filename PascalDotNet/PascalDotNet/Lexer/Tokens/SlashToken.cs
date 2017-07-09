namespace PascalDotNet.Lexer.Tokens
{
	public class SlashToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}

		public SlashToken (string value)
		{
			Value = value;
		}
	}
}

