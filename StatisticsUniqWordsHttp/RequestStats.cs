using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsUniqWordsHttp
{
    public class RequestStats
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string UrlPage { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
