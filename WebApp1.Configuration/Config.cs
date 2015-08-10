using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WebApp1.Configuration
{
    public class Config
    {
        private static Config instance;
        public string ConnectionString { get; set; }
        private Config()
        {
            Load();
        }
        public static Config GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            }
        }

        private void Load()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MovieConnectionString"].ConnectionString;
        }
    }
}
