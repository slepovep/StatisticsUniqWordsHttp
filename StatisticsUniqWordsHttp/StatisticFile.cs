using System;
using System.IO;
using System.Collections.Generic;

namespace StatisticsUniqWordsHttp
{
    //вывод статистики из локального файла
    class StatisticFile
    {
        //список слов участвующих в поиске
        private List<string> listSearch = new List<string>();
        public List<string> ListSearch 
        {
            get 
            {
                return listSearch;
            }

            set
			{
                int numarr = 0;
                foreach (var search in value)
				{
                    numarr++;
                    if (string.IsNullOrEmpty(search))
                    {
                        throw new Exception($"Ошибка. {numarr}-й параметр поиска не может содержать пустое значение.");
                    }
                }
                listSearch = value;
            }
        }
        //инициализация списка слов для поиска
        public StatisticFile() 
        {
            ListSearch = new List<string> (new string[] { "РАЗРАБОТКА", "ПРОГРАММНОГО", "ОБЕСПЕЧЕНИЯ" }) ;
        }

        public StatisticFile(List<string> listSearch)
        {
            ListSearch = listSearch;
        }
        //расчет кол-ва слов в файле и вывод статистики
        public void CountWords(string localfile)
        {
            string filestr = "";

            StreamReader sr = new StreamReader(localfile);

            //считывание файла в строку
            while (sr.EndOfStream != true)
            {
                filestr += sr.ReadLine();
            }

            sr.Close();

            #region запись в БД master
             StatDb statDb = new StatDb();
             statDb.User = "User1";
             statDb.LocalFile = localfile;
             //запись в БД 
             statDb.Id = StatDb.Insert(statDb);
            #endregion

            //поиск по каждому ключевому слову из списка поиска
            foreach (var search in ListSearch)
			{
                int countWords = CountWordsSearch(filestr, search);
                Console.WriteLine(search + " - " + countWords);

                #region запись в БД detail 
                 StatDetailDb statDetailDb = new StatDetailDb();
                 statDetailDb.Word = search;
                 statDetailDb.Count = countWords;
                 statDetailDb.StatDbId = statDb.Id ;//Id master
                 //запись в БД 
                 StatDetailDb.Insert(statDetailDb);
                #endregion
            }
        }

        //поиск кол-ва слов в строке
        private static int CountWordsSearch(string inputtext, string searchword)
        {
            int counter = 0;
            string[] words = inputtext.Split(new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t' });

            foreach (var word in words)
            {
                if (searchword.ToUpper() == word.ToUpper())
                {
                    counter++;
                }
            }
            return counter;
        }


	}
}
