<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="cache-control" content="no-cache" />
    <title>Home</title>

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
    <form id="form1" runat="server">   

        <%--<asp:Label ID="lblHyperlink" runat="server"><b>Go To</b></asp:Label> 
        <br />
        <a id="hyperlinkLogin" href="Login.aspx" runat="server">Login</a>
        <br />
        <a id="hyperlinkTest" href="Test.aspx" runat="server">My Test Page</a>
        <br />
        <br />--%>

        <asp:Label ID="lblUser" runat="server"></asp:Label> 
        <br />
        <br />
        <br />
        <br />
        <div style="text-align: center;">

            <asp:Button ID="btnSync" Text="Synchronize" runat="server" CssClass="width-200" OnClick="BtnSync_Click" />
            <br />
            <br />
            <asp:Label ID="lblStatus" runat="server" CssClass="bg-yellow"></asp:Label>
        
        </div>

    </form>
</body>
</html>
