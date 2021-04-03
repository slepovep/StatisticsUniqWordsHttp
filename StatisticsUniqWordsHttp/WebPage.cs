using System;
using System.IO;
using System.Net;

namespace StatisticsUniqWordsHttp
{
	class WebPage
	{
        //адрес Web-страницы
		public string UrlPage { get; set; }
        //имя файла на локальном диске
        private string filename;
        public string FileName 
        { 
            get
			{
                return filename;
			}    
            
            set
			{
              if (string.IsNullOrEmpty(value))
			  {
                  throw new Exception($"Ошибка. Имя файла не может быть пустым.");
              }  
              else if (value.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0) 
              {
                throw new Exception($"Ошибка. Имя файла '{value}' содержит недопустимые символы.");
              }
              else
              {
                  filename = value;
              }

            }
        
        }
        //имя каталога на локальном диске
        private string localpath;
        public string LocalPath 
        {
            get 
            {
                return localpath;
            }
            
            set
			{
                if (!Directory.Exists(value))
                {
                    throw new Exception($"Ошибка. Каталог '{value}' не существует.");
                }
				else 
                {
                    localpath = value;
                }
            }
        
        }
        //имя файла для сохранения (расчетное)
        public string LocalFile
        {
            get
            {
                return Path.Combine(LocalPath, FileName); ;
            }

        }	
        //инициализация параметров
        public WebPage()
        {
            UrlPage = "https://www.simbirsoft.com/";
            LocalPath = Environment.CurrentDirectory;
            FileName = "webpage.http";
        }

        public WebPage(string urlpage, string localpath, string filename)
        {
            this.UrlPage = urlpage;
            this.LocalPath = localpath;
            this.FileName = filename;
        }

        //скачивание страницы на локальный диск
        public void DownloadFile()
		{
			WebClient client = new WebClient();
			client.DownloadFile(UrlPage, LocalFile);
		}
	}
}
