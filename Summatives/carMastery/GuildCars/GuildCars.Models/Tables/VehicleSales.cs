using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class VehicleSales
    {
        public int SalesID { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PmtType { get; set; }
        public string StreetAdd1 { get; set; }
        public string StreetAdd2 { get; set; }
        public string StateID { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public decimal SalesPrice { get; set; }
        public int VehicleId { get; set; }
        public DateTime dateOfSale { get; set; }
        public string PhoneNumber { get; set; }
        public int purchasedVehicleID { get; set; }
    }
}
