using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WebApp1.Entities
{
    public class Movie: BaseObject
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Genre { get; set; }
        public decimal Price { get; set; }
        public static Movie ReadMovie(IDataReader reader)
        {
            Movie movie = new Movie();
            movie.ID = reader.GetInt32(0);
            movie.Title = reader.GetString(1);
            movie.ReleaseDate = reader.GetDateTime(2).Date;
            movie.Genre = reader.GetString(3);
            movie.Price = reader.GetDecimal(4);
            return movie;
        }
    }
}
