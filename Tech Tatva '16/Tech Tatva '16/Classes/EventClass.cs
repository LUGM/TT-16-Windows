using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Tatva__16
{

    public class EventClass
    {
        [SQLite.PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Fav_Image { get; set; }
    }

    public class Day
    {
        public string day { get; set; }
        public List<EventClass> Events {get; set;}
    }

    public class Results
    {
        public string EventName { get; set; }
        public string Image { get; set; }
    }

}
