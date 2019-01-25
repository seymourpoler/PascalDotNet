using System;
using System.Collections.ObjectModel;
using FluentAssertions;
using NUnit.Framework;

namespace PascalDotNet.Lexer.Tests
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void ReturnNewNodeWithAddedNodes()
        {
            var node = new Node(String.Empty);

            var result = node.Add(new Node(String.Empty));

            result.Nodes.Should().BeOfType<ReadOnlyCollection<Node>>();
            result.Nodes.Should().NotBeEmpty();
        }
    }
}
