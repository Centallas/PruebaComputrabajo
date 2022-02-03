using Data_Access_Layer.Repository.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;


namespace Data_Access_Layer.Repository
{
    public class db
    {
        readonly SqlConnection connection;
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }

        public db()
        {
            var configuration = GetConfiguration();
            connection = new SqlConnection(configuration.GetSection("Data")
                .GetSection("ConnectionString").Value);
        }

        public async Task<string> EmployeeOpt(Employee employee)
        {
            string msg = string.Empty;
            await Task.Run(() =>
            {

                try
                { 
                    SqlCommand command = new SqlCommand("Sp_Employee", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                    command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
                    command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@Fax", employee.Fax);
                    command.Parameters.AddWithValue("@TestName", employee.TestName);
                    command.Parameters.AddWithValue("@Lastlogin", employee.LastLogin);
                    command.Parameters.AddWithValue("@Password1", employee.Password);
                    command.Parameters.AddWithValue("@PortalId", employee.PortalId);
                    command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                    command.Parameters.AddWithValue("@StatusId", employee.StatusId);
                    command.Parameters.AddWithValue("@Telephone", employee.Telephone);
                    command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
                    command.Parameters.AddWithValue("@Username", employee.Username);
                    command.Parameters.AddWithValue("@type", employee.type);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    msg = "SUCCESS";


                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            });
            return msg;
        }
        //Get the Record
        public DataSet EmployeeGet(Employee employee, out string msg)
        {
            msg = string.Empty;
            DataSet dataSet = new DataSet();
            try
            {

                SqlCommand command = new SqlCommand("Sp_Employee", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", employee.ID);
                command.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                command.Parameters.AddWithValue("@CreatedOn", employee.CreatedOn);
                command.Parameters.AddWithValue("@DeletedOn", employee.DeletedOn);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Fax", employee.Fax);
                command.Parameters.AddWithValue("@TestName", employee.TestName);
                command.Parameters.AddWithValue("@Lastlogin", employee.LastLogin);
                command.Parameters.AddWithValue("@Password1", employee.Password);
                command.Parameters.AddWithValue("@PortalId", employee.PortalId);
                command.Parameters.AddWithValue("@RoleId", employee.RoleId);
                command.Parameters.AddWithValue("@StatusId", employee.StatusId);
                command.Parameters.AddWithValue("@Telephone", employee.Telephone);
                command.Parameters.AddWithValue("@UpdatedOn", employee.UpdatedOn);
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@type", employee.type);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet);
                msg = "SUCCESS";


            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return dataSet;
        }
    }


}
