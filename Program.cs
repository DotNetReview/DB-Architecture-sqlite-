using ConsoleApp1.Database;
using ConsoleApp1.Models;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static IDbService<User> userDbService;
        private static IDbService<News> newsDbService;

        static void Main(string[] args)
        {
            MainAsync();
        }

        private static async void MainAsync()
        {
            await InitializeAsync();

            await WorkWithDataAsync();
        }

        static async Task InitializeAsync()
        {
            var dbContext = new DbContext("myDB.db");
            await dbContext.ConnectToDatabase();

            userDbService = new DbService<User, int>(dbContext);
            newsDbService = new DbService<News, int>(dbContext);
        }

        private static async Task WorkWithDataAsync()
        {
            await userDbService.AddOrUpdate(new User { ID = 1, Name = "John" });
            var user = await userDbService.Where(x => x.ID == 1);

            var allNews = await newsDbService.GetAll();
        }
    }
}
