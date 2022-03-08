
using System.Collections.Generic;

namespace Messenger.Db.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Site { get; set; }
        public List<Cookie> Cookies { get; set; }
    }
}
