using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace StatisticsUniqWordsHttp
{
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

            //инициализация объектов для записи в БД
            //master
            StatDb statDb = new StatDb();
            statDb.User = "User1";
            statDb.UrlPage = localfile;

            //поиск по каждому ключевому слову из списка поиска
            foreach (var search in ListSearch)
			{
                int countWords = CountWordsSearch(filestr, search);
                Console.WriteLine(search + " - " + countWords);
                
                //detail
                StatWordsDb statWordsDb = new StatWordsDb();
                statWordsDb.PatentId = statDb.Id;
                statWordsDb.Word = search;
                statWordsDb.Count = countWords;
                //запись в БД
                StatDb.InsertStatDb(statDb, statWordsDb);
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
