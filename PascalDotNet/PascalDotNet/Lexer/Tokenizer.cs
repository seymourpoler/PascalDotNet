﻿using System.Text;
using System;
using PascalDotNet.Lexer.Tokens;

namespace PascalDotNet.Lexer
{
	public interface ITokenizer
	{
		IToken NextToken{ get;}
	}

	public class Tokenizer : ITokenizer
	{
		private readonly Text _text;

		public IToken NextToken
		{
			get
			{
				if(!_text.HasMoreCharacters)
				{
					return new EndOfFileToken();
				}

				char character = _text.NextCharacter;
				while(character == ' ' || character == '\r' || character == '\t' || character == '\n')
				{
					if(!_text.HasMoreCharacters)
					{
						return new EndOfFileToken();
					}
					character = _text.NextCharacter;
				}

				if(char.IsLetter(character))
				{
					return BuildKeywordOrIdentifierToken (character);
				}
				if(char.IsDigit(character))
				{
					return BuildIntegerOrDecimalToken (character);
				}
				if('\'' == character)
				{
					return BuildLiteralTokenWithSingleQuotes (character);
				}
				if('\"' == character)
				{
					return BuildLiteralTokenWithDoubleQuotes (character);
				}
				if('+' == character)
				{
					return new PlusToken (character.ToString());
				}
				if('-' == character)
				{
					return new MinusToken (character.ToString());
				}
				if('*' == character){
					return BuildStartOrCommentEndToken (character);
				}
				if('/' == character){
					return new SlashToken (character.ToString());
				}
				if('%' == character)
				{
					return new PercentToken (character.ToString ());
				}
				if('^' == character)
				{
					return new CaretToken (character.ToString ());
				}
				if('=' == character)
				{
					return new EqualToken ();
				}
				if('(' == character)
				{
					return BuildCommentStartOrLeftParenthesisToken(character);
				}
				if(')' == character)
				{
					return new RigthParenthesisToken (character.ToString());
				}
				if('[' == character)
				{
					return new LeftSquareBracketToken (character.ToString ());
				}
				if(']' == character)
				{
					return new RigthSquareBracketToken (character.ToString ());
				}
				if('<' == character)
				{
					return BuildNotEqualOrLessEqualOrLessToken (character);
				}
				if('>' == character)
				{
					return BuildGeaterEqualOrGeaterToken (character);
				}
				if(':' == character)
				{
					return BuildAssignmentOrColonToken (character);
				}
				if(';' == character)
				{
					return new SemiColonToken (character.ToString ());
				}
				if('.' == character)
				{
					return new DotToken (character.ToString ());
				}
				if(',' == character)
				{
					return new CommaToken (character.ToString ());
				}
				throw new UnExpectedTokenException();
			}
		}

		public Tokenizer(string text)
		{
			_text = new Text (text);
		}

		private IToken BuildKeywordOrIdentifierToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			bool exit = false;

			while(!exit)
			{
				if(_text.IsTheNextCharacter(nextCharacter => char.IsLetter (nextCharacter) && nextCharacter != ' '))
				{
					tokenValue.Append (_text.NextCharacter);
				}
				else
				{
					exit = true;
				}
			}

			return TokenBuilder.Build (tokenValue.ToString ());
		}

		private IToken BuildIntegerOrDecimalToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			bool exit = false;

			while(!exit)
			{
				if(_text.IsTheNextCharacter(nextCharacter => char.IsDigit (nextCharacter) || '.' == nextCharacter && nextCharacter != ' '))
				{
					tokenValue.Append (_text.NextCharacter);
				}
				else
				{
					exit = true;
				}
			}

			return TokenBuilder.Build (tokenValue.ToString ());
		}

		private IToken BuildLiteralTokenWithSingleQuotes(char character)
		{
			return BuildLiteralToken (
				character: character,
				separator: '\'');
		}

		private IToken BuildLiteralTokenWithDoubleQuotes(char character)
		{
			return BuildLiteralToken (
				character: character, 
				separator: '\"');
		}

		private IToken BuildLiteralToken(char character, char separator)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			char currentCharacter = Char.MinValue;
			do
			{
				currentCharacter = _text.NextCharacter;
				tokenValue.Append (currentCharacter);
			} 
			while(separator != currentCharacter);

			return new LiteralToken (tokenValue.ToString ());
		}

		private IToken BuildStartOrCommentEndToken (char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			if(_text.IsTheNextCharacter(')'))
			{
				return new CommentEndToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			return new StarToken ("*");
		}

		private IToken BuildCommentStartOrLeftParenthesisToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			if(_text.IsTheNextCharacter('*'))
			{
				return new CommentStartToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			return new LeftParenthesisToken (character.ToString ());
		}

		private IToken BuildNotEqualOrLessEqualOrLessToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			if(_text.IsTheNextCharacter('>'))
			{
				return new NotEqualToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			if(_text.IsTheNextCharacter('='))
			{
				return new LessEqualToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			return new LessToken (character.ToString ());
		}

		private IToken BuildGeaterEqualOrGeaterToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			if(_text.IsTheNextCharacter('='))
			{
				return new GreaterEqualToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			return new GreaterToken (character.ToString ());
		}

		private IToken BuildAssignmentOrColonToken(char character)
		{
			var tokenValue = new StringBuilder ();
			tokenValue.Append (character);
			if(_text.IsTheNextCharacter('='))
			{
				return new AssignmentToken (tokenValue.Append (_text.NextCharacter).ToString ());
			}
			return new ColonToken (character.ToString ());
		}
	}
}
