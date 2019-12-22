using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Security;

public class Platform
{
    public int Id { get; set; }
    public string UniqueName { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public Well[] Well { get; set; }
}

public class Well
{
    public int Id { get; set; }
    public string PlatformId { get; set; }
    public string UniqueName { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
    private static HttpClient httpClient = new HttpClient();
    private const string URLAEMEnersol = "http://test-demo.aem-enersol.com/api/PlatformWell/GetPlatformWellDummy";

    string myUsername;
    string myToken;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure user is logged in to access other features
        if (Session["username"] != null && Session["token"] != null)
        {
            myUsername = Session["username"].ToString();
            myToken = Session["token"].ToString();

            lblUser.Text = "You are logged in as <b>" + myUsername + "</b> <a id=\"hyperlinkLogout\" href=\"Login.aspx\">Logout</a>";
        }
        // Else, redirect to Login page
        else
        {
            // Redirect to Login page
            Response.Redirect("Login.aspx", true);
        }
    }

    protected void BtnSync_Click(object sender, EventArgs e)
    {
        lblStatus.Text = "Sync button clicked";

        SyncData();
    }

    private async void SyncData()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, URLAEMEnersol);
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", myToken);
        //request.Content = new StringContent("{'username': '" + myUsername + "', 'password': '" + myPassword + "'}", Encoding.UTF8, "application/json");
        //var responseTask = await httpClient.SendAsync(request, CancellationToken.None);
        var responseTask = httpClient.SendAsync(request, CancellationToken.None);
        responseTask.Wait();

        var response = responseTask.Result;

        if (response.IsSuccessStatusCode)
        {
            // Get response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize responsebody JSON in string to Employee (array) object
            Platform[] platform = Newtonsoft.Json.JsonConvert.DeserializeObject<Platform[]>(responseBody);
            
            foreach(Platform p in platform)
            {
                lblStatus.Text += "<br>" + p.UniqueName;

                if(p.Well!=null&&p.Well.Length>0)
                {
                    foreach (Well w in p.Well)
                    {
                        lblStatus.Text += "<br>   " + w.UniqueName;
                    }
                }
            }

            // Show success message
            lblStatus.Text += "<br>SUCCESS";
        }
        else
        {
            // Show failed message
            lblStatus.Text = "FAILED<br>"+response.ToString();
        }
    }
}
