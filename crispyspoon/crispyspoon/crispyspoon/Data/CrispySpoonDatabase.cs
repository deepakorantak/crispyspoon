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

        public Task<List<T>> GetDataAsync<T>() where T : new()
        {
            return database.Table<T>().ToListAsync();
        }

        public Task<T> GetDataByIdAsync<T>(int id) where T : IEntity ,new() 
        {
            return database.Table<T>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveDataAsync<T>(T item) where T : IEntity, new()
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

        public Task<int> DeleteDataAsync<T>(T item) where T : IEntity, new()
        {
            return database.DeleteAsync(item);
        }
    }
}
