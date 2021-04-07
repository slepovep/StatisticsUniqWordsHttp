using System;
using NLog;

namespace StatisticsUniqWordsHttp
{
	class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		static void Main(string[] args)
		{
			try
			{
				WebPage webpage = new WebPage();
				webpage.UrlPage = "https://www.simbirsoft.com/";
				webpage.FileName = "test.html";
				//скачивание web-страницы на локальный диск
				webpage.DownloadFile();
			
				StatisticFile file = new StatisticFile();
				//вывод статистики по количеству уникальных слов
				file.CountWords(webpage.LocalFile);			
			
			}
			catch (Exception msg)
			{
				logger.Debug(msg.ToString());
			}

			Console.ReadKey();
		}
	}
}
