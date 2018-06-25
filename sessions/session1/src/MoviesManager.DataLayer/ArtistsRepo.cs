using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesManager
{
    public class ArtistsRepo : IDisposable
    {
        //int modifiedCount = db.SaveChanges();
        //cmd.ExecuteNonQuery();

        //var artist = db.artists.first();
        //cmd.ExecuteReader();

        //var artistsCount = db.artists.Count();
        //cmd.ExecuteScalar();

        const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MoviesDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection conn;
        public ArtistsRepo()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }
        public int GetCount()
        {
            var cmd = new SqlCommand("select count(*) from Artists", conn);
            object scalar = cmd.ExecuteScalar();
            int artistsCount = (int)scalar;
            conn.Close();
            return artistsCount;
        }
        public bool Delete(int id)
        {
            var cmd = new SqlCommand("delete from Artists where Artists.Id = " + id, conn);
            int modifiedCount = cmd.ExecuteNonQuery();
            conn.Close();
            return modifiedCount > 0;
        }
        public List<Artist> Search(string query)
        {
            using (var cmd = new SqlCommand("select * from Artists where Artists.Id = @query", conn))
            {
                cmd.Parameters.AddWithValue("query", query);
                using (var reader = cmd.ExecuteReader())
                {
                    var artists = new List<Artist>();
                    while (reader.Read())
                    {
                        int id = (int)reader["Id"];
                        string fullName = (string)reader["FullName"];
                        var artist = new Artist
                        {
                            FullName = fullName,
                            Id = id
                        };
                        artists.Add(artist);
                    }
                    return artists;
                }
            }
        }
        public Artist GetById(int id)
        {
            using (var cmd = new SqlCommand("select * from Artists where Artists.Id = @ID", conn))
            {
                cmd.Parameters.AddWithValue("ID", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int dbId = (int)reader["Id"];
                        string fullName = (string)reader["FullName"];
                        var artist = new Artist
                        {
                            FullName = fullName,
                            Id = dbId
                        };
                        return artist;
                    }
                }
            }
            return null;
        }
        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
