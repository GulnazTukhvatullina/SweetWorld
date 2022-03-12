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
            database.CreateTable<Assortment>();
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public IEnumerable<Assortment> GetAssortments()
        {
            return database.Table<Assortment>().ToList();
        }

        public IEnumerable<Assortment> GetAssortmentsType(string type)
        {
            return database.Table<Assortment>().Where(a=>a.Type==type).ToList();
        }
        public int SaveAssortment(Assortment item)
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

        public int DeleteAssortment(int id)
        {
            return database.Delete<Assortment>(id);
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
