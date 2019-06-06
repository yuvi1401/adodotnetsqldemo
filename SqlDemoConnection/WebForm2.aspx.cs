using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SqlDemoConnection
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           
            //string CS = "data source=.; database = Sample;  integrated security = SSPI";
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductsTable", con);
                con.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();

                //SqlCommand cmd1 = new SqlCommand();
                //cmd1.CommandText = "SELECT COUNT(ProductId) FROM ProductsTable";
                //cmd1.Connection = con;
                con.Close();

                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(ProductId) FROM ProductsTable", con);
                con.Open();
                int TotalRows = (int)cmd1.ExecuteScalar();


                Response.Write("Total Rows = " + TotalRows.ToString() + "<br/>");

                con.Close();

                //SqlCommand cmd2 = new SqlCommand("INSERT into ProductsTable values (6, 'keyboard', 20, 7)", con);
                //con.Open();

                //int TotalRowsAffected = (int)cmd2.ExecuteNonQuery();


                //Response.Write("Total Rows Affected = " + TotalRowsAffected.ToString());
                //con.Close();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = con;
                con.Open();

               // GridView1.DataSource = cmd3.ExecuteReader();
                //GridView1.DataBind();

                // using same command object

                cmd3.CommandText = "DELETE from ProductsTable WHERE ProductId = 6";

               int TotalRowsAffected = (int)cmd3.ExecuteNonQuery();
                Response.Write("Total Rows Deleted = " + TotalRowsAffected.ToString() + "<br/>");

                cmd3.CommandText = "INSERT into ProductsTable values (6, 'keyboard', 20, 7)";

                 TotalRowsAffected = (int)cmd3.ExecuteNonQuery();
                Response.Write("Total Rows Inserted = " + TotalRowsAffected.ToString() + "<br/>");
          

                //GridView1.DataSource = cmd3.ExecuteReader();
                //GridView1.DataBind();


            }
        }

        //private void Add()
        //{
        //    throw new NotImplementedException();
        //}
    }
}