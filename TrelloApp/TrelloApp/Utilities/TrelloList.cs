using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloWebService.TrelloClasses
{
    public class TrelloList
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool closed { get; set; }
        public float pos { get; set; }
        public object softLimit { get; set; }
        public string idBoard { get; set; }
        public bool subscribed { get; set; }
    }

}
