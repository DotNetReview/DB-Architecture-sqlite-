using ConsoleApp1.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DbContext : IDbContext
    {
        public SQLiteAsyncConnection Connection { get; private set; }

        public string DatabasePath { get; }

        public DbContext(string databasePath)
        {
            DatabasePath = databasePath;
        }


        public async Task ConnectToDatabase()
        {
            Connection = new SQLiteAsyncConnection(DatabasePath);

            await CreateTables()
                .ConfigureAwait(false);
        }

        public async Task CreateTables()
        {
            await Connection.CreateTablesAsync<User, News>()
                .ConfigureAwait(false);
        }

        public async Task DropDatabase()
        {
            if (Connection is null)
            {
                throw new NullReferenceException("No Connection with database");
            }

            await Connection.DropTableAsync<User>().ConfigureAwait(false);
            await Connection.DropTableAsync<News>().ConfigureAwait(false);
        }
    }
}
