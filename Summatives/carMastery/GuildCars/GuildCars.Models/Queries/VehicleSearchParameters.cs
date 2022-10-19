using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleSearchParameters
    {
        public int? minYear { get; set; }
        public int? maxYear { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public string YearMakeModel { get; set; }
    }
}
