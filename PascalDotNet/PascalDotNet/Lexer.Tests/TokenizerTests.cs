using NUnit.Framework;
using FluentAssertions;
using PascalDotNet.Lexer.Tokens;
using System;
using PascalDotNet.Lexer.Exceptions;

namespace PascalDotNet.Lexer.Tests
{
	[TestFixture]
	public class TokenizerTests
	{
		[Test]
		public void ReturnsEndOfFileTokenWhenIsAtEndOfFile()
		{
			var word = "a";
			var tokenizer = new Tokenizer (word);
			var nextCharacter = tokenizer.NextToken;
			nextCharacter = tokenizer.NextToken;

			var token = tokenizer.NextToken;

			token.Should ().BeOfType<EndOfFileToken> ();
		}

		[Test]
		public void ReturnsOrTokenWhenIsOr()
		{
			var program = "position or size";
			var tokenizer = new Tokenizer (program);
			var nextToken = tokenizer.NextToken;

			var token = tokenizer.NextToken;

			token.Value.Should ().Be ("or");
			token.Should ().BeOfType<OrToken> ();
		}

		[Test]
		public void ReturnsAndTokenWhenIsAnd()
		{
			var program = "position and size";
			var tokenizer = new Tokenizer (program);
			var nextToken = tokenizer.NextToken;

			var token = tokenizer.NextToken;

			token.Value.Should ().Be ("and");
			token.Should ().BeOfType<AndToken> ();
		}

		[Test]
		public void ReturnsProgramTokenFromKeyWord()
		{
			var word = "PROGRAM";
			var tokenizer = new Tokenizer (word);

			var token = tokenizer.NextToken;

			token.Value.Should ().Be (word);
			token.Should ().BeOfType<ProgramToken> ();
		}
		
		[Test]
		public void ReturnsConstTokenFromKeyWord()
		{
			var word = "CONST PI = 3.14;";
			var tokenizer = new Tokenizer (word);

			var token = tokenizer.NextToken;

			token.Value.Should ().Be ("CONST");
			token.Should ().BeOfType<ConstToken> ();
		}

		[Test]
		public void ReturnsIdentifierTokenFromIdentifier()
		{
			var name = "TOM";
			var program = "PROGRAM";
			var word = string.Format("{0} {1}", program, name);
			var tokenizer = new Tokenizer (word);
			var token = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (name);
			result.Should ().BeOfType<IdentifierToken> ();
		}
		[Test]
		public void ReturnsIntegerTokenWhenIsInteger()
		{
			var program = "123";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<IntegerToken> ();
		}

		[Test]
		public void ReturnsDecimalTokenWhenIsDecimal()
		{
			var program = "123.4";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<DecimalToken> ();
		}

		[Test]
		public void ReturnsLiteralTokenWhenIsLiteralWithSingleQuote()
		{
			var program = "\'good morning\'asw;";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("\'good morning\'");
			result.Should ().BeOfType<LiteralToken> ();
		}

		[Test]
		public void ReturnsLiteralTokenWhenIsLiteral()
		{
			var program = "\"good morning\"asw";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("\"good morning\"");
			result.Should ().BeOfType<LiteralToken> ();
		}

		[Test]
		public void ReturnsPlusTokenWhenIsPlus()
		{
			var program = "+";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<PlusToken> ();
		}

		[Test]
		public void ReturnsMinusTokenWhenIsMinus()
		{
			var program = "-";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<MinusToken> ();
		}

		[Test]
		public void ReturnsCommentEndTokenWhenIsCommentEnd()
		{
			var program = "*)";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<CommentEndToken> ();
		}

		[Test]
		public void ReturnsStarTokenWhenIsStar()
		{
			var program = "*";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<StarToken> ();
		}

		[Test]
		public void ReturnsSlashTokenWhenIsSlash()
		{
			var program = "/";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<SlashToken> ();
		}

		[Test]
		public void ReturnsPercentTokenWhenIsPercent()
		{
			var program = "%";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<PercentToken> ();
		}

