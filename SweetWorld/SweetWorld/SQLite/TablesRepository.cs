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
            database.CreateTable<Favourite>();
            database.CreateTable<Backet>();
            database.CreateTable<Request>();
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }

        public IEnumerable<Assortment> GetAssortments()
        {
            return database.Table<Assortment>().ToList();
        }

        public IEnumerable<Backet> GetBackets()
        {
            return database.Table<Backet>().ToList();
        }

        public Backet GetBacketId(int idUser, int idAssortment)
        {
            return database.Table<Backet>().Where(a => a.IdUser == idUser && a.IdAssortment == idAssortment).FirstOrDefault();
                
        }

        public double GetBacketSum(int idUser)
        {
            double sum = 0;
            foreach (var i in database.Table<Backet>().Where(a => a.IdUser == idUser).ToList())
            {
                sum += i.Summa;
            }
            return sum;
        }

        //public IEnumerable<Request> GetUserRequestDate()
        //{
        //    return database.Query<Request>("");
        //}

        public Backet GetBacket(int id)
        {
            return database.Get<Backet>(id);
        }

        public Assortment GetAssortmentsId(int id)
        {
            return database.Table<Assortment>().Where(a => a.Id == id).FirstOrDefault();
        }

        public Backet GetBacketUser(int idUser)
        {
            return database.Table<Backet>().Where(a => a.IdUser == idUser).FirstOrDefault();
        }

        public IEnumerable<Backet> GetBacketsUser(int idUser)
        {
            return database.Table<Backet>().Where(a => a.IdUser == idUser).ToList();
        }

        public IEnumerable<Assortment> GetAssortmentsType(string type)
        {
            return database.Table<Assortment>().Where(a=>a.Type==type).ToList();
        }

        public IEnumerable<Favourite> GetFavouriteUser(int idUser)
        {
            return database.Table<Favourite>().Where(a => a.IdUser == idUser).ToList();
        }

        public int GetCountAssortinBacket(int idUser)
        {
            int count = 0;
            foreach (var i in database.Table<Backet>().Where(a => a.IdUser == idUser).ToList())
            {
                count += i.Count;
            }
            return count;
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

        public int SaveBacket(Backet item)
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

        public int SaveRequest(Request item)
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

        public int DeleteFavourite(int id)
        {
            return database.Delete<Favourite>(id);
        }

        public int DeleteBacket(int id)
        {
            return database.Delete<Backet>(id);
        }

        public int GetFavouriteId(int idUser,int idAssortment)
        {
            return database.Table<Favourite>().Where(a => a.IdUser == idUser && a.IdAssortment == idAssortment).FirstOrDefault().Id;
        }

        public Favourite GetIsFavourite(int idUser, int idAssortment)
        {
            return database.Table<Favourite>().Where(a => a.IdUser == idUser && a.IdAssortment == idAssortment).FirstOrDefault();
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

        public int SaveFavourite(Favourite item)
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
