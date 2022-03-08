using LiteDB;
using Messenger.Db.Models;
using System.Threading.Tasks;

namespace Messenger.Db
{
    public class AddUpdateAccountTask : DbTaskBase
    {
        private Account _account;

        public AddUpdateAccountTask(Account account)
        {
            _account = account;
        }

        public override object Query(LiteDatabase db)
        {
            var accountTable = db.GetCollection<Account>("accounts");
            if (_account == null)
                throw new System.Exception("Input account can not be null.");

            if (_account.Id == 0)
                _account.Id = accountTable.Insert(_account).AsInt32;
            else
                accountTable.Update(_account);

            return _account;
        }
    }
}
