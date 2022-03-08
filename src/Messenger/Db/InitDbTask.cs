using LiteDB;
using Messenger.Db.Models;
using System;
using System.Threading.Tasks;

namespace Messenger.Db
{
    public class InitDbTask : DbTaskBase
    {
        public override object Query(LiteDatabase db)
        {
            var account = db.GetCollection<Account>("accounts");
            account.EnsureIndex(x => x.Id);
            return true;
        }
    }
}
