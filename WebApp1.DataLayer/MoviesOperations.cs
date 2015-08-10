using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebApp1.Entities;


namespace WebApp1.DataLayer
{
    public class MoviesOperations : BaseOperations
    {
        public MoviesOperations(SqlConnection connection) : base(connection) { }
        public MoviesOperations(string connectionString) : base(connectionString) { }
        public MoviesOperations() : base() { }

        List<Movie> movies = new List<Movie>();
        public List<Movie> GetMovies(int offset, int perPage)
        {
            using (SqlCommand command = new SqlCommand("Movies_Get", Connection)
            {
                CommandType = CommandType.StoredProcedure })

            {
                command.Parameters.AddWithValue("offset",offset);
                command.Parameters.AddWithValue("perPage", perPage);
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        movies.Add(Movie.ReadMovie(reader));
                }
            }
            return movies;
        }

        public void AddMovie(Movie newMovie)
        {
            using (SqlCommand command = new SqlCommand("Movie_Post", Connection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("ID", newMovie.ID);
                command.Parameters.AddWithValue("Title", newMovie.Title);
                command.Parameters.AddWithValue("ReleaseDate", newMovie.ReleaseDate);
                command.Parameters.AddWithValue("Genre", newMovie.Genre);
                command.Parameters.AddWithValue("Price", newMovie.Price);
                command.ExecuteNonQuery();
            }
        }

        public Movie GetMovie(int id)
        {
            Movie movie = null;
            using (SqlCommand command = new SqlCommand("Single_Movie_Get", Connection) { CommandType = CommandType.StoredProcedure })
            {
                command.Parameters.AddWithValue("ID", id);
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie = Movie.ReadMovie(reader);
                    }
                    
                }
                return movie;
            }
        }

        public List<Movie> SearchMovie(string searchString)
        {
            List<Movie> foundMovieList = new List<Movie>();
            using(SqlCommand command = new SqlCommand("Moive_Search",Connection){CommandType = CommandType.StoredProcedure})
            {
                command.Parameters.AddWithValue("searchString", searchString);
                using (IDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        foundMovieList.Add(Movie.ReadMovie(reader));
                    }
                }
            }
            return foundMovieList;
        }

        public int GetMovieCount()
        {
            int movieCount=0;
            using (SqlCommand command = new SqlCommand("Movie_Count_Get", Connection) { CommandType = CommandType.StoredProcedure })
            {
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movieCount = reader.GetInt32(0);
                    }
                }
            }
            return movieCount;
        }
    }
}
