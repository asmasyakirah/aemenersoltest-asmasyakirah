<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="cache-control" content="no-cache" />
    <title>Hello</title>

</head>
<body>
    <form id="form1" runat="server">   

        <asp:Label ID="lblHyperlink" runat="server"><b>Go To</b></asp:Label> 
        <br />
        <a id="hyperlinkTest" href="Test.aspx" runat="server">My Test Page</a>
    </form>
</body>
</html>
