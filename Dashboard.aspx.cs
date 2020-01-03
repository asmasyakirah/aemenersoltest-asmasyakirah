using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Security;
using System.Web.UI.WebControls;

public class Dashboard
{
    public bool success { get; set; }
    public Chart[] chartDonut { get; set; }
    public Chart[] chartBar { get; set; }
    public Table[] tableUsers { get; set; }
}

public class Chart
{
    public string name { get; set; }
    public string value { get; set; }
}
public class Table
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string userName { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
    private static HttpClient httpClient = new HttpClient();
    private const string URLAEMEnersol = "http://test-demo.aem-enersol.com/api/dashboard";
    private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConn"].ConnectionString);

    string myUsername;
    string myToken;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure user is logged in to access other features
        if (Session["username"] != null && Session["token"] != null)
        {
            myUsername = Session["username"].ToString();
            myToken = Session["token"].ToString();

            if (!this.IsPostBack)
            {
                GetDashboard();
            }
        }
        // Else, redirect to Login page
        else
        {
            // Redirect to Login page
            Response.Redirect("Login.aspx", true);
        }
    }

    private async void GetDashboard()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, URLAEMEnersol);
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", myToken);
        var responseTask = httpClient.SendAsync(request, CancellationToken.None);
        responseTask.Wait();

        var response = responseTask.Result;

        if (response.IsSuccessStatusCode)
        {
            // Get response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize responsebody JSON in string to Employee (array) object
            Dashboard dashboard = Newtonsoft.Json.JsonConvert.DeserializeObject<Dashboard>(responseBody);

            if (dashboard.success == true)
            {
                // Show success message
                //lblStatus.Text += "<br>SUCCESS" + dashboard.tableUsers.Length;

                ////Building an HTML string.
                //StringBuilder html1 = new StringBuilder();

                //int no1 = 1;
                //foreach (Chart c1 in dashboard.chartDonut)
                //{
                //    html1.Append("<tr>" +
                //        "<th scope=\"row\">" + no1 + "</th>" +
                //        "<td>" + c1.name + "</td>" +
                //        "<td>" + c1.value + "</td>" +
                //        "<td></td>" +
                //        "</tr>");
                //    //phTable.Controls.Add(new Literal { Text = html.ToString() });
                //    chartDonutScript.InnerHtml = html1.ToString();
                //    no1++;
                //}

                ////Building an HTML string.
                //StringBuilder html2 = new StringBuilder();

                //int no2 = 1;
                //foreach (Chart c2 in dashboard.chartBar)
                //{
                //    html2.Append("<tr>" +
                //        "<th scope=\"row\">" + no2 + "</th>" +
                //        "<td>" + c2.name + "</td>" +
                //        "<td>" + c2.value + "</td>" +
                //        "<td></td>" +
                //        "</tr>");
                //    //phTable.Controls.Add(new Literal { Text = html.ToString() });
                //    chartBarScript.InnerHtml = html2.ToString();
                //    no2++;
                //}

                //Building an HTML string.
                StringBuilder html3 = new StringBuilder();

                int no3 = 1;
                foreach (Table t in dashboard.tableUsers)
                {
                    html3.Append("<tr>" +
                        "<th scope=\"row\">" + no3 + "</th>" +
                        "<td>" + t.firstName + "</td>" +
                        "<td>" + t.lastName + "</td>" +
                        "<td>" + t.userName + "</td>" +
                        "</tr>");
                    //phTable.Controls.Add(new Literal { Text = html.ToString() });
                    tblUser.InnerHtml = html3.ToString();
                    no3++;
                    //}
                }
            }
            else
            {
                // Show success message
                //lblStatus.Text += "<br>ERROR";
            }

            //foreach (Platform p in platform)
            //{
            //    lblStatus.Text += "<br>" + p.UniqueName;

            //    if (p.Well != null && p.Well.Length > 0)
            //    {
            //        foreach (Well w in p.Well)
            //        {
            //            lblStatus.Text += "<br>   " + w.UniqueName;
            //        }
            //    }
            //}
        }
        else
        {
            // Show failed message
            //lblStatus.Text = "Synchronization from API to localDB failed";
            //lblStatus.Text = "FAILED<br>"+response.ToString();
        }
    }
}
