using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XperiaApp.Models
{
    class Categories
    {
        [PrimaryKey,AutoIncrement]
       public int CatID { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        
    }
}
