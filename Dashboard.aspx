<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="_Default" %>

<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <link rel="stylesheet" href="Content/Dashboard.css" media="all">
    <title>Login</title>
  </head>
  <body>
      
      <nav class="navbar navbar-dark bg-dark justify-content-between">
        <a class="navbar-brand">Dashboard</a>
        <form class="form-inline">
            <a id="hyperlinkLogout" href="Login.aspx">Sign Out</a>
        </form>
    </nav>

    <div class="block">
        <div class="row" style="padding: 20px">
            <h3 class="col-12">Overview</h3>
            <div class="row col-12">
                <div class="col-6">
                    <div class="card">
                      <div class="card-header">
                        Card Title
                      </div>
                      <div class="card-body">            
                      </div>
                    </div>
                </div>
                <div class="col-6">
                    <div class="card">
                      <div class="card-header">
                        Card Title
                      </div>
                      <div class="card-body">            
                      </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" style="padding: 20px">
            <h3 class="col-12">User List</h3>
            <div class="row col-12">
                <div class="col-12">
                        <table class="table table-bordered">
                          <thead>
                            <tr>
                              <th scope="col">#</th>
                              <th scope="col">First</th>
                              <th scope="col">Last</th>
                              <th scope="col">Handle</th>
                            </tr>
                          </thead>
                          <tbody id="tblUser" runat="server">
                            <asp:PlaceHolder ID="phTable" runat="server"></asp:PlaceHolder>
                            <%--<tr>
                              <th scope="row">1</th>
                              <td>Mark</td>
                              <td>Otto</td>
                              <td>@mdo</td>
                            </tr>
                            <tr>
                              <th scope="row">2</th>
                              <td>Jacob</td>
                              <td>Thornton</td>
                              <td>@fat</td>
                            </tr>
                            <tr>
                              <th scope="row">3</th>
                              <td>Larry</td>
                              <td>the Bird</td>
                              <td>@twitter</td>
                            </tr>--%>
                          </tbody>
                        </table>
                </div>
            </div>
        </div>
    </div>
      
    <%--<asp:Label ID="lblStatus" runat="server" CssClass="bg-yellow"></asp:Label>--%>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    <!-- Highcharts -->
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script src="https://code.highcharts.com/modules/export-data.js"></script>

  </body>
</html>