using dvdLibrary.Data.Interfaces;
using dvdLibrary.Models.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using dvdLibrary.Models.queries;

namespace dvdLibrary.Data.ADO
{
    public class dvdRepositoryADO : IdvdRepository
    {
        public void delete(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@dvdId", dvdId);
                

                cn.Open();

                cmd.ExecuteNonQuery();


            }
        }

        public dvdRequest GetByDirector(string director)
        {
            dvdRequest dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdSelectDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdDirector", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new dvdRequest();
                        dvd.dvdId = (int)dr["dvdId"];
                        dvd.dvdTitle = dr["dvdTitle"].ToString();
                        dvd.dvdDirector = dr["dvdDirector"].ToString();
                        dvd.dvdRating = dr["dvdRating"].ToString();
                        dvd.dvdReleaseYear = (int)dr["dvdReleaseYear"];
                        dvd.notes = dr["notes"].ToString();
                    }
                }
            }

            return dvd;
        }

        public dvdRequest GetbyId(int dvdId)
        {
            dvdRequest dvd = null;

            using(var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdSelect",cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", dvdId);

                cn.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.Read())
                    {
                        dvd = new dvdRequest();
                        dvd.dvdId = (int)dr["dvdId"];
                        dvd.dvdTitle = dr["dvdTitle"].ToString();
                        dvd.dvdDirector = dr["dvdDirector"].ToString();
                        dvd.dvdRating = dr["dvdRating"].ToString();
                        dvd.dvdReleaseYear = (int)dr["dvdReleaseYear"];
                        dvd.notes = dr["notes"].ToString();
                    }
                }
            }

            return dvd;
        }

        public List<dvdRequest> GetByRating(string rating)
        {
            List<dvdRequest> dvdRequest = new List<dvdRequest>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdSelectRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdRating", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvdRequest currentRow = new dvdRequest();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.dvdTitle = dr["dvdTitle"].ToString();
                        currentRow.dvdDirector = dr["dvdDirector"].ToString();
                        currentRow.dvdRating = dr["dvdRating"].ToString();
                        currentRow.dvdReleaseYear = (int)dr["dvdReleaseYear"];
                        currentRow.notes = dr["notes"].ToString();

                        dvdRequest.Add(currentRow);

                    }
                }
            }
            return dvdRequest;
        }

        public dvdRequest GetByTitle(string title)
        {
            dvdRequest dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdSelectTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdTitle", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new dvdRequest();
                        dvd.dvdId = (int)dr["dvdId"];
                        dvd.dvdTitle = dr["dvdTitle"].ToString();
                        dvd.dvdDirector = dr["dvdDirector"].ToString();
                        dvd.dvdRating = dr["dvdRating"].ToString();
                        dvd.dvdReleaseYear = (int)dr["dvdReleaseYear"];
                        dvd.notes = dr["notes"].ToString();
                    }
                }
            }

            return dvd;
        }

        public List<dvdRequest> GetDvds()
        {
            List<dvdRequest> dvdRequest = new List<dvdRequest>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        dvdRequest currentRow = new dvdRequest();
                        currentRow.dvdId = (int)dr["dvdId"];
                        currentRow.dvdTitle = dr["dvdTitle"].ToString();
                        currentRow.dvdDirector = dr["dvdDirector"].ToString();
                        currentRow.dvdRating = dr["dvdRating"].ToString();
                        currentRow.dvdReleaseYear = (int)dr["dvdReleaseYear"];
                        currentRow.notes = dr["notes"].ToString();

                        dvdRequest.Add(currentRow);

                    }
                }
            }
            return dvdRequest; 
        }

        public void insert(dvdRequest dvd)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@dvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                //cmd.Parameters.AddWithValue("@dvdId",dvd.dvdId);
                cmd.Parameters.AddWithValue("@dvdTitle", dvd.dvdTitle);
                cmd.Parameters.AddWithValue("@dvdDirector", dvd.dvdDirector);
                cmd.Parameters.AddWithValue("@dvdRating", dvd.dvdRating);
                cmd.Parameters.AddWithValue("@dvdReleaseYear", dvd.dvdReleaseYear);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.dvdId = (int)param.Value;
            }
        }

        public void update(dvdRequest dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("dvdUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                

                cmd.Parameters.AddWithValue("@dvdId",dvd.dvdId);
                cmd.Parameters.AddWithValue("@dvdTitle", dvd.dvdTitle);
                cmd.Parameters.AddWithValue("@dvdDirector", dvd.dvdDirector);
                cmd.Parameters.AddWithValue("@dvdRating", dvd.dvdRating);
                cmd.Parameters.AddWithValue("@dvdReleaseYear", dvd.dvdReleaseYear);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                
            }
        }
    }
}
