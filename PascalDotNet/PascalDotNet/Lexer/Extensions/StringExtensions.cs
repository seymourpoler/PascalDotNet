namespace PascalDotNet.Lexer.Extensions
{
	public static class StringExtensions
	{
		public static bool IsEqualTo(this string strA, string strB)
		{
			return string.Compare (strA: strA, strB: strB, ignoreCase: true) == 0;
		}
	}
}
