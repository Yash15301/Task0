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
    public partial class forgotpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblIncorrectUsername.Visible = false;
            lblPasswordNotMatch.Visible = false;
            lblQuestion.Text = "Security Question: Where are you from? ";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["connectionTask0"].ConnectionString;
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    sqlCon.Open();
                    /*query = "SELECT COUNT(1) FROM User1 FULL OUTER JOIN ForgotPasswordQuestions ON ForgotPasswordQuestions.uid = User1.id AND User1.isActive=1 WHERE Username=@Username AND answer=@Answer";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Username", forgotUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Answer", answer.Text.Trim());*/
                    SqlCommand sqlCmd = sqlCon.CreateCommand();
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = "spForgotPassword";
                    sqlCmd.Parameters.AddWithValue("@Username", forgotUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Answer", answer.Text.Trim());
                    int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCmd.ExecuteNonQuery();
                    if (count < 1)
                    {
                        lblIncorrectUsername.Visible = true;
                    }
                    else
                    {
                        if (forgotPassword.Text.Trim() != ConfirmPassword.Text.Trim())
                        {
                            lblPasswordNotMatch.Visible = true;
                        }

                        
                        {
                            SqlCommand cmd = sqlCon.CreateCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "spUpdateUserPassword";
                            cmd.Parameters.AddWithValue("@Username", forgotUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@NewPassword", forgotPassword.Text.Trim());
                            cmd.ExecuteNonQuery();
                            /*query = "UPDATE User1 SET Password=@NewPassword WHERE Username=@Username";
                            sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.Parameters.AddWithValue("@Username", forgotUsername.Text.Trim());
                            sqlCmd.Parameters.AddWithValue("@NewPassword", forgotPassword.Text.Trim());
                            sqlCmd.ExecuteScalar();
                            Response.Redirect("login.aspx");*/
                        }

                    }
                    sqlCon.Close();
                }
            }
            catch (ThreadAbortException)
            { }

            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }
    }
}