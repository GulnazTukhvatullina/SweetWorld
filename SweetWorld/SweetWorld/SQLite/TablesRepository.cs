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
        }
    }
}
