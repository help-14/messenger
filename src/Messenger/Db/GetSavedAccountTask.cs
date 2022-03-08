using LiteDB;
using Messenger.Db.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Messenger.Db
{
    public class GetSavedAccountTask : DbTaskBase
    {
        public override object Query(LiteDatabase db)
        {
            var accountTable = db.GetCollection<Account>("accounts");
            return accountTable.Query().ToList();
        }
    }
}
