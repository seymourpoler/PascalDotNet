namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly ITokenizer _tokenizer;
		public Parser(ITokenizer tokenizer)
		{
			_tokenizer = tokenizer;
		}
	}
}
