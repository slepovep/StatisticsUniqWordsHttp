using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StatisticsUniqWordsHttp
{
 
    //detail StatDb
    public class StatDetailDb
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int Count { get; set; }
        public int StatDbId { get; set; }

        public static void Insert(StatDetailDb statWordsDb)
        {
            using (AppContext db = new AppContext())
            {
                // добавляем в бд
                db.statWordsDb.Add(statWordsDb);

                // получаем объекты из бд и выводим на консоль
                var req = db.statDb.ToList();
                Console.WriteLine("Список объектов:");
                foreach (StatDb r in req)
                {
                    Console.WriteLine($"{r.Id}.{r.User} {r.RequestTime} {r.LocalFile}");
                }

                //db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");


            }
        }


    }


}
