using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace BuhgLite
{
    class Globals
    {
        public static string DbName = "BuhgDB.sqlite";

        public static SQLiteConnection Connection = null;
    }
}
