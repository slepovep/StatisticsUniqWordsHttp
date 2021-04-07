using System;

namespace StatisticsUniqWordsHttp
{
	class Program
	{
		//public static AppContext db = new AppContext();
		static void Main(string[] args)
		{
				WebPage webpage = new WebPage();
				webpage.UrlPage = "https://www.simbirsoft.com/";
				webpage.FileName = "test.html";
				//скачивание web-страницы на локальный диск
				webpage.DownloadFile();

				StatisticFile file = new StatisticFile();
				//вывод статистики по количеству уникальных слов
				file.CountWords(webpage.LocalFile);

			Console.ReadKey();
		}
	}
}
