using GuildCars.Data2.ADO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using GuildCars.Models.Queries;
using System.Data.SqlClient;
using System.Configuration;

namespace GuildCars.Tests.IntegrationTests
{
    [TestFixture]
    public  class AdoTests
    {
        [SetUp]
        public void init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "CarsReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void canLoadVehicles()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicles = repo.GetAll();

            Assert.AreEqual(21, vehicles.Count());

            Assert.AreEqual("TestVIN123", vehicles[0].VIN);
        }

        
        

        [Test]
        public void canLoadSpecials()
        {
            var repo = new SpecialsRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(3, specials.Count());
        }

        [Test]
        public void canLoadSales()
        {
            var repo = new VehicleSalesRepositoryADO();

            var sales = repo.GetAll();

            Assert.AreEqual(3, sales.Count());
        }
        [Test]
        public void canLoadVehicleById()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(5);

            Assert.IsNotNull(vehicle);

            Assert.AreEqual(5, vehicle.VehicleID);
            Assert.AreEqual("New", vehicle.NewOrUsed);
            Assert.AreEqual("3C6OP61598G485174", vehicle.VIN);
            Assert.AreEqual(1, vehicle.MakeID);
            Assert.AreEqual(5, vehicle.ModelID);
            Assert.AreEqual("Manual", vehicle.IsManual);
            Assert.AreEqual(5, vehicle.ExtColorID);
            Assert.AreEqual(5, vehicle.IntColorID);
            Assert.AreEqual(0.00M, vehicle.Mileage);
            Assert.AreEqual("Hurts to look at", vehicle.VehicleDescription);
            Assert.AreEqual("orangePassport.jpg", vehicle.VehicleImage);
            //Assert.AreEqual("2021-06-15 00:00:00d", vehicle.DateAdded);
            Assert.AreEqual(2021, vehicle.VehicleYear);
            Assert.AreEqual(2, vehicle.BodyStyleId);
            Assert.AreEqual(true, vehicle.IsFeatured);
            Assert.AreEqual(22599.99M, vehicle.MSRP);
            Assert.AreEqual(19589.46M, vehicle.SalesPrice);
        }

        [Test]
        public void NotFoundVehicleReturnsNull()
        {
            var repo = new VehiclesRepositoryADO();

            var vehicle = repo.GetById(500);

            Assert.IsNull(vehicle);
        }

        [Test]
        public void CanAddVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.NewOrUsed = "Used";
            vehicleToAdd.VIN = "AddedVIN789";
            vehicleToAdd.MakeID = 4;
            vehicleToAdd.ModelID = 15;
            vehicleToAdd.IsManual = "Automatic";
            vehicleToAdd.ExtColorID = 2;
            vehicleToAdd.IntColorID = 9;
            vehicleToAdd.Mileage = 1500.44M;
            vehicleToAdd.VehicleDescription = "Steal of a deal";
            vehicleToAdd.VehicleImage = "testimg.png";
            vehicleToAdd.DateAdded = DateTime.Now;
            vehicleToAdd.VehicleYear = 2019;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.IsFeatured = false;
            vehicleToAdd.MSRP = 21554.32M;
            vehicleToAdd.SalesPrice = 21431.41M;
            vehicleToAdd.isSold = "No";


            repo.insert(vehicleToAdd);

            Assert.AreEqual(22, vehicleToAdd.VehicleID);
        }
        [Test]
        public void CanAddContact()
        {
            ContactAdd contactToAdd = new ContactAdd();
            var repo = new ContactsRepositoryADO();

            contactToAdd.ContactName = "Charlie";
            contactToAdd.ContactMessage = "y'all sell cars?";
            contactToAdd.ContactEmail = "mrmcparland@gmail.com";
            contactToAdd.ContactPhoneNumber = "815-993-0781";

            repo.addContact(contactToAdd);

            Assert.AreEqual("Charlie", contactToAdd.ContactName);
        }

        [Test]
        public void canUpdateVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.NewOrUsed = "Used";
            vehicleToAdd.VIN = "AddedVIN789";
            vehicleToAdd.MakeID = 4;
            vehicleToAdd.ModelID = 15;
            vehicleToAdd.IsManual = "Manual";
            vehicleToAdd.ExtColorID = 2;
            vehicleToAdd.IntColorID = 9;
            vehicleToAdd.Mileage = 1500.44M;
            vehicleToAdd.VehicleDescription = "Steal of a deal";
            vehicleToAdd.VehicleImage = "testimg.png";
            vehicleToAdd.DateAdded = DateTime.Now;
            vehicleToAdd.VehicleYear = 2019;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.IsFeatured = false;
            vehicleToAdd.MSRP = 21554.32M;
            vehicleToAdd.SalesPrice = 21431.41M;
            vehicleToAdd.isSold = "No";

            repo.insert(vehicleToAdd);

            vehicleToAdd.NewOrUsed = "New";
            vehicleToAdd.VIN = "Changed123";
            vehicleToAdd.MakeID = 5;
            vehicleToAdd.ModelID = 19;
            vehicleToAdd.IsManual = "Manual";
            vehicleToAdd.ExtColorID = 4;
            vehicleToAdd.IntColorID = 1;
            vehicleToAdd.Mileage = 0.0M;
            vehicleToAdd.VehicleDescription = "Oops, edits";
            vehicleToAdd.VehicleImage = "updatedImg.png";
            vehicleToAdd.DateAdded = DateTime.Now;
            vehicleToAdd.VehicleYear = 2018;
            vehicleToAdd.BodyStyleId = 2;
            vehicleToAdd.IsFeatured = true;
            vehicleToAdd.MSRP = 30000.01M;
            vehicleToAdd.SalesPrice = 29499.19M;
            vehicleToAdd.isSold = "No";
            repo.update(vehicleToAdd);

            var updatedVehicle = repo.GetById(21);

            Assert.AreEqual(4, updatedVehicle.MakeID);


        }

        [Test]
        public void canDeleteVehicle()
        {
            Vehicles vehicleToAdd = new Vehicles();
            var repo = new VehiclesRepositoryADO();

            vehicleToAdd.NewOrUsed = "Used";
            vehicleToAdd.VIN = "AddedVIN789";
            vehicleToAdd.MakeID = 4;
            vehicleToAdd.ModelID = 15;
            vehicleToAdd.IsManual = "Automatic";
            vehicleToAdd.ExtColorID = 2;
            vehicleToAdd.IntColorID = 9;
            vehicleToAdd.Mileage = 1500.44M;
            vehicleToAdd.VehicleDescription = "Steal of a deal";
            vehicleToAdd.VehicleImage = "testimg.png";
            vehicleToAdd.DateAdded = DateTime.Now;
            vehicleToAdd.VehicleYear = 2019;
            vehicleToAdd.BodyStyleId = 1;
            vehicleToAdd.IsFeatured = false;
            vehicleToAdd.MSRP = 21554.32M;
            vehicleToAdd.SalesPrice = 21431.41M;
            vehicleToAdd.isSold = "No";

            repo.insert(vehicleToAdd);

            var loaded = repo.GetById(21);
            Assert.IsNotNull(loaded);

            repo.delete(21);
            loaded= repo.GetById(21);

            Assert.IsNull(loaded);
        }

        [Test]
        public void canLoadFeaturedVehicles()
        {
            var repo = new VehiclesRepositoryADO();
            List<Vehicles> featuredVehicles = repo.GetFeatured().ToList();

            Assert.AreEqual(8, featuredVehicles.Count());

            Assert.AreEqual("TestVIN123", featuredVehicles[0].VIN);
        }
        [Test]
        public void canLoadNewVehicles()
        {
            var repo = new VehiclesRepositoryADO();
            List<Vehicles> newVehicles = repo.GetNew().ToList();

            Assert.AreEqual(8, newVehicles.Count());

            Assert.AreEqual("3C6OP61598G485174", newVehicles[1].VIN);

            Assert.AreEqual("White", newVehicles[2].ExtColor);
        }
        [Test]
        public void canLoadUnsoldVehicles()
        {
            var parameters = new VehicleSearchParameters()
            {
                YearMakeModel = "",
                minPrice = 1000,
                maxPrice = 20000,
                maxYear = 2015,
                minYear = 2005
            };
            var repo = new VehiclesRepositoryADO();
            List<Vehicles> unsoldVehicles = repo.SearchNotSold(parameters).ToList();

            Assert.AreEqual(5, unsoldVehicles.Count);
            Assert.AreNotEqual(4, unsoldVehicles.Count);
        }

        [Test]
        public void canLoadStockValueNew()
        {
            var repo = new VehiclesRepositoryADO();
            List<StockValueVehicles> stockValueNew = repo.GetStockValuesNew().ToList();

            Assert.AreEqual(47282.31, stockValueNew[0].sumMSRP);

            
        }
        [Test]
        public void canSearchOnPrice()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchUsed(new VehicleSearchParameters { minPrice = 10000M });
            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void canSearchOnMake()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchUsed(new VehicleSearchParameters { YearMakeModel = "ord" });
            Assert.AreEqual(2, found.Count());
        }
        [Test]
        public void canSearchOnYear()
        {
            var repo = new VehiclesRepositoryADO();

            var found = repo.SearchUsed(new VehicleSearchParameters { YearMakeModel = "2020" });
            Assert.AreEqual(0, found.Count());

            
        }
        [Test]
        public void canSearchSales()
        {
            var repo = new VehicleSalesRepositoryADO();

            var found = repo.GetWithParams(new SalesSearchParameters { userName = "Mike M" });
            Assert.AreEqual(1, found.Count());
            //Assert.AreEqual("Jeff Garland", found[0].CustomerName);
        }
        [Test]
        public void canRecordSales()
        {
            var repo = new VehicleSalesRepositoryADO();
            var SalesID = new VehicleSalesRepositoryADO().GetAll().Count;

           

            VehicleSales salesLog = new VehicleSales();

            salesLog.purchasedVehicleID = 1;
            salesLog.SalesPrice = 25333.30M;
            salesLog.UserName = "Mike M";
            salesLog.CustomerName = "Caitie M";
            salesLog.Email = "cmcp@gmail.com";
            salesLog.PmtType = "Cash";
            salesLog.City = "Oswego";
            salesLog.StreetAdd1 = "22 Aldon";
            salesLog.StateID = "IL";
            salesLog.Zipcode = 60384;
            
            salesLog.dateOfSale = DateTime.Now;

            repo.salesLog(salesLog);

            var justSold = new VehiclesRepositoryADO().GetById(salesLog.purchasedVehicleID);
            var salesTest = new VehicleSalesRepositoryADO().GetAll();


            Assert.AreEqual(25333.30M, justSold.SalesPrice);

            Assert.AreNotEqual(0.0M, justSold.SalesPrice);

            //Assert.AreEqual(6, salesTest.Count());

            
        }

        [Test]
        public void canUpdateVehicleSoldStatus()
        {
            var repo = new VehicleSalesRepositoryADO();
           
            VehicleSales salesLog = new VehicleSales();

            salesLog.SalesPrice = 25000.8M;
            salesLog.VehicleId = 1;

            repo.salesLog(salesLog);
            var soldVehicle = new VehiclesRepositoryADO().GetById(1);
            Assert.AreEqual(true, soldVehicle.isSold);
           // Assert.AreEqual(25000.8M, soldVehicle.SalesPrice);
        }

        [Test]
        public void canLoadVehicleMake()
        {
            var repo = new VehiclesRepositoryADO();

            var makeCount = repo.getVehicleMake();

            Assert.AreEqual(5, makeCount.Count);
            Assert.AreEqual("Toyota", makeCount[0].Make);
        }

        [Test]
        public void canLoadVehicleModel()
        {
            var repo = new VehiclesRepositoryADO();
            var model = repo.getVehicleModel(1);

            Assert.AreEqual("Corolla", model[0].Model);
        }
    }
}
