using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Task0
{
    public partial class list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                SqlConnection sqlCon = null;
                String SqlconString = ConfigurationManager.ConnectionStrings["connectionTask0"].ConnectionString;
                using (sqlCon = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT id,EmpId,Username,Password,isActive,LastModified FROM User1"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = sqlCon;
                            sda.SelectCommand = cmd;
                            /*using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridViewList.DataSource = dt;
                                GridViewList.DataBind();
                            }*/
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);
                                GridViewList.DataSource = ds.Tables[0];
                                GridViewList.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewList.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void btn_EditRecord(object sender, EventArgs e)
        {
            Response.Redirect("AddEdit.aspx?param=");
        }

        protected void btn_AddRecord(object sender, EventArgs e)
        {
            Response.Redirect("AddEdit.aspx");
        }
    }
}