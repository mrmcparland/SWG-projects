using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class VehicleMake
    {
        public int MakeID { get; set; }
        public string Make { get; set; }
        public string UserName { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
