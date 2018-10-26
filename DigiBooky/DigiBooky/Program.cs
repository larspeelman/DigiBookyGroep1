using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Authors;
using Domain.Books;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DigiBooky
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitBooks();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void InitBooks()
        {
            Random red = new Random();
            Author[] authorList = new Author[]
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle")
            };
            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", Author = authorList[red.Next(0, 3)], Isbn = "isbn" + bookCount.ToString() });
            }
        }
    }
}
