using CrispySpoon.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrispySpoon.Data
{
    public class CrispySpoonDatabase
    {
        readonly SQLiteAsyncConnection database;

        public CrispySpoonDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Vendor>().Wait();
        }

        public Task<List<Vendor>> GetItemsAsync()
        {
            return database.Table<Vendor>().ToListAsync();
        }

        public Task<List<Vendor>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Vendor>("SELECT * FROM [Vendor]");
        }

        public Task<Vendor> GetItemAsync(int id)
        {
            return database.Table<Vendor>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveVendorAsync(Vendor item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Vendor item)
        {
            return database.DeleteAsync(item);
        }
    }
}
