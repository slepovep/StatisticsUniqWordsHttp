using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StatisticsUniqWordsHttp.Tests
{
	[TestClass]
	public class StatisticFileTest
	{
		[TestMethod]
		public void TestCountWordsSearch()
		{
			// arrange
			string str = "разработка программного обеспечения,обеспечения";
			string search = "ОБЕСПЕЧЕНИЯ";
			int expected = 2;

			// act
			StatisticFile file = new StatisticFile();
			var result = file.CountWordsSearch(str, search);

			// assert
			Assert.AreEqual(expected, result);
		}
	}
}
