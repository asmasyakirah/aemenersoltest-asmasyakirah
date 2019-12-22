<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="cache-control" content="no-cache" />
    <title>Login</title>

    <style>
        .width-200
        {
            width: 200px;
        }

        .bg-yellow
        {
            background: yellow;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" style="text-align: center;">   

        <img src="https://www.aemenersol.com/wp-content/uploads/2019/07/TAGLINE_LOGO-14.png" style="max-width: 300px;" />
        <br />
        <asp:Label runat="server">
            Please login first to access Platform & Well Sync feature
        </asp:Label>    
        <br />  
        <asp:Label ID="lblDesc" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="fldUsername" placeholder="Username" runat="server" CssClass="width-200"></asp:TextBox>
        <br />
        <asp:TextBox ID="fldPassword" placeholder="Password" Type="Password" runat="server" CssClass="width-200"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" Text="Login" runat="server" CssClass="width-200" OnClick="BtnLogin_Click" />
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" CssClass="bg-yellow"></asp:Label>

    </form>
</body>
</html>
