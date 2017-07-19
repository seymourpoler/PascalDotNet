using System;
using System.Collections.ObjectModel;

namespace PascalDotNet.Lexer.Extensions
{
	public static class ReadOnlyCollectionExtensions
	{
		public static T Second<T>(this ReadOnlyCollection<T> collection) where T : class
		{
			if(collection.Count < 2)
			{
				throw new ArgumentOutOfRangeException ();
			}
			return collection [1];
		}
	}
}

