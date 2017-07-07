namespace PascalDotNet.Lexer.Tokens
{
	public class AssignmentToken : IToken
	{
		public string Value{ get; private set;}

		public AssignmentToken (string value)
		{
			Value = value;
		}
	}
}
