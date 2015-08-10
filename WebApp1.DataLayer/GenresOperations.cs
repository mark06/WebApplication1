using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp1.Entities;
using System.Data.SqlClient;
using System.Data;

namespace WebApp1.DataLayer
{
    public class GenresOperations:BaseOperations
    {
        public GenresOperations(SqlConnection connection) : base(connection) { }
        public GenresOperations(String connectionString) : base(connectionString) { }
        public GenresOperations() : base() { }
        
        public List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();

            using (SqlCommand command = new SqlCommand("Genres_Get", Connection)
            {
                CommandType = CommandType.StoredProcedure})
            {
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genres.Add(Genre.ReadGenre(reader));
                    }
                }
            }

            return genres;
        }

        public void PostGenre(string newGenre)
        {
            using (SqlCommand command = new SqlCommand("Genre_Post", Connection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("Genre", newGenre);
                command.ExecuteNonQuery();
            }
        }

    }
}