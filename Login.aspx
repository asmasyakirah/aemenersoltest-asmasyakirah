<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="Content/Login.css" media="all">
    <title>Login</title>
  </head>
  <body>
    <div class="row justify-content-md-center">
        <div class="col-lg-4 col-md-3"></div>
        <form class="col-lg-4 col-md-6" runat="server">

            <div class="card">
              <div class="card-header">
                <strong>Sign in to your dashboard</strong>
              </div>
              <div class="card-body">
            
                  <div class="form-group">
                      <%--<input type="email" class="form-control" id="exampleInputEmail1" placeholder="Username">--%>
                      <asp:TextBox ID="fldUsername" placeholder="Username" runat="server" CssClass="form-control"></asp:TextBox>        
                  </div>
                  <div class="form-group">
                      <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                      <asp:TextBox ID="fldPassword" placeholder="Password" Type="Password" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>
                  <%--<button type="submit" class="btn btn-primary">SIGN IN</button>--%>
                  <asp:Button ID="btnLogin" Text="SIGN IN" runat="server" CssClass="btn btn-primary" OnClick="BtnLogin_Click" />

              </div>
            </div>
      
        </form>
        <div class="col-lg-4 col-md-3"></div>
    </div>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
  </body>
</html>

<%--<!DOCTYPE html>
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
</html>--%>
