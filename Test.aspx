<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="cache-control" content="no-cache" />
    <title>Test</title>

</head>
<body>
    <form id="form1" runat="server">   
        <a id="hyperlinkHome" href="Default.aspx" runat="server"><b>< Go back</b></a>
        <br />
        <br />
        <asp:Label ID="lblDescTitle" runat="server"><b>Test Report</b></asp:Label>    
        <br />  
        <asp:Label ID="lblDesc" runat="server"></asp:Label>      
    </form>
</body>
</html>
