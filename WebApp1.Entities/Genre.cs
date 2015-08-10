using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WebApp1.Entities
{
    public class Genre : BaseObject
    {
        public String GenreName { get; set; }

        public static Genre ReadGenre(IDataReader reader)
        {
            Genre genre = new Genre();
            genre.ID = reader.GetInt32(0);
            genre.GenreName = reader.GetString(1);
            return genre;
        }
    }
}
