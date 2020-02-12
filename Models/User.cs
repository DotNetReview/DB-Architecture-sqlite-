using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class User : IDbModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
