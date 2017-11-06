using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserMicroService.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public string cityName { get; set; }
        public string countryName { get; set; }
        public string phone { get; set; }
        public bool active { get; set; }

    }
}