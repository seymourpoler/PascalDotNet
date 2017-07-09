namespace PascalDotNet.Lexer.Tokens
{
	public class SlashToken : IToken
	{
		public string Value{ get; private set;}
		public bool IsAnOperator{get{return true;}}
		public Operator Operator{get{return Operator.Div;}}

		public SlashToken (string value)
		{
			Value = value;
		}
	}
}

