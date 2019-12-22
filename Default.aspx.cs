using System;

public partial class _Default : System.Web.UI.Page
{
    string myUsername;
    string myPassword;
    string myToken;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure user is logged in to access other features
        if (Session["username"] != null && Session["token"] != null)
        {
            myUsername = Session["username"].ToString();
            myToken = Session["token"].ToString();

            lblStatus.Text = "You are logged in as " + myUsername;
        }
    }
}
