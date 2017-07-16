using System;

namespace PascalDotNet.Lexer
{
	public class Text
	{
		private readonly char[] _text;
		private int _position;

		public char NextCharacter
		{
			get
			{
				if(!HasMoreCharacters)
				{
					return char.MinValue;
				}
				var result = _text [_position];
				_position++;
				return result;
			}	
		}

		public bool HasMoreCharacters
		{
			get
			{
				return _position < _text.Length;
			}
		}

		public Text(string text)
		{
			if(String.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentNullException ();
			}
			_position = 0;
			_text = text.ToCharArray();
		}

		public bool IsTheNextCharacter(char nextCharacter)
		{
			if(!HasMoreCharacters)
			{
				return false;
			}
			return nextCharacter == _text [_position];
		}

		public bool IsTheNextCharacter(Func<char, bool> predicate){
			if(!HasMoreCharacters)
			{
				return false;
			}
			return predicate (_text[_position]);
		}
	}
}
