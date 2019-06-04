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
                SqlCommand cmd = new SqlCommand("Select * from ProductsTable", con);
                con.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
                // con.Close();
            }
        }

        //private void Add()
        //{
        //    throw new NotImplementedException();
        //}
    }
}