		[Test]
		public void ReturnsCaretTokenWhenIsCaret()
		{
			var program = "^";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (program);
			result.Should ().BeOfType<CaretToken> ();
		}

		[Test]
		public void ReturnsEqualTokenWhenIsEqual()
		{
			var program = "number=123;";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;
			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("=");
			result.Should ().BeOfType<EqualToken> ();
		}

		[Test]
		public void ReturnsCommentStartTokenWhenCommentStart()
		{
			var program = "(*comment*)";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("(*");
			result.Should ().BeOfType<CommentStartToken> ();
		}

		[Test]
		public void ReturnsLeftParenthesisTokenWhenIsLeftParenthesis()
		{
			var program = "(12*12)";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("(");
			result.Should ().BeOfType<LeftParenthesisToken> ();
		}

		[Test]
		public void ReturnsRigthParenthesisTokenWhenIsRigthParenthesis()
		{
			var program = "12)";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (")");
			result.Should ().BeOfType<RigthParenthesisToken> ();
		}

		[Test]
		public void ReturnsLeftSquareBracketTokenWhenIsLeftSquareBracket()
		{
			var program = "[12]";
			var tokenizer = new Tokenizer (program);

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("[");
			result.Should ().BeOfType<LeftSquareBracketToken> ();
		}

		[Test]
		public void ReturnsRigthSquareBracketTokenWhenIsLeftSquareBracket()
		{
			var program = "[12]";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;
			character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("]");
			result.Should ().BeOfType<RigthSquareBracketToken> ();
		}

		[Test]
		public void ReturnsNotEqualTokenWhenIsNotEqual()
		{
			var program = "1 <> 1";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("<>");
			result.Should ().BeOfType<NotEqualToken> ();
		}

		[Test]
		public void ReturnsLessEqualTokenWhenIsLessEqual()
		{
			var program = "1 <= 1";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("<=");
			result.Should ().BeOfType<LessEqualToken> ();
		}

		[Test]
		public void ReturnsLessTokenWhenIsLess()
		{
			var program = "1 < 1";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be ("<");
			result.Should ().BeOfType<LessToken> ();
		}

		[Test]
		public void ReturnsGreaterEqualTokenWhenIsGreaterEqual()
		{
			var program = "1 >= 1";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (">=");
			result.Should ().BeOfType<GreaterEqualToken> ();
		}

		[Test]
		public void ReturnsGreaterTokenWhenIsGreater()
		{
			var program = "1 > 1";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (">");
			result.Should ().BeOfType<GreaterToken> ();
		}

		[Test]
		public void ReturnsAssignmentTokenWhenIsAssignment()
		{
			var program = "position := 1;";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (":=");
			result.Should ().BeOfType<AssignmentToken> ();
		}

		[Test]
		public void ReturnsColonTokenWhenIsColon()
		{
			var program = "position : 1;";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (":");
			result.Should ().BeOfType<ColonToken> ();
		}

		[Test]
		public void ReturnsSemiColonTokenWhenIsSemiColon()
		{
			var program = "position : 1;";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;
			character = tokenizer.NextToken;
			character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (";");
			result.Should ().BeOfType<SemiColonToken> ();
		}

		[Test]
		public void ReturnsDotTokenWhenIsDot()
		{
			var program = "N..M";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (".");
			result.Should ().BeOfType<DotToken> ();
		}

		[Test]
		public void ReturnsCommaTokenWhenIsComma()
		{
			var program = "position:string, table";
			var tokenizer = new Tokenizer (program);
			var character = tokenizer.NextToken;
			character = tokenizer.NextToken;
			character = tokenizer.NextToken;

			var result = tokenizer.NextToken;

			result.Value.Should ().Be (",");
			result.Should ().BeOfType<CommaToken> ();
		}

		[Test]
		public void ThrowsUnExpectedTokenExceptionWhenThereIsUnExpectedToken()
		{
			var program = "?";
			var tokenizer = new Tokenizer (program);

			Action action = () => {var token = tokenizer.NextToken;};

			action.ShouldThrow<UnExpectedTokenException> ();
		}
	}
}
