using System;
using FluentAssertions;
using NUnit.Framework;

namespace PascalDotNet.Lexer.Tests
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void ThrowsExceptionWhenTheConditionIsFalse()
        {
            Action action = () => Check.ThrowIf<Exception>(() => true);

            action.Should().Throw<Exception>();
        }
        
        [Test]
        public void DoNotThrowExceptionWhenTheConditionIsFalse()
        {
            Action action = () => Check.ThrowIf<Exception>(() => false);

            action.Should().NotThrow<Exception>();
        }
    }
}