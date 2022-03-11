using System;
using System.Collections.Generic;
using System.Text;

namespace SweetWorld.SQLite
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
