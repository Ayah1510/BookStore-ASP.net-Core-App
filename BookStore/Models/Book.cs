using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public  String Description { get; set; }

        public String ImgageURL { get; set; }
        public Author Author { get; set; }
    }
}
