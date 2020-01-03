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
    private const string URLAEMEnersol = "http://test-demo.aem-enersol.com/api/PlatformWell/GetPlatformWellActual";
    private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDBConn"].ConnectionString);

    string myUsername;
    string myToken;
    Platform[] platform;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure user is logged in to access other features
        if (Session["username"] != null && Session["token"] != null)
        {
            //myUsername = Session["username"].ToString();
            //myToken = Session["token"].ToString();

            //lblUser.Text = "You are logged in as <b>" + myUsername + "</b> <a id=\"hyperlinkLogout\" href=\"Login.aspx\">Logout</a>";
            
            // Redirect to Dashboard page
            Response.Redirect("Dashboard.aspx", true);
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
        //lblStatus.Text = "Sync button clicked";

        // Get Platform and Well data from API
        GetPlatformAndWell();
    }

    private async void GetPlatformAndWell()
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
            platform = Newtonsoft.Json.JsonConvert.DeserializeObject<Platform[]>(responseBody);

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

            // Show success message
            //lblStatus.Text += "<br>SUCCESS";

            SyncPlatformAndWell();
        }
        else
        {
            // Show failed message
            lblStatus.Text = "Synchronization from API to localDB failed";
            //lblStatus.Text = "FAILED<br>"+response.ToString();
        }
    }

    private void SyncPlatformAndWell()
    {
        DateTime now = DateTime.Now;

        SyncPlatform();
        SyncWell();

        lblStatus.Text += "<br>Synchronization from API to localDB sucessfully done<br>on " + now.ToString("dd/MM/yyyy hh:mm tt");
    }

    private void SyncPlatform()
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand commandClear = new SqlCommand("DELETE FROM Platform", con);
        commandClear.ExecuteNonQuery();

        string commandInsert = "";
        int platformCount = platform.Length;
        foreach (Platform p in platform)
        {
            // Add to command insert
            commandInsert += "(@Id" + p.Id + ", "
                  + "@UniqueName" + p.Id + ", "
                  + "@Latitude" + p.Id + ", "
                  + "@Longitude" + p.Id + ", "
                  + "@CreatedAt" + p.Id + ", "
                  + "@UpdatedAt" + p.Id + ")";

            platformCount--;
            if(platformCount!=0)
            {
                commandInsert += ",";
            }
        }

        SqlCommand command = new SqlCommand("INSERT INTO Platform ([Id],[UniqueName],[Latitude],[Longitude],[CreatedAt],[UpdatedAt]) VALUES "
                  + commandInsert, con);

        foreach (Platform p in platform)
        {
            command.Parameters.AddWithValue("@Id" + p.Id, p.Id);
            command.Parameters.AddWithValue("@UniqueName" + p.Id, p.UniqueName != null ? p.UniqueName : string.Empty);
            command.Parameters.AddWithValue("@Latitude" + p.Id, p.Latitude != null ? p.Latitude : string.Empty);
            command.Parameters.AddWithValue("@Longitude" + p.Id, p.Longitude != null ? p.Longitude : string.Empty);
            command.Parameters.AddWithValue("@CreatedAt" + p.Id, p.CreatedAt != null ? p.CreatedAt : string.Empty);
            command.Parameters.AddWithValue("@UpdatedAt" + p.Id, p.UpdatedAt != null ? p.UpdatedAt : string.Empty);
        }

        command.ExecuteNonQuery();
        con.Close();
    }

    private void SyncWell()
    {
        if (con.State == System.Data.ConnectionState.Closed)
        { con.Open(); }

        SqlCommand commandClear = new SqlCommand("DELETE FROM Well", con);
        commandClear.ExecuteNonQuery();

        foreach (Platform p in platform)
        {
            string commandInsert = "";
            if (p.Well != null && p.Well.Length > 0)
            {
                int wellCount = p.Well.Length;
                foreach (Well w in p.Well)
                {
                    // Add to command insert
                    commandInsert += "(@Id" + w.Id + ", "
                      + "@PlatformId" + w.Id + ", "
                      + "@UniqueName" + w.Id + ", "
                      + "@Latitude" + w.Id + ", "
                      + "@Longitude" + w.Id + ", "
                      + "@CreatedAt" + w.Id + ", "
                      + "@UpdatedAt" + w.Id + ")";

                    wellCount--;
                    if (wellCount != 0)
                    {
                        commandInsert += ",";
                    }
                }

                SqlCommand command = new SqlCommand("INSERT INTO Well (Id,PlatformId,UniqueName,Latitude,Longitude,CreatedAt,UpdatedAt) VALUES "
                  + commandInsert, con);

                foreach (Well w in p.Well)
                {
                    command.Parameters.AddWithValue("@Id" + w.Id, w.Id);
                    command.Parameters.AddWithValue("@PlatformId" + w.Id, w.PlatformId);
                    command.Parameters.AddWithValue("@UniqueName" + w.Id, w.UniqueName != null ? w.UniqueName : string.Empty);
                    command.Parameters.AddWithValue("@Latitude" + w.Id, w.Latitude != null ? w.Latitude : string.Empty);
                    command.Parameters.AddWithValue("@Longitude" + w.Id, w.Longitude != null ? w.Longitude : string.Empty);
                    command.Parameters.AddWithValue("@CreatedAt" + w.Id, w.CreatedAt != null ? w.CreatedAt : string.Empty);
                    command.Parameters.AddWithValue("@UpdatedAt" + w.Id, w.UpdatedAt != null ? w.UpdatedAt : string.Empty);
                }

                command.ExecuteNonQuery();
            }
        }        
        con.Close();
    }
}
