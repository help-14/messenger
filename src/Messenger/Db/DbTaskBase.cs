using LiteDB;
using System;
using System.IO;

namespace Messenger.Db
{
    public abstract class DbTaskBase
    {
        private static LiteDatabase _connection;

        public abstract object Query(LiteDatabase db);

        public object Execute()
        {
            if (_connection == null)
            {
                var dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.ini");
                var newDb = !File.Exists(dbPath);

                _connection = new LiteDatabase(dbPath);
                if (newDb) new InitDbTask().Execute();
            }
            return Query(_connection);
        }
    }
}
