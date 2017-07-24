using NUnit.Framework;
using PascalDotNet.Lexer.Tokens;
using FluentAssertions;

namespace PascalDotNet.Lexer.Tests.Tokens
{
	[TestFixture]
	public class TokenComparatorTest
	{
		[Test]
		public void ReturnsTrueWhenBothNull()
		{
			var result = TokenComparator.Equals (null, null);

			result.Should ().BeTrue ();
		}

		[Test]
		public void ReturnsFalseWhenOneIsNullAndNotOther()
		{
			var result = TokenComparator.Equals (new KeyWordToken(""), null);

			result.Should ().BeFalse ();
		}

		[Test]
		public void ReturnsFalseWhenHasDifferentTypes()
		{
			var result = TokenComparator.Equals (new KeyWordToken("Key"), new SemiColonToken());

			result.Should ().BeFalse ();
		}

		[Test]
		public void ReturnsFalseWhenHasDifferentValue()
		{
			var result = TokenComparator.Equals (new KeyWordToken("Key"), new KeyWordToken("Word"));

			result.Should ().BeFalse ();
		}

		[Test]
		public void ReturnsTrueWhenBothHasNullValues()
		{
			var result = TokenComparator.Equals (new IdentifierToken(null), new IdentifierToken(null));

			result.Should ().BeTrue ();
		}


		[Test]
		public void ReturnsTrueAreEquals()
		{
			var result = TokenComparator.Equals (new IdentifierToken("position"), new IdentifierToken("position"));

			result.Should ().BeTrue ();
		}
	}
}
