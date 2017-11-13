using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UserMicroService.Util
{
    public static class DBFunctions
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }
    }
}