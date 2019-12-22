using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;

public class Employee
{
    public int Id { get; set; }
    public string Employee_Name { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
    private static HttpClient httpClient = new HttpClient();
    private const string URL = "http://dummy.restapiexample.com/api/v1/";

    protected void Page_Load(object sender, EventArgs e)
    {
        //GetUser();

        if(!this.IsPostBack)
        {
            // Connection start
            lblDesc.Text = "Connection start";

            // Call GET from API
            CallAPIGet1();
        }
    }

    private async void CallAPIGet1()
    {
        // Define base url
        //httpClient.BaseAddress = new Uri(URL);
        //HTTP GET
        var responseTask = httpClient.GetAsync(URL+"employees");
        responseTask.Wait();

        var response = responseTask.Result;

        if (response.IsSuccessStatusCode)
        {
            // Show success message
            lblDesc.Text += "<br>SUCCESS";

            // Show all response body
            string responseBody = await response.Content.ReadAsStringAsync();
            lblDesc.Text += "<br>" + responseBody;

            // Deserialize responsebody JSON in string to Employee (array) object
            Employee[] employee = Newtonsoft.Json.JsonConvert.DeserializeObject<Employee[]>(responseBody);
            
            // Show all each employee's name in response body
            foreach (var e in employee)
            {
                lblDesc.Text += "<br>" + e.Employee_Name;
            }
        }
        else
        {
            // Show failed message
            lblDesc.Text += "<br>FAIL";
        }

        // Show all results
        lblDesc.Text += "<br>" + response.ToString();

        // Connection ends
        lblDesc.Text += "<br>Connections end";
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
