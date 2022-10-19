using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using GuildCars.Data2.Interfaces;
using GuildCars.Models.Queries;
using System.Data;

namespace GuildCars.Data2.ADO
{
    public class VehiclesRepositoryADO : IVehiclesRepository
    {
        public void delete(int vehicleId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesDelete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@VehicleID", vehicleId);

                cn.Open();

                cmd.ExecuteNonQuery();

                
            }
        }

        public List<Vehicles> GetAll()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Vehicles currentRow = new Vehicles();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.NewOrUsed = dr["NewOrUsed"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.IsManual = dr["IsManual"].ToString();
                        currentRow.ExtColorID = (int)dr["ExtColorId"];
                        currentRow.IntColorID = (int)dr["IntColorId"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleImage = dr["VehicleImage"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalesPrice = (decimal)dr["SalesPrice"];
                        currentRow.isSold = dr["IsSold"].ToString();

                        vehicles.Add(currentRow); 


                    }
                }
            }

            return vehicles;
        }
        public List<VehicleMake> GetVehicleMakes()
        {
            List<VehicleMake> vehicleMakes = new List<VehicleMake>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectMakesAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleMake currentRow = new VehicleMake();
                        currentRow.MakeID = (int)dr["MakeId"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.UserName = dr["UserName"].ToString();

                        vehicleMakes.Add(currentRow);


                    }
                }

                return vehicleMakes;
            }
        }
        public List<VehicleModel> GetVehicleModels()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectModelsForMake", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModel currentRow = new VehicleModel();
                        currentRow.ModelID = (int)dr["ModelId"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.MakeID = (int)dr["MakeId"];

                        vehicleModels.Add(currentRow);


                    }
                }

                return vehicleModels;
            }
        }
        public List<VehicleModel> GetVehicleModelsAll()
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectModelsAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModel currentRow = new VehicleModel();
                        currentRow.ModelID = (int)dr["ModelId"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.MakeID = (int)dr["MakeId"];
                        currentRow.Make = dr["Make"].ToString();

                        vehicleModels.Add(currentRow);


                    }
                }

                return vehicleModels;
            }
        }

        public Vehicles GetById(int vehicleId)
        {
            Vehicles vehicle = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelect", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Vehicles vehicles = new Vehicles();

                        vehicles.VehicleID = (int)dr["VehicleID"];
                        vehicles.NewOrUsed = dr["NewOrUsed"].ToString(); ;
                        vehicles.VIN = dr["VIN"].ToString();
                        vehicles.MakeID = (int)dr["MakeID"];
                        vehicles.ModelID = (int)dr["ModelID"];
                        vehicles.IsManual = dr["IsManual"].ToString();
                        vehicles.ExtColorID = (int)dr["ExtColorId"];
                        vehicles.IntColorID = (int)dr["IntColorId"];
                        vehicles.Mileage = (decimal)dr["Mileage"];
                        vehicles.VehicleDescription = dr["VehicleDescription"].ToString();
                        //vehicles.VehicleImage = dr["VehicleImage"].ToString();
                        vehicles.DateAdded = (DateTime)dr["DateAdded"];
                        vehicles.VehicleYear = (int)dr["VehicleYear"];
                        vehicles.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicles.IsFeatured = (bool)dr["IsFeatured"];
                        vehicles.MSRP = (decimal)dr["MSRP"];
                        vehicles.SalesPrice = (decimal)dr["SalesPrice"];
                        vehicles.Make = dr["Make"].ToString();
                        vehicles.Model = dr["Model"].ToString();
                        vehicles.BodyStyle = dr["BodyStyle"].ToString();
                        vehicles.IntColor = dr["IntColor"].ToString();
                        vehicles.ExtColor = dr["ExtColor"].ToString();
                        vehicles.isSold = dr["isSold"].ToString();

                        if(dr["VehicleImage"]!= DBNull.Value)
                            vehicles.VehicleImage = dr["VehicleImage"].ToString();

                        return vehicles;


                    }
                }
            }
            return vehicle;
        }

        public IEnumerable<Vehicles>  GetFeatured()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectFeaturedVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

               

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles row = new Vehicles();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.NewOrUsed = dr["NewOrUsed"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.IsManual = dr["IsManual"].ToString();
                        row.ExtColorID = (int)dr["ExtColorId"];
                        row.IntColorID = (int)dr["IntColorId"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        //row.VehicleImage = dr["VehicleImage"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();

                        if (dr["VehicleImage"] != DBNull.Value)
                            row.VehicleImage = dr["VehicleImage"].ToString();

                        vehicles.Add(row);


                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<Vehicles> GetNew()
        {
            List<Vehicles> vehicles = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectNewVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles row = new Vehicles();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.NewOrUsed = dr["NewOrUsed"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.IsManual = dr["IsManual"].ToString();
                        row.ExtColorID = (int)dr["ExtColorId"];
                        row.IntColorID = (int)dr["IntColorId"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        //row.VehicleImage = dr["VehicleImage"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ExtColor = dr["ExtColor"].ToString();
                        row.IntColor = dr["IntColor"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.isSold = dr["IsSold"].ToString();

                        if (dr["VehicleImage"] != DBNull.Value)
                            row.VehicleImage = dr["VehicleImage"].ToString();

                        vehicles.Add(row);


                    }
                }
            }
            return vehicles;
        }

        public IEnumerable<SpecialsAndVehicles> GetSpecialsAndVehicles()
        {
            List<SpecialsAndVehicles> specialsAndVehicles = new List<SpecialsAndVehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsAndVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SpecialsAndVehicles currentRow = new SpecialsAndVehicles();
                        currentRow.VehicleID = (int)dr["VehicleID"];
                        currentRow.NewOrUsed = dr["NewOrUsed"].ToString();
                        currentRow.VIN = dr["VIN"].ToString();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.ModelID = (int)dr["ModelID"];
                        currentRow.IsManual = dr["IsManual"].ToString();
                        currentRow.ExtColorID = (int)dr["ExtColorId"];
                        currentRow.IntColorID = (int)dr["IntColorId"];
                        currentRow.Mileage = (decimal)dr["Mileage"];
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.VehicleImage = dr["VehicleImage"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.VehicleYear = (int)dr["VehicleYear"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.MSRP = (decimal)dr["MSRP"];
                        currentRow.SalesPrice = (decimal)dr["SalesPrice"];
                        currentRow.isSold = dr["IsSold"].ToString();
                        currentRow.SpecialID = (int)dr["SpecialId"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specialsAndVehicles.Add(currentRow);


                    }
                }
            }

            return specialsAndVehicles;
        }

        public IEnumerable<StockValueVehicles> GetStockValuesNew()
        {
            List<StockValueVehicles> stockNewVehicles = new List<StockValueVehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetStockValueNewVehicles", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        StockValueVehicles row = new StockValueVehicles();

                        row.vehicleYear = (int)dr["vehicleYear"];
                        row.vehicleMake = dr["Make"].ToString();
                        row.vehicleModel = dr["Model"].ToString();
                        row.countVehicleId = (int)dr["Count"];
                        row.sumMSRP = (decimal)dr["Stock Value"];
                        row.newOrUsed = dr["NewOrUsed"].ToString();

                        
                        stockNewVehicles.Add(row);


                    }
                }
            }
            return stockNewVehicles;
        }

        public void insert(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@NewOrUsed", vehicle.NewOrUsed);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@IsManual", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@ExtColorId", vehicle.ExtColorID);
                cmd.Parameters.AddWithValue("@IntColorId", vehicle.@IntColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehicleImage", vehicle.VehicleImage);
                cmd.Parameters.AddWithValue("@DateAdded", vehicle.DateAdded);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.isSold);
               


                cn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleID = (int)param.Value;                
            }
        }
        public void insertMake(VehicleMake vehicleMake)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Make", vehicleMake.Make);
                cmd.Parameters.AddWithValue("@UserName", vehicleMake.UserName);
                cmd.Parameters.AddWithValue("@DateAdded", vehicleMake.DateAdded);
                
   
                cn.Open();

                cmd.ExecuteNonQuery();

                vehicleMake.MakeID = (int)param.Value;
            }
        }

        public void insertModel(VehicleModel vehicleModel)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ModelId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Model", vehicleModel.Model);
                cmd.Parameters.AddWithValue("@UserName", vehicleModel.UserName);
                cmd.Parameters.AddWithValue("@DateAdded", vehicleModel.DateAdded);
                cmd.Parameters.AddWithValue("@MakeId", vehicleModel.Make);


                cn.Open();

                cmd.ExecuteNonQuery();

                vehicleModel.ModelID = (int)param.Value;
            }
        }
        public IEnumerable<Vehicles> SearchNew(VehicleSearchParameters parameters)
        {
            List<Vehicles> vehiclesSearch = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select top 20 v.*,vma.Make, vmo.Model, ext.ExtColor,  intcol.IntColor, bstyle.BodyStyle " +
                "from vehicles v " +
                "inner join vehiclemake vma on v.makeid = vma.makeid " +
                "inner join vehiclemodel vmo on v.modelid = vmo.modelid " +
                "inner join extcolorlookup ext on v.extcolorid = ext.extcolorid " +
                "inner join intcolorlookup intCol on v.intcolorid = intcol.intcolorid " +
                "inner join BodyStyleLookup bStyle on bStyle.BodyStyleId = v.BodyStyleId " +
                "where 1=1 and v.IsSold = 'No' and v.NewOrUsed = 'New' ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if (parameters.minYear.HasValue)
                {
                    query += "AND v.VehicleYear >= @minYear ";
                    cmd.Parameters.AddWithValue("@minYear", parameters.minYear.Value);
                }
                if (parameters.maxYear.HasValue)
                {
                    query += "AND v.VehicleYear <= @maxYear ";
                    cmd.Parameters.AddWithValue("@maxYear", parameters.maxYear.Value);
                }
                if (parameters.minPrice.HasValue)
                {
                    query += "AND v.MSRP >= @minPrice ";
                    cmd.Parameters.AddWithValue("@minPrice", parameters.minPrice.Value);
                }
                if (parameters.maxPrice.HasValue)
                {
                    query += "AND v.MSRP <= @maxPrice ";
                    cmd.Parameters.AddWithValue("@maxPrice", parameters.maxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.YearMakeModel))
                {
                    query += "AND (vehicleYear like @YearMakeModel " +
                        "OR vma.Make like @YearMakeModel " +
                        "OR vmo.Model like @YearMakeModel)";
                    cmd.Parameters.AddWithValue("@YearMakeModel", '%' + parameters.YearMakeModel + '%');
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles row = new Vehicles();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.NewOrUsed = dr["NewOrUsed"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.IsManual = dr["IsManual"].ToString();
                        row.ExtColorID = (int)dr["ExtColorId"];
                        row.IntColorID = (int)dr["IntColorId"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        //row.VehicleImage = dr["VehicleImage"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ExtColor = dr["ExtColor"].ToString();
                        row.IntColor = dr["IntColor"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.isSold = dr["IsSold"].ToString();

                        if (dr["VehicleImage"] != DBNull.Value)
                            row.VehicleImage = dr["VehicleImage"].ToString();

                        vehiclesSearch.Add(row);

                    }
                }
            }

            return vehiclesSearch;
        }

        public IEnumerable<Vehicles> SearchNotSold(VehicleSearchParameters parameters)
        {
            List<Vehicles> vehiclesSearch = new List<Vehicles>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select top 20 v.*,vma.Make, vmo.Model, ext.ExtColor,  intcol.IntColor, bstyle.BodyStyle " +
                "from vehicles v " +
                "inner join vehiclemake vma on v.makeid = vma.makeid " +
                "inner join vehiclemodel vmo on v.modelid = vmo.modelid " +
                "inner join extcolorlookup ext on v.extcolorid = ext.extcolorid " +
                "inner join intcolorlookup intCol on v.intcolorid = intcol.intcolorid " +
                "inner join BodyStyleLookup bStyle on bStyle.BodyStyleId = v.BodyStyleId " +
                "where 1=1 and v.IsSold = 'No' ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if (parameters.minYear.HasValue)
                {
                    query += "AND v.VehicleYear >= @minYear ";
                    cmd.Parameters.AddWithValue("@minYear", parameters.minYear.Value);
                }
                if (parameters.maxYear.HasValue)
                {
                    query += "AND v.VehicleYear <= @maxYear ";
                    cmd.Parameters.AddWithValue("@maxYear", parameters.maxYear.Value);
                }
                if (parameters.minPrice.HasValue)
                {
                    query += "AND v.MSRP >= @minPrice ";
                    cmd.Parameters.AddWithValue("@minPrice", parameters.minPrice.Value);
                }
                if (parameters.maxPrice.HasValue)
                {
                    query += "AND v.MSRP <= @maxPrice ";
                    cmd.Parameters.AddWithValue("@maxPrice", parameters.maxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.YearMakeModel))
                {
                    query += "AND (vehicleYear like @YearMakeModel " +
                        "OR vma.Make like @YearMakeModel " +
                        "OR vmo.Model like @YearMakeModel)";
                    cmd.Parameters.AddWithValue("@YearMakeModel", '%' + parameters.YearMakeModel + '%');
                }
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicles row = new Vehicles();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.NewOrUsed = dr["NewOrUsed"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.IsManual = dr["IsManual"].ToString();
                        row.ExtColorID = (int)dr["ExtColorId"];
                        row.IntColorID = (int)dr["IntColorId"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        //row.VehicleImage = dr["VehicleImage"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ExtColor = dr["ExtColor"].ToString();
                        row.IntColor = dr["IntColor"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.isSold = dr["IsSold"].ToString();

                        if (dr["VehicleImage"] != DBNull.Value)
                            row.VehicleImage = dr["VehicleImage"].ToString();

                        vehiclesSearch.Add(row);

                    }
                }
            }

            return vehiclesSearch;
        }

        public IEnumerable<Vehicles> SearchUsed(VehicleSearchParameters parameters)
        {
            List<Vehicles> vehiclesSearch = new List<Vehicles>();

            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select top 20 v.*,vma.Make, vmo.Model, ext.ExtColor,  intcol.IntColor, bstyle.BodyStyle " +
                "from vehicles v " +
                "inner join vehiclemake vma on v.makeid = vma.makeid " +
                "inner join vehiclemodel vmo on v.modelid = vmo.modelid " +
                "inner join extcolorlookup ext on v.extcolorid = ext.extcolorid " +
                "inner join intcolorlookup intCol on v.intcolorid = intcol.intcolorid " +
                "inner join BodyStyleLookup bStyle on bStyle.BodyStyleId = v.BodyStyleId " +
                "where 1=1 and v.NewOrUsed = 'Used' and v.IsSold = 'No' ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if (parameters.minYear.HasValue)
                {
                    query += "AND v.VehicleYear >= @minYear ";
                    cmd.Parameters.AddWithValue("@minYear", parameters.minYear.Value);
                }
                if (parameters.maxYear.HasValue)
                {
                    query += "AND v.VehicleYear <= @maxYear ";
                    cmd.Parameters.AddWithValue("@maxYear", parameters.maxYear.Value);
                }
                if (parameters.minPrice.HasValue)
                {
                    query += "AND v.MSRP >= @minPrice ";
                    cmd.Parameters.AddWithValue("@minPrice", parameters.minPrice.Value);
                }
                if (parameters.maxPrice.HasValue)
                {
                    query += "AND v.MSRP <= @maxPrice ";
                    cmd.Parameters.AddWithValue("@maxPrice", parameters.maxPrice.Value);
                }
                if (!string.IsNullOrEmpty(parameters.YearMakeModel))
                {
                    query += "AND (vehicleYear like @YearMakeModel " +
                        "OR vma.Make like @YearMakeModel " +
                        "OR vmo.Model like @YearMakeModel)";
                    cmd.Parameters.AddWithValue("@YearMakeModel", '%' +parameters.YearMakeModel + '%');
                }
                cmd.CommandText = query;
                cn.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Vehicles row = new Vehicles();

                        row.VehicleID = (int)dr["VehicleID"];
                        row.NewOrUsed = dr["NewOrUsed"].ToString();
                        row.VIN = dr["VIN"].ToString();
                        row.MakeID = (int)dr["MakeID"];
                        row.ModelID = (int)dr["ModelID"];
                        row.IsManual = dr["IsManual"].ToString();
                        row.ExtColorID = (int)dr["ExtColorId"];
                        row.IntColorID = (int)dr["IntColorId"];
                        row.Mileage = (decimal)dr["Mileage"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        //row.VehicleImage = dr["VehicleImage"].ToString();
                        row.DateAdded = (DateTime)dr["DateAdded"];
                        row.VehicleYear = (int)dr["VehicleYear"];
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalesPrice = (decimal)dr["SalesPrice"];
                        row.Make = dr["Make"].ToString();
                        row.Model = dr["Model"].ToString();
                        row.ExtColor = dr["ExtColor"].ToString();
                        row.IntColor = dr["IntColor"].ToString();
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.isSold = dr["IsSold"].ToString();

                        if (dr["VehicleImage"] != DBNull.Value)
                            row.VehicleImage = dr["VehicleImage"].ToString();

                        vehiclesSearch.Add(row);

                    }
                }
            }
            
            return vehiclesSearch; 
        }

        public void update(Vehicles vehicle)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehiclesUpdate", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@NewOrUsed", vehicle.NewOrUsed);
                cmd.Parameters.AddWithValue("@VIN", vehicle.VIN);
                cmd.Parameters.AddWithValue("@MakeId", vehicle.MakeID);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelID);
                cmd.Parameters.AddWithValue("@IsManual", vehicle.IsManual);
                cmd.Parameters.AddWithValue("@ExtColorId", vehicle.ExtColorID);
                cmd.Parameters.AddWithValue("@IntColorId", vehicle.@IntColorID);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@VehicleImage", vehicle.VehicleImage);
                cmd.Parameters.AddWithValue("@DateAdded", vehicle.DateAdded);
                cmd.Parameters.AddWithValue("@VehicleYear", vehicle.VehicleYear);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                cmd.Parameters.AddWithValue("@IsSold", vehicle.isSold);


                cn.Open();

                cmd.ExecuteNonQuery();

                
            }
        }

        public List<VehicleMake> getVehicleMake()
        {
            List<VehicleMake> vehicleMakes = new List<VehicleMake>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectMakesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleMake currentRow = new VehicleMake();

                        currentRow.MakeID = (int)dr["MakeId"];
                        currentRow.Make = dr["Make"].ToString();
                        currentRow.UserName = dr["UserName"].ToString();
                        

                        vehicleMakes.Add(currentRow);
                    }
                }
            }
            return vehicleMakes;
        }
        public List<VehicleModel> getVehicleModel(int MakeID)
        {
            List<VehicleModel> vehicleModels = new List<VehicleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectModelsForMake", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", MakeID);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleModel currentRow = new VehicleModel();

                        currentRow.MakeID = (int)dr["MakeId"];
                        currentRow.Model = dr["Model"].ToString();
                        currentRow.UserName = dr["UserName"].ToString();
                        currentRow.ModelID = (int)dr["ModelId"];


                        vehicleModels.Add(currentRow);
                    }
                }
            }
            return vehicleModels;
        }

        public List<BodyStyleLookup> getBodyStyle()
        {
            List<BodyStyleLookup> bodyStyles = new List<BodyStyleLookup>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select * " +
                "from BodyStyleLookup " +
                "where 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                
                
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyleLookup row = new BodyStyleLookup();

                        
                        row.BodyStyle = dr["BodyStyle"].ToString();
                        row.BodyStyleID = (int)dr["BodyStyleId"];
                       
                        bodyStyles.Add(row);

                    }
                }
            }

            return bodyStyles;
        }

        public List<newUsed> getNewOrUsed()
        {
            List<newUsed> newOrUsed = new List<newUsed>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select distinct newOrUsed " +
                "from Vehicles " +
                "where 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newUsed row = new newUsed();


                        row.newOrUsed = dr["newOrUsed"].ToString();

                        newOrUsed.Add(row);

                    }
                }
            }

            return newOrUsed;
        }

        public List<transmissionLookoup> getTransmission()
        {
            List<transmissionLookoup> transmissions = new List<transmissionLookoup>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select distinct isManual " +
                "from Vehicles " +
                "where 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        transmissionLookoup row = new transmissionLookoup();


                        row.transmissionType = dr["isManual"].ToString();

                        transmissions.Add(row);

                    }
                }
            }

            return transmissions;
        }

        public List<ExtColorLookup> getExtColors()
        {
            List<ExtColorLookup> extColors = new List<ExtColorLookup>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select * " +
                "from ExtColorLookup " +
                "where 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExtColorLookup row = new ExtColorLookup();


                        row.ExtColor = dr["ExtColor"].ToString();
                        row.ExtColorId = (int)dr["ExtColorId"];

                        extColors.Add(row);

                    }
                }
            }

            return extColors;
        }

        public List<IntColorLookup> getIntColors()
        {
            List<IntColorLookup> intColors = new List<IntColorLookup>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select * " +
                "from IntColorLookup " +
                "where 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;


                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        IntColorLookup row = new IntColorLookup();


                        row.IntColor = dr["IntColor"].ToString();
                        row.IntColorId = (int)dr["IntColorId"];

                        intColors.Add(row);

                    }
                }
            }

            return intColors;
        }
    }
}
