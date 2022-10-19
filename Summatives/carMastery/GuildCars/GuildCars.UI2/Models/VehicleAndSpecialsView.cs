using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI2.Models
{
    public class VehicleAndSpecialsView
    {
        public IEnumerable<Vehicles> Vehicles { get; set; }
        public IEnumerable<Specials> Specials { get; set; }
    }
}