using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;

namespace Task0
{
    public partial class userProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string username = Session["username"].ToString();
                int employee_id = 0;
                string password = string.Empty;
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["connectionTask0"].ConnectionString;
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("SELECT EmpId,Password FROM User1 WHERE Username=@username"))
                    {
                        sqlCon.Open();
                        sqlCmd.Parameters.AddWithValue("@username", username);
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.ExecuteNonQuery();
                        using (SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                employee_id = Convert.ToInt32(reader[0].ToString());
                                password = reader[1].ToString();
                            }
                        }

                    }

                }
                lblUserProfileUsername.Text = "Username : " + username;
                lblUserProfileEmpId.Text = "Employee ID : " + employee_id;
                lblUserProfilePassword.Text = "Password: " + password;
            }
            catch (ThreadAbortException)
            { }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
    }
}