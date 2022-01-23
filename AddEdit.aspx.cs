using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Task0
{
	public partial class AddEdit : System.Web.UI.Page
	{
		SqlCommand sqlCmd;
		SqlConnection sqlCon = null;
		String SqlconString = ConfigurationManager.ConnectionStrings["connectionTask0"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				passwordMatch.Visible = false;
				if (Request["id"] != null && Request["id"].ToString() != "")
				{
					int id = Convert.ToInt32(Request["id"]);
					//autofill
					int EmiD = 0;
					string uname = String.Empty;
					int active = 0;
					string location = String.Empty;
					using (sqlCon = new SqlConnection(SqlconString))
					{
						sqlCon.Open();
						sqlCmd = sqlCon.CreateCommand();
						string query = @"SELECT EmpId,Username,isActive,Location FROM User1 WHERE id=@id";
						sqlCmd = new SqlCommand(query, sqlCon);
						sqlCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
						sqlCmd.ExecuteNonQuery();
						using (SqlDataReader reader = sqlCmd.ExecuteReader())
						{
							while (reader.Read())
							{
								//SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
								EmiD = Convert.ToInt32(reader[0].ToString());
								uname = reader[1].ToString();
								active = Convert.ToInt32(reader[2].ToString());
								location = reader[3].ToString();
							}
						}
						AEEmpId.Text = EmiD.ToString();
						AEUsername.Text = uname.ToString();
						AEIsActive.Text = active.ToString();
						AELocation.Text = location.ToString();

					}
				}
				// For Delete no need to fill the form, use request parameter DelId to delete
				else if (Request["DelId"] != null && Request["DelId"].ToString() != "")
				{
					form1.Visible = false;
					int deleteID = Convert.ToInt32(Request["DelId"].ToString());
					using (sqlCon = new SqlConnection(SqlconString))
					{
						sqlCon.Open();
						/*string query = @"DELETE FROM User1 WHERE id='" + Convert.ToInt32(deleteID.ToString()) + "'";
						sqlCmd = new SqlCommand(query, sqlCon);
						sqlCmd.ExecuteNonQuery();*/
						//int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
						sqlCmd = sqlCon.CreateCommand();
						sqlCmd.CommandType = CommandType.StoredProcedure;
						sqlCmd.CommandText = "spDeleteUser";
						sqlCmd.Parameters.AddWithValue("@DelId", deleteID);
						sqlCmd.ExecuteNonQuery();
						Response.Redirect("list.aspx");
					}
					sqlCon.Close();

				}
			}
			catch (Exception ex)
			{ Console.WriteLine(ex.Message); }
		}
		protected void AddEditSubmit_Click(object sender, EventArgs e)
		{
			try
			{
				//int update = 0;
				/*if (Request["id"] != null && Request["id"].ToString() != "")
				{
					int id = Convert.ToInt32(Request["id"].ToString());
					DataSet ds = new DataSet();
					update = 1;
					ds = ObjUser.GetUser(id);
					if (ds != null && ds.Tables[0].Rows.Count > 0)
					{
						AEEmpId.Text = ds.Tables[0].Rows[0]["EmpId"].ToString();
						AEUsername.Text = ds.Tables[0].Rows[0]["Username"].ToString();
						AEPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
						AEIsActive.Text = ds.Tables[0].Rows[0]["isActive"].ToString()
					}
				}*/

				//update
				if (Request["id"] != null && Request["id"].ToString() != "")
				{
					int id = Convert.ToInt32(Request["id"]);
					using (sqlCon = new SqlConnection(SqlconString))
					{
						sqlCon.Open();
						/*string query = @"UPDATE User1 SET EmpId=@empid, Username=@username, Password=@password, isActive=@isactive WHERE id=@id";
						sqlCmd = new SqlCommand(query, sqlCon);
						sqlCmd.Parameters.AddWithValue("@empid", SqlDbType.Int).Value = AEEmpId.Text;
						sqlCmd.Parameters.AddWithValue("@username", AEUsername.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@password", AEPassword.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@isactive", SqlDbType.Int).Value = AEIsActive.Text;
						sqlCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
						sqlCmd.ExecuteNonQuery();*/
						//count = Convert.ToInt32(sqlCmd.ExecuteScalar());
						if (AEPassword.Text == AECPassword.Text)
						{
							sqlCmd = sqlCon.CreateCommand();
							sqlCmd.CommandType = CommandType.StoredProcedure;
							sqlCmd.CommandText = "spUpdateUser";
							sqlCmd.Parameters.AddWithValue("@empid", SqlDbType.Int).Value = AEEmpId.Text;
							sqlCmd.Parameters.AddWithValue("@username", AEUsername.Text.Trim());
							sqlCmd.Parameters.AddWithValue("@password", AEPassword.Text.Trim());
							sqlCmd.Parameters.AddWithValue("@isactive", SqlDbType.Int).Value = AEIsActive.Text;
							sqlCmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
							sqlCmd.ExecuteNonQuery();
							Response.Redirect("list.aspx");
						}
						else
                        {
							passwordMatch.Visible = true;
                        }
					}
					sqlCon.Close();

				}

				//button click event 
				//change queries to sp calls
				//Datasets
				//Add Confirm password
				else
				{
					//insert goes here
					using (sqlCon = new SqlConnection(SqlconString))
					{
						sqlCon.Open();
						/*string query = @"INSERT INTO User1 (EmpId, Username, Password, isActive) VALUES (@empid, @username, @password, @isactive)";
						sqlCmd = new SqlCommand(query, sqlCon);
						sqlCmd.Parameters.AddWithValue("@empid", SqlDbType.Int).Value = AEEmpId.Text;
						sqlCmd.Parameters.AddWithValue("@username", AEUsername.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@password", AEPassword.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@isactive", SqlDbType.Int).Value = AEIsActive.Text;
						sqlCmd.ExecuteNonQuery();*/
						//count = Convert.ToInt32(sqlCmd.ExecuteScalar());
						sqlCmd = sqlCon.CreateCommand();
						sqlCmd.CommandType = CommandType.StoredProcedure;
						sqlCmd.CommandText = "spAddUser";
						sqlCmd.Parameters.AddWithValue("@empid", SqlDbType.Int).Value = AEEmpId.Text;
						sqlCmd.Parameters.AddWithValue("@username", AEUsername.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@password", AEPassword.Text.Trim());
						sqlCmd.Parameters.AddWithValue("@isactive", SqlDbType.Int).Value = AEIsActive.Text;
						sqlCmd.Parameters.AddWithValue("location", AELocation.Text.Trim());
						sqlCmd.ExecuteNonQuery();
						Response.Redirect("list.aspx");
					}
					sqlCon.Close();
				}
				/*else
				{
					//udpate goes here
					Response.Redirect("list.aspx");
				}*/
			}
			catch (ThreadAbortException)
			{ }
			catch (Exception ex)
			{ Console.WriteLine(ex.Message); }
		}
	}
}