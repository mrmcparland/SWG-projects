using GuildCars.Data2.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data2.ADO
{
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public void delete(int specialID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialDelete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SpecialID", specialID);

                cn.Open();

                cmd.ExecuteNonQuery();


            }
        }

        public List<Specials> GetAll()
        {
            List<Specials> specials = new List<Specials>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Specials currentRow = new Specials();
                        currentRow.SpecialID = (int)dr["SpecialId"];
                        currentRow.SpecialTitle = dr["SpecialTitle"].ToString();
                        currentRow.SpecialDescription = dr["SpecialDescription"].ToString();

                        specials.Add(currentRow);


                    }
                }
            }
            return specials;
        }
        public void insert(Specials specials)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SpecialId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SpecialTitle", specials.SpecialTitle);
                cmd.Parameters.AddWithValue("@SpecialDescription", specials.SpecialDescription);
               
                cn.Open();

                cmd.ExecuteNonQuery();

                specials.SpecialID = (int)param.Value;
            }
        }
    }
}
