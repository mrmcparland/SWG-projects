using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCheckout.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string FirstPublicationYear { get; set; }
    }
}
