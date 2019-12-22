using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Security;

public class Employee
{
    public int Id { get; set; }
    public string Employee_Name { get; set; }
}

public partial class _Default : System.Web.UI.Page
{
    private static HttpClient httpClient = new HttpClient();
    private const string URLAEMEnersol = "http://test-demo.aem-enersol.com/api/Account/Login";

    string myUsername;
    string myPassword;
    string myToken;

    protected void Page_Load(object sender, EventArgs e)
    {
        // On first time load, assign username & password as null
        if(!this.IsPostBack)
        {
            myUsername = null;
            myPassword = null;
            myToken = null;
            Session["username"] = myUsername;
            Session["token"] = myToken;
        }
    }

    private async void LoginUser()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, URLAEMEnersol);
        request.Headers.Accept.Clear();
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Content = new StringContent("{'username': '" + myUsername + "', 'password': '" + myPassword + "'}", Encoding.UTF8, "application/json");
        //var responseTask = await httpClient.SendAsync(request, CancellationToken.None);
        var responseTask = httpClient.SendAsync(request, CancellationToken.None);
        responseTask.Wait();

        var response = responseTask.Result;

        if (response.IsSuccessStatusCode)
        {
            // Get response body
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize responsebody JSON in string to Employee (array) object
            myToken = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(responseBody);

            // Store username and token in Session
            Session["username"] = myUsername;
            Session["token"] = myToken;

            // Show success message
            lblStatus.Text = "Successfully logged in!";

            // Redirect to Home page
            FormsAuthentication.RedirectFromLoginPage(myUsername, true);
        }
        else
        {
            // Show failed message
            lblStatus.Text = "Wrong Username/Password";
        }
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        myUsername = fldUsername.Text;
        myPassword = fldPassword.Text;

        // Check if field is empty
        if(myUsername==null||myPassword==null)
        {
            lblStatus.Text = "Please key-in both Username/Password fields";
        }
        else
        {
            LoginUser();
        }
    }
}
