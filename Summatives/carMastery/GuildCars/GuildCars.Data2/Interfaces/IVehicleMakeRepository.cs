using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data2.Interfaces
{
    public interface IVehicleMakeRepository
    {
        List<VehicleMake> GetAll();
    }
}
