using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Clock2
{
    internal class SqliteDataAccess
    {
        public static HolidayModel getNext()
        {
            HolidayModel h = new HolidayModel();

            using(IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HolidayModel>("select * from Holiday where Date>=date('now') order by Date limit 1", new DynamicParameters());

                List<HolidayModel> l = output.ToList();
                h = l[0];

                return h;
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
