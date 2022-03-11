using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SweetWorld.SQLite
{
    public class TablesRepository
    {
        SQLiteConnection database;
        public TablesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }

        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }

        public int SaveUser(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
