using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Contacts
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactMessage { get; set; }
        public string ContactPhoneNumber { get; set; }
    }
}
