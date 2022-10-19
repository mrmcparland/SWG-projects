using GuildCars.Data2.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuildCars.Data2.ADO
{
    public class VehicleSalesRepositoryADO : IVehicleSalesRepository
    {
        public List<VehicleSales> GetAll()
        {
            List<VehicleSales> vehicleSales = new List<VehicleSales>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleSales currentRow = new VehicleSales();
                        //currentRow.SalesID = (int)dr["SalesId"];
                        currentRow.UserName = dr["UserName"].ToString();
                        //currentRow.Email = dr["Email"].ToString();
                        //currentRow.PmtType = dr["PmtType"].ToString();
                        //currentRow.StreetAdd1 = dr["StreetAdd1"].ToString();
                        //currentRow.StreetAdd2 = dr["StreetAdd2"].ToString();
                        //currentRow.StateID = dr["StateId"].ToString();
                        //currentRow.Zipcode = (int)dr["ZipCode"];
                        //currentRow.City = dr["City"].ToString();
                        currentRow.SalesPrice = (decimal)dr["SalesPrice"];
                        currentRow.VehicleId = (int)dr["VehiclesSold"];


                        vehicleSales.Add(currentRow);


                    }
                }
            }
            return vehicleSales;
        }

        public List<VehicleSales> GetWithParams(SalesSearchParameters parameters)
        {
            List<VehicleSales> vehicleSales = new List<VehicleSales>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "select v.UserName, sum(v.SalesPrice) as 'Total Sales', count(v.VehicleId) as 'Total Vehicles' " +
                "from VehicleSales v " +
                "where 1=1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if (parameters.minDate.HasValue)
                {
                    query += "AND v.dateOfSale >= @minDate ";
                    cmd.Parameters.AddWithValue("@minDate", parameters.minDate.Value);
                }
                if (parameters.maxDate.HasValue)
                {
                    query += "AND v.dateOfSale <= @maxDate ";
                    cmd.Parameters.AddWithValue("@maxDate", parameters.maxDate.Value);
                }
                
                if (parameters.userName != "-All-")
                {
                    query += "AND v.UserName like @userName ";
                    cmd.Parameters.AddWithValue("@userName", '%' + parameters.userName + '%');
                }

                query += "GROUP BY v.UserName";
                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleSales row = new VehicleSales();

                        
                        //row.SalesID = (int)dr["SalesID"];
                        row.UserName = dr["UserName"].ToString();
                        //row.CustomerName = dr["CustomerName"].ToString();
                        //row.Email = dr["Email"].ToString();
                        //row.PmtType = dr["PmtType"].ToString();
                        //row.StreetAdd1 = dr["StreetAdd1"].ToString();
                        //row.StreetAdd2 = dr["StreetAdd2"].ToString();
                        //row.StateID = dr["StateId"].ToString();
                        //row.Zipcode = (int)dr["ZipCode"];
                        //row.City = dr["City"].ToString();
                        row.SalesPrice = (decimal)dr["Total Sales"];
                        row.VehicleId = (int)dr["Total Vehicles"];
                       // row.dateOfSale = (DateTime)dr["dateOfSale"];

                        vehicleSales.Add(row);

                    }
                }
            }

            return vehicleSales;
        }

        public void salesLog(VehicleSales vehicleSales)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesLog", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SalesId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserName", vehicleSales.UserName);
                cmd.Parameters.AddWithValue("@CustomerName", vehicleSales.CustomerName);
                //cmd.Parameters.AddWithValue("@Email", vehicleSales.Email);
                cmd.Parameters.AddWithValue("@StreetAdd1", vehicleSales.StreetAdd1);
                cmd.Parameters.AddWithValue("@StateId", vehicleSales.StateID);
                cmd.Parameters.AddWithValue("@ZipCode", vehicleSales.Zipcode);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicleSales.SalesPrice);
                cmd.Parameters.AddWithValue("@VehicleId", vehicleSales.purchasedVehicleID);
                cmd.Parameters.AddWithValue("@DateOfSale", vehicleSales.dateOfSale);
                cmd.Parameters.AddWithValue("@PmtType", vehicleSales.PmtType);
                cmd.Parameters.AddWithValue("@City", vehicleSales.City);

                if(string.IsNullOrEmpty(vehicleSales.Email))
                {
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Email", vehicleSales.Email);
                }

                if (string.IsNullOrEmpty(vehicleSales.StreetAdd2))
                {
                    cmd.Parameters.AddWithValue("@StreetAdd2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@StreetAdd2", vehicleSales.StreetAdd2);
                }

                cn.Open();
                cmd.ExecuteNonQuery();
                vehicleSales.SalesID = (int)param.Value;
            }

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSalesPriceUpdate", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleID", vehicleSales.purchasedVehicleID);
                cmd.Parameters.AddWithValue("@SalesPrice", vehicleSales.SalesPrice);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

       

        public List<State> GetStates()
        {
            List<State> states = new List<State>();

            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectStatesAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        
                        currentRow.StateAbbr = dr["StateAbbr"].ToString();

                        states.Add(currentRow);
                    }
                }
            }
            return states;
        }

        public List<pmtType> GetPmtType()
        {
            List<pmtType> pmtTypes = new List<pmtType>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectPmtTypesAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        pmtType currentRow = new pmtType();

                        currentRow.pmtOption = dr["PmtType"].ToString();

                        pmtTypes.Add(currentRow);
                    }
                }
            }
            return pmtTypes;
        }




    }
}
