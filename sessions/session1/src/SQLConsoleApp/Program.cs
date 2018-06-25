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
            //int modifiedCount = db.SaveChanges();
            //cmd.ExecuteNonQuery();

            //var artist = db.artists.first();
            //cmd.ExecuteReader();

            //var artistsCount = db.artists.Count();
            //cmd.ExecuteScalar();

            var conn = new SqlConnection(connStr);
            conn.Open();
            var cmd = new SqlCommand("select count(*) from Artists", conn);
            object scalar = cmd.ExecuteScalar();
            int artistsCount = (int)scalar;
            conn.Close();
        }
    }
}
