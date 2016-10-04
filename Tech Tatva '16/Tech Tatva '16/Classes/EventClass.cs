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
        public string Description { get; set; }
        public string Venue { get; set; }
        public string Stime { get; set; }
        public string Etime { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string TeamSize { get; set; }
        public string Round { get; set; }
        public string Contact { get; set; }
        public string Image { get; set; }
        public string Fav_Image { get; set; }
    }

    public class Day
    {
        public string day { get; set; }
        public List<EventClass> Events {get; set;}
    }

    public class Team
    {
        public string Teamid { get; set; }
        public string Round { get; set; }
        public string Position { get; set; }
    }

    public class Results
    {
        public string eve { get; set; }
        public string Image { get; set; }
        public List<Team> Teams { get; set; }

        public Results()
        {
            Image = "ms-appx:///Assets/Square71x71Logo.scale-240.png";
        }

    }       

    public class Schedule
    {
        public string eid { get; set; }
        public string ename { get; set; }
        public string catid { get; set; }
        public string catname { get; set; }
        public string round { get; set; }
        public string venue { get; set; }
        public string stime { get; set; }
        public string etime { get; set; }
        public string day { get; set; }
        public string date { get; set; }

    }

    public class EventAPI
    {
        public string ename { get; set; }
        public string eid { get; set; }
        public string edesc { get; set; }
        public string emaxteamsize { get; set; }
        public string cid { get; set; }
        public string cname { get; set; }
        public string cntctname { get; set; }
        public string cntctno { get; set; }
        public string hs1 { get; set; }
        public string hs2 { get; set; }

    }

    public class ListSchedule
    {
        public List<Schedule> data { get; set; }
    }

    public class ListEventAPI
    {
        public List<EventAPI> data { get; set; }
    }

    public class ResultAPI
    {
        public string eve { get; set; }
        public string Image { get; set; }
        public string tid { get; set; }
        public string cat { get; set; }
        public string round { get; set; }
        public string pos { get; set; }
    }

    public class ListResultAPI
    {
        public List<ResultAPI> data { get; set; }
    }
}
