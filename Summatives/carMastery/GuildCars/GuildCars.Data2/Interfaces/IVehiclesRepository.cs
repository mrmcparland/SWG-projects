using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using GuildCars.Models.Queries;
namespace GuildCars.Data2.Interfaces
{
    public interface IVehiclesRepository
    {
        List<Vehicles> GetAll();
        List<VehicleMake> GetVehicleMakes();
        List<VehicleModel> GetVehicleModels();
        List<VehicleModel> GetVehicleModelsAll();
        Vehicles GetById(int vehicleId);
        void insert(Vehicles vehicle);
        void insertMake(VehicleMake vehicleMake);
        void insertModel(VehicleModel vehicleModel);
        void update(Vehicles vehicle);
        void delete(int vehicleId);
        IEnumerable<Vehicles> GetFeatured();
        IEnumerable<Vehicles> GetNew();
        IEnumerable<StockValueVehicles> GetStockValuesNew();
        IEnumerable<Vehicles> SearchUsed(VehicleSearchParameters parameters);
        IEnumerable<Vehicles> SearchNew(VehicleSearchParameters parameters);
        IEnumerable<SpecialsAndVehicles> GetSpecialsAndVehicles();
        IEnumerable<Vehicles> SearchNotSold(VehicleSearchParameters parameters);
        List<VehicleMake> getVehicleMake();
        List<VehicleModel> getVehicleModel(int MakeID);
        List<BodyStyleLookup> getBodyStyle();
        List<newUsed> getNewOrUsed();
        List<transmissionLookoup> getTransmission();
        List<ExtColorLookup> getExtColors();
        List<IntColorLookup> getIntColors();

    }
}
