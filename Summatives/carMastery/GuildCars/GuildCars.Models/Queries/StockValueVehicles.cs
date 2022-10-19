using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class StockValueVehicles
    {
        public int vehicleYear { get; set; }
        public string vehicleMake { get; set; }
        public string vehicleModel { get; set; }
        public int countVehicleId { get; set; }
        public decimal sumMSRP { get; set; }
        public string newOrUsed { get; set; }
        
    }
}
