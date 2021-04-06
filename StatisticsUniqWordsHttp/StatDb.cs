using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsUniqWordsHttp
{
    public class StatDb
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UrlPage { get; set; }
        public DateTime RequestTime { get; set; }
    
        public static void InsertStatDb(StatDb statDb, StatWordsDb statWordsDb)
        {
            using (AppContext db = new AppContext())
            {
                // создаем два объекта User
                StatDb request1 = new StatDb { User = "User1", RequestTime = DateTime.Now, UrlPage = "webpage_url" };
                StatDb request2 = new StatDb { User = "User2", RequestTime = DateTime.Now, UrlPage = "webpage_url2" };

                // добавляем их в бд
                db.statDb.Add(statDb);
                //db.statDb.Add(statWordsDb);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var req = db.statDb.ToList();
                Console.WriteLine("Список объектов:");
                foreach (StatDb r in req)
                {
                    Console.WriteLine($"{r.Id}.{r.User} {r.RequestTime} {r.UrlPage}");
                }
            }
        }    

    }

    public class StatWordsDb
    {
        public int Id { get; set; }
        public int PatentId { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }
    }


}
