using MoviesManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConsoleApp
{
    class Program
    {
        const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoviesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string GetFullName() => "dzevo";
        static void Main(string[] args)
        {
            var repo = new ArtistsRepo();
            //var result = repo.GetCount();
            //var result = repo.Delete(2);
            //while (true)
            //{
            //    var artists = repo.Search(Console.ReadLine());
            //    foreach (var artist in artists)
            //    {
            //        Console.WriteLine(artist); 
            //    }
            //}
            var artist = repo.GetById(int.Parse(Console.ReadLine()));
            Console.WriteLine(artist);
        }
    }
}

