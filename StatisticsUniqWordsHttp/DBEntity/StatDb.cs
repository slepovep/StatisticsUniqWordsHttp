using System;
using System.Collections.Generic;

namespace StatisticsUniqWordsHttp
{
    public class StatDb
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string LocalFile { get; set; }
        public DateTime RequestTime { get; set; } = DateTime.Now;
        public List<StatDetailDb> StatDetail { get; set; }

        public static int Insert(StatDb statDb)
        {
            using (AppContext db = new AppContext())
            {
                // добавляем в бд
                db.statDb.Add(statDb);
                db.SaveChanges();
                return statDb.Id;
            }
        }    

    }

}
