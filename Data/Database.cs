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
            _database.CreateTableAsync<SignList>().Wait();
            _database.CreateTableAsync<Sign>().Wait();
            _database.CreateTableAsync<ListSign>().Wait();
        }

        public Task<int> SaveSignAsync(Sign sign)
        {
            if (sign.ID != 0)
            {
                return _database.UpdateAsync(sign);
            }
            else
            {
                return _database.InsertAsync(sign);
            }
        }

        public Task<int> DeleteSignAsync(Sign sign)
        {
            return _database.DeleteAsync(sign);
        }
        public Task<List<Sign>> GetSignsAsync()
        {
            return _database.Table<Sign>().ToListAsync();
        }
        public Task<List<SignList>> GetSignListsAsync()
        {
            return _database.Table<SignList>().ToListAsync();
        }

        public Task<SignList> GetSignListAsync(int id)
        {
            return _database.Table<SignList>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveSignListAsync(SignList slist)
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

        public Task<int> DeleteSecretListAsync(SignList slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveListSignAsync(ListSign lists)
        {
            if (lists.ID != 0)
            {
                return _database.UpdateAsync(lists);
            }
            else
            {
                return _database.InsertAsync(lists);
            }
        }

        public Task<List<Sign>> GetListSignsAsync(int signlistid)
        {
            return _database.QueryAsync<Sign>( "select S.ID, S.Description from Sign S"+ "inner join ListSign LS" + " on S.ID = LS.SignID where LS.SignListID = ?",signlistid);
        }
    }
}
