using GuildCars.Data2.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data2.ADO
{
    public class ContactsRepositoryADO : IContactsRepository
    {
        public void addContact( ContactAdd contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactId", System.Data.SqlDbType.Int);
                param.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ContactName", contact.ContactName);
                //cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                cmd.Parameters.AddWithValue("@ContactMessage", contact.ContactMessage);
                //cmd.Parameters.AddWithValue("@ContactPhoneNumber", contact.ContactPhoneNumber);

                if (string.IsNullOrEmpty(contact.ContactEmail))
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactEmail", contact.ContactEmail);
                }

                if (string.IsNullOrEmpty(contact.ContactPhoneNumber))
                {
                    cmd.Parameters.AddWithValue("@ContactPhoneNumber", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ContactPhoneNumber", contact.ContactPhoneNumber);
                }


                cn.Open();

                cmd.ExecuteNonQuery();

                //contact.ContactID = (int)param.Value;
            }
        }
    }
}
