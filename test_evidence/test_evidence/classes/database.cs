using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_evidence.classes
{
   public class database
    {
        // SQLite connection
        private SQLiteAsyncConnection Database;

        public database(string dbPath)
        {
            Database = new SQLiteAsyncConnection(dbPath);
            Database.CreateTableAsync<auto>().Wait();
        }
        // Query
        public Task<List<auto>> GetItemsAsync()
        {
            return Database.Table<auto>().ToListAsync();
        }
        // Query using SQL query string
        public Task<List<auto>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<auto>("SELECT * FROM [auto] ");
        }


        public Task<int> SaveItemAsync(auto item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<List<auto>> DeleteItemAsync(int item)
        {
            return Database.QueryAsync<auto>("DELETE FROM [auto] WHERE [ID] = " + item);
        }

    }
}
