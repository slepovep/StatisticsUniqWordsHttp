using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsUniqWordsHttp
{
    public class CRUD
    {
      public static void AddRequest ()
	  {

            using (AppContext db = new AppContext())
            {
                // создаем два объекта User
                RequestStats request1 = new RequestStats { User = "User1", RequestTime = DateTime.Now, UrlPage = "webpage_url" };
                RequestStats request2 = new RequestStats { User = "User2", RequestTime = DateTime.Now, UrlPage = "webpage_url2" };

                // добавляем их в бд
                db.RequestStat.Add(request1);
                db.RequestStat.Add(request2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
 
                // получаем объекты из бд и выводим на консоль
                var req = db.RequestStat.ToList();
                Console.WriteLine("Список объектов:");
                foreach (RequestStats r in req)
                {
                    Console.WriteLine($"{r.Id}.{r.User} {r.RequestTime} {r.UrlPage}");
                }
            }




	  }


    }
}
