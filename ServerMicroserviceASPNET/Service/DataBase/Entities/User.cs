using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.DataBase.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Contact { get; set; }

    }
}
