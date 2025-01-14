using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp
{
    internal class Session
    {
        public static int LoggedInUserId { get; set; } = -1; // Default to -1 (no user logged in)
        public static string ConnectionString = "Host=localhost;Port=5432;Database=FinancialApp_db;Username=postgres;Password=1323";

    }
}
