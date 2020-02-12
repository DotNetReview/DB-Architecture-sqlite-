using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IDbContext
    {
        SQLiteAsyncConnection Connection { get; }

        Task ConnectToDatabase();
        Task CreateTables();
        Task DropDatabase();
    }
}
