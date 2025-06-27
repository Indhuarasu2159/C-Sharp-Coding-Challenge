using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Util
{
    public class DBPropertyUtil
    {
        public static string GetProperty(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
