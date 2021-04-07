using System;
using System.Linq;

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
                db.statDetailDb.Add(statWordsDb);
                db.SaveChanges();
            }
        }


    }


}
