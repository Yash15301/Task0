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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["connectionTask0"].ConnectionString;
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    /*string query = "SELECT COUNT(1) FROM User1 WHERE Username=@Username AND Password=@Password AND isActive=1";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());*/
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "spGetUser";
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        Session["username"] = txtUsername.Text.Trim();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        lblErrorMessage.Visible = true;
                    }
                }
                sqlCon.Close();
            }

            catch (ThreadAbortException)
            { }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }


        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("forgotpass.aspx");
        }
    }
}