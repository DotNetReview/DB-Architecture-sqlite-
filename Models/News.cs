using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class News : IDbModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
