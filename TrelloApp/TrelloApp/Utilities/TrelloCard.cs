using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloWebService.TrelloClasses
{
    public class TrelloCard
    {
        public string id { get; set; }
        public string address { get; set; }
        public Badges badges { get; set; }
        public string[] checkItemStates { get; set; }
        public bool closed { get; set; }
        public string coordinates { get; set; }
        public string creationMethod { get; set; }
        public DateTime dateLastActivity { get; set; }
        public string desc { get; set; }
        public Descdata descData { get; set; }
        public string due { get; set; }
        public string dueReminder { get; set; }
        public string email { get; set; }
        public string idBoard { get; set; }
        public string idChecklist { get; set; }
        public string[] idLabels { get; set; }
        public string idList { get; set; }
        public string[] idMembers { get; set; }
        public string[] idMembersVoted { get; set; }
        public int idShort { get; set; }
        public TrelloLabel[] labels { get; set; }
        public Limits limits { get; set; }
        public string locationName { get; set; }
        public bool manualCoverAttachment { get; set; }
        public string name { get; set; }
        public float pos { get; set; }
        public string shortLink { get; set; }
        public string shortUrl { get; set; }
        public bool subscribed { get; set; }
        public string url { get; set; }
        public Cover cover { get; set; }
    }

    public class Badges
    {
        public Attachmentsbytype attachmentsByType { get; set; }
        public bool location { get; set; }
        public int votes { get; set; }
        public bool viewingMemberVoted { get; set; }
        public bool subscribed { get; set; }
        public string fogbugz { get; set; }
        public int checkItems { get; set; }
        public int checkItemsChecked { get; set; }
        public int comments { get; set; }
        public int attachments { get; set; }
        public bool description { get; set; }
        public string due { get; set; }
        public bool dueComplete { get; set; }
    }

    public class Attachmentsbytype
    {
        public Trello trello { get; set; }
    }

    public class Trello
    {
        public int board { get; set; }
        public int card { get; set; }
    }

    public class Descdata
    {
        public Emoji emoji { get; set; }
    }

    public class Emoji
    {
    }

    public class Limits
    {
        public Attachments attachments { get; set; }
    }

    public class Attachments
    {
        public Perboard perBoard { get; set; }
    }

    public class Perboard
    {
        public string status { get; set; }
        public int disableAt { get; set; }
        public int warnAt { get; set; }
    }

    public class Cover
    {
        public string color { get; set; }
        public bool? idUploadedBackground { get; set; }
        public string size { get; set; }
        public string brightness { get; set; }
        public bool isTemplate { get; set; }
    }

    public class Idchecklist
    {
        public string id { get; set; }
    }

    public class TrelloLabel
    {
        public string id { get; set; }
        public string idBoard { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }

}
