using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuildCars.Data2.Interfaces
{
    public interface IVehicleSalesRepository
    {
        List<VehicleSales> GetAll();
        List<VehicleSales> GetWithParams(SalesSearchParameters parameters);
        void salesLog(VehicleSales vehicleSales);
        
        List<State> GetStates();
        List<pmtType> GetPmtType();
       
    }
}
