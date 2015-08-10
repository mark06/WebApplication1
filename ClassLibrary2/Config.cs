using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ClassLibrary2
{
    public class Config
    {
        private static Config instance;

        private Config() { }

        private void Load()
        {
            instance.ConnectionString = ConfigurationManager.ConnectionStrings["MovieConnectionString"].ConnectionString;
        }

        public static Config GetInsatnce()
        {
            if (instance == null)
            {
                instance = new Config();
                instance.Load();
            }
            return instance;
        }

        public string ConnectionString { get; set;}
    }
}
