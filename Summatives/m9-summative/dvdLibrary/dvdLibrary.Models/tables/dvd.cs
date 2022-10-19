using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvdLibrary.Models.tables
{
    public  class dvd
    {
        public int dvdId { get; set; }
        public string dvdTitle { get; set; }
        public string dvdDirector { get; set; }
        public string dvdRating { get; set; }
        public int dvdReleaseYear { get; set; }
        public string notes { get; set; }
    }
}
