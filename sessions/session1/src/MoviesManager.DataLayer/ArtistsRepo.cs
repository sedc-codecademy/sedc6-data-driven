using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesManager
{
    public class ArtistsRepo
    {
        //int modifiedCount = db.SaveChanges();
        //cmd.ExecuteNonQuery();

        //var artist = db.artists.first();
        //cmd.ExecuteReader();

        //var artistsCount = db.artists.Count();
        //cmd.ExecuteScalar();

        const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoviesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int GetCount()
        {
            var conn = new SqlConnection(connStr);
            conn.Open();
            var cmd = new SqlCommand("select count(*) from Artists", conn);
            object scalar = cmd.ExecuteScalar();
            int artistsCount = (int)scalar;
            conn.Close();
            return artistsCount;
        }

        public bool Delete(int id)
        {
            var conn = new SqlConnection(connStr);
            conn.Open();
            var cmd = new SqlCommand("delete from Artists where Artists.Id = " + id, conn);
            int modifiedCount = cmd.ExecuteNonQuery();
            conn.Close();
            return modifiedCount > 0;
        }
    }
}
