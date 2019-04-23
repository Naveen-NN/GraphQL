using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLBookApi.DAO
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public decimal Price { get; set; }

        public int AuthorId {get;set;}

    }
}
