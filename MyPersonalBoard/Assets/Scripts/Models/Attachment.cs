using System;
using System.Collections.Generic;
using System.Text;

namespace TrelloWebService.TrelloClasses
{
    public class Attachment
    {
        public string id { get; set; }
        public string bytes { get; set; }
        public DateTime date { get; set; }
        public string edgeColor { get; set; }
        public string idMember { get; set; }
        public bool isUpload { get; set; }
        public string mimeType { get; set; }
        public string name { get; set; }
        public object[] previews { get; set; }
        public string url { get; set; }
        public int pos { get; set; }
    }
}
