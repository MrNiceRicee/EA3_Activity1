using LoginApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace LoginApp.Services.Business.Data
{
    public class SecurityDAO
    {
        /*        List<UserModel> CurrentUsers = new List<UserModel>();

                Made a Text file, did not realize we were going to implement a datatable! this is awesome :)

                public void getUsers()
                {
                    CurrentUsers.Clear();
                    foreach (var user in System.IO.File.ReadAllText(HostingEnvironment.MapPath(@"~/Services/Business/Data/SavedUsers.txt")).Split('\n'))
                    {
                        if (user.Length >2)
                        {
                            //System.Diagnostics.Debug.WriteLine("user"+user);
                            CurrentUsers.Add(JsonConvert.DeserializeObject<UserModel>(user));
                        }
                    }
                }*/

        string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool FindByUser(UserModel user)
        {
            //assume that it is always false first
            bool success = false;

            //provide the query string
            string queryString = "select * from dbo.users where username = @username and password = @password";

            //create and open the connection with a using block. ensure that the resources will be CLOSED after.
            using(SqlConnection connection = new SqlConnection(connectionString)){
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@USERNAME",System.Data.SqlDbType.VarChar,50).Value = user.Username;
                command.Parameters.Add("@PASSWORD", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    reader.Close();
                }catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return success;
        }

    }
}