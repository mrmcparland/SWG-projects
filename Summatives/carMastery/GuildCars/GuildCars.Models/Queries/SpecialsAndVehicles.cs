using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class SpecialsAndVehicles
    {
        public int VehicleID { get; set; }
        public string NewOrUsed { get; set; }
        public string VIN { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public string IsManual { get; set; }
        public int ExtColorID { get; set; }
        public int IntColorID { get; set; }
        public decimal Mileage { get; set; }
        public string VehicleDescription { get; set; }
        public string VehicleImage { get; set; }
        public DateTime DateAdded { get; set; }
        public int VehicleYear { get; set; }
        public int BodyStyleId { get; set; }
        public bool IsFeatured { get; set; }
        public decimal MSRP { get; set; }
        public decimal SalesPrice { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ExtColor { get; set; }
        public string IntColor { get; set; }
        public string BodyStyle { get; set; }
        public string isSold { get; set; }
        public int SpecialID { get; set; }
        public string SpecialTitle { get; set; }
        public string SpecialDescription { get; set; }
    }
}
