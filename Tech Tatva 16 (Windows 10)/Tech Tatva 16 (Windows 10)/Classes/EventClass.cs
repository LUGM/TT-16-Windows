using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Tatva_16__Windows_10_.Classes
{
    public class EventClass
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Fav_Image { get; set; }
        public string Description { get; set; }
        public string Time;
        public string Date;
        public string Location;
    }

    public class Day
    {
        public string day { get; set; }
        public ObservableCollection<EventClass> Events { get; set; }
    }

    public class Results
    {
            public string EventName { get; set; }
            public string Image { get; set; }
    }
}
