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
		public void ReturnsFalseWhenHasDifferentValue()
		{
			var result = TokenComparator.Equals (new KeyWordToken("Key"), new KeyWordToken("Word"));

			result.Should ().BeFalse ();
		}

		[Test]
		public void ReturnsTrueWhenBothHasNullValues()
		{
			var result = TokenComparator.Equals (new SemiColonToken(null), new SemiColonToken(null));

			result.Should ().BeTrue ();
		}


		[Test]
		public void ReturnsTrueAreEquals()
		{
			var result = TokenComparator.Equals (new SemiColonToken(";"), new SemiColonToken(";"));

			result.Should ().BeTrue ();
		}
	}
}
