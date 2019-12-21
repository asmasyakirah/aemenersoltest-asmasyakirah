using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetUser();
    }

    protected void GetUser()
    {
        String qs = "";
        qs = qs + " SELECT *";
        qs = qs + " FROM   tblUser";

        DataTable dt = GetData(qs);
        if ((dt != null) && (dt.Rows.Count > 0))
        {
            DataRow row = dt.Rows[0];

            // Show 1st retrieved data
            lblDesc.Text = "User found. 1st user: " + row["Username"].ToString();
        }
        else
        {
            // Show error message
            lblDesc.Text = "Error retrieving data from db";
        }
    }

    private static DataTable GetData(string query)
    {
        string strConnString = ConfigurationManager.ConnectionStrings["LocalDBConn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = query;
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
