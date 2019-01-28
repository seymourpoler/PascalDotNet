using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PascalDotNet.Lexer.Extensions
{
	public static class ReadOnlyCollectionExtensions
	{
		public static T Second<T>(this IReadOnlyCollection<T> collection)
		{
			if(collection.Count < 2)
			{
				throw new ArgumentOutOfRangeException ();
			}
			return collection.ElementAt(1);
		}

		public static T Third<T>(this IReadOnlyCollection<T> collection)
		{
			if(collection.Count < 3)
			{
				throw new ArgumentOutOfRangeException ();
			}
			return collection.ElementAt(2);
		}
	}
}

