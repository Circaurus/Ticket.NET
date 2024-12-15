using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketNET.Models
{
    public class Events : BaseResponse
    {
        public Embedded _embedded {  get; set; }

        public class Embedded
        {
            public Event[] events { get; set; }
        }

        public class Event
        {
            public string name { get; set; }
            public string description { get; set; }
            public string id { get; set; }
            public string url { get; set; }
            public Dates[] dates { get; set; }

        }

        public class Dates
        {
            public EventDateInfo[] start { get; set; }
        }

        public class EventDateInfo
        {
            public string localDate { get; set; }
        }
    }
}
