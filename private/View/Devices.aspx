<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Devices.aspx.cs" Inherits="bcms.Devices" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Devices</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
   
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="navBar.html"-->
        <div class="px-5" id="main">
            <h1 class="display-5">Manage Devices <i class="fa fa-laptop" aria-hidden="true"></i></h1>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col" class="auto-style1">User ID</th>
                            <th scope="col" class="auto-style1">Device Type</th>
                            <th scope="col" class="auto-style1">Device Name</th>
                            <th scope="col" class="auto-style1">Login Time</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%if (!devices.Any())
                            {%>
                            <tr>
                                <td>No device information found</td>
                            </tr>

                        <%}else%>
                            <% foreach (var item in devices)
                                {%>
                            <tr>
                            <td><%=item.UserID%></td>
                            <td><%=item.Type%></td>
                            <td><%=item.Name%></td>
                            <td><%=item.StrTime%></td>
                            </tr>
                            <%}%>
                    </tbody>
                </table>
            </div>
        </div>

    </form>
</body>
</html>
