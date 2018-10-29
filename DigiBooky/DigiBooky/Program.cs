﻿using System;
using System.Collections.Generic;
using Digibooky_domain.Authors;
using Digibooky_domain.Books;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Digibooky_api
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
            List<Author> authorList = new List<Author>
            {
                new Author("Jef", "Depaepe"),
                new Author("Jos", "Schuurlink"),
                new Author("Guido", "Gazelle"),
            };
            DBAuthors.AuthorDB = authorList;

            for (int bookCount = 1; bookCount < 50; bookCount++)
            {
                DBBooks.ListofBooks.Add(new Book { BookTitle = $"BookTitle{bookCount}", AuthorId = red.Next(1, 4).ToString(), Isbn = "isbn" + bookCount.ToString() });
            }
        }
    }
}
