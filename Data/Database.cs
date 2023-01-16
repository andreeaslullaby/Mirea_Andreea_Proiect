using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Mirea_Andreea_Proiect.Models;

namespace Mirea_Andreea_Proiect.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;
        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SecretList>().Wait();
        }
        public Task<List<SecretList>> GetSecretListsAsync()
        {
            return _database.Table<SecretList>().ToListAsync();
        }

        public Task<SecretList> GetSecretListAsync(int id)
        {
            return _database.Table<SecretList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveSecretListAsync(SecretList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }

        public Task<int> DeleteSecretListAsync(SecretList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}
