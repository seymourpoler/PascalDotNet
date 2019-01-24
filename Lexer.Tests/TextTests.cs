using FluentAssertions;
using NUnit.Framework;
using System;

namespace PascalDotNet.Lexer.Tests
{
	[TestFixture]
    public class TextTests
    {
        [Test]
        public void ReturnsFirstCharacter()
        {
            var text = new Text("Program");

            var result = text.NextCharacter;

            result.Should().Be('P');
        }

		[Test]
		public void ReturnsSecondCharacter()
		{
			var text = new Text("Program");
			var result = Char.MinValue;
			result = text.NextCharacter;

			result = text.NextCharacter;

			result.Should().Be('r');
		}

		[Test]
		public void ThrowsArgumentNullExceptionWhenThereIsNoCharacters()
		{
			Action action = () => {
				var text = new Text(null);
			};

			action.Should().Throw<ArgumentNullException>();
		}

		[Test]
		public void ReturnsTrueWhenHasMoreCharacters()
		{
			var text = new Text("Program");

			var result = text.HasMoreCharacters;

			result.Should ().BeTrue();
		}

		[Test]
		public void ReturnsFalseWhenHasNoMoreCharacters()
		{
			var text = new Text("P");
			var character = text.NextCharacter;

			var result = text.HasMoreCharacters;

			result.Should ().BeFalse();
		}

		[Test]
		public void ReturnsStringEmptyWhenThereIsNoMoreCharacters()
		{
			var text = new Text("P");
			var character = Char.MinValue;
			character = text.NextCharacter;
			character = text.NextCharacter;
			character = text.NextCharacter;

			var result = text.NextCharacter;

			result.Should ().Be (Char.MinValue);
		}

		[Test]
		public void ReturnsTrueIfIsEqualWithTheNextCharacter()
		{
			var text = new Text ("Program");

			var result = text.IsTheNextCharacter ('P');

			result.Should ().BeTrue();
		}

		[Test]
		public void ReturnsFalseIfIsNotEqualWithTheNextCharacter()
		{
			var text = new Text ("Program");

			var result = text.IsTheNextCharacter ('j');

			result.Should ().BeFalse();
		}

		[Test]
		public void ReturnsFalseIfThereIsNoNextCharacter()
		{
			var text = new Text ("Pr");
			char character;
			character = text.NextCharacter;
			character = text.NextCharacter;
			character = text.NextCharacter;
			character = text.NextCharacter;

			var result = text.IsTheNextCharacter ('j');

			result.Should ().BeFalse();
		}

		[Test]
		public void ReturnsTrueWhenThePredicateForTheNextCharacterIsTrue()
		{
			var text = new Text ("1234.6");

			var result = text.IsTheNextCharacter(
				(nextCharacter) => 
					(char.IsDigit (nextCharacter) || '.' == nextCharacter) && 
					nextCharacter != ' ');

			result.Should ().BeTrue ();
		}

		[Test]
		public void ReturnsFalseWhenThePredicateForTheNextCharacterIsFalse()
		{
			var text = new Text ("p = 12;");
			var character = text.NextCharacter;

			var result = text.IsTheNextCharacter (
				(nextCharacter) => 
					char.IsLetter (nextCharacter) &&
					nextCharacter != ' ');

			result.Should ().BeFalse ();
		}

		[Test]
		public void ReturnsFalseWhenThereIsNoMoreCharacters()
		{
			var text = new Text ("p");
			var character = text.NextCharacter;
			character = text.NextCharacter;
			character = text.NextCharacter;

			var result = text.IsTheNextCharacter (
				(nextCharacter) => char.IsLetter (nextCharacter));

			result.Should ().BeFalse ();
		}
    }
}
