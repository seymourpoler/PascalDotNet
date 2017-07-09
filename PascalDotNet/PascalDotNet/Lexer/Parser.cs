namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly Tokenizer _tokenizer;
		public Parser(Tokenizer tokenizer)
		{
			_tokenizer = tokenizer;
		}
	}
}
