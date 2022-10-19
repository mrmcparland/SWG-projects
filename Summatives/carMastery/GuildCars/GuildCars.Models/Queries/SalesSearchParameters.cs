using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SalesSearchParameters
    {
        public DateTime? minDate { get; set; }
        public DateTime? maxDate { get; set; }
        public string userName { get; set; }
    }
}
