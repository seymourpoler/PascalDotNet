using PascalDotNet.Lexer.Parsers;

namespace PascalDotNet.Lexer
{
	public class Parser
	{
		private readonly HeadingParser _headingParser;
		private readonly ConstantsDeclarationParser _constantsDeclarationParser;
		private readonly VariablesDeclarationParser _variablesDeclarationParser;

		public Parser(ITokensParser tokensParser)
		{
			_headingParser = new HeadingParser (tokensParser);
			_constantsDeclarationParser = new ConstantsDeclarationParser (tokensParser);
			_variablesDeclarationParser = new VariablesDeclarationParser (tokensParser);
		}

		public Node Parse()
		{
			return new Node ("Pascal")
				.Add (_headingParser.Parse ())
				.Add (_constantsDeclarationParser.Parse ())
				.Add (_variablesDeclarationParser.Parse ());
		}
	}
}
