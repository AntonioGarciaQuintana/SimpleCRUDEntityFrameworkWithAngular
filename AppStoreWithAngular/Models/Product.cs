using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppStoreWithAngular.Models
{
    public class Product
    {
        public long id { get; set; }

        public string name { get; set; }

        public string code { get; set; }

        public string decription { get; set; }

        public int stock { get; set; }
    }
}