using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RealaseDate { get; set; }
        public string CoverImg { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
