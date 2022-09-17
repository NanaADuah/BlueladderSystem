<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataLogs.aspx.cs" Inherits="bcms.DataLogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Logs</title>
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
        <!--#include file="navBar.html"-->
    <form id="form1" runat="server">
        <div class="px-5" id="main">
            <div class="form-check-inline">

            <h1 class="display-5">Manage Data Logs <i class="fa fa-laptop" aria-hidden="true"></i></h1>
            </div>
            <asp:Button Text="EXPORT" runat="server" id="btnExport" class="btn btn-success float-right"/>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <%if (!datalogs.Any())
                            {%>
                            <tr>
                                <th>Data</th>
                            </tr>

                        <%}
                        else { %>
                        <tr>
                            <th scope="col" class="auto-style1">#</th>
                            <th scope="col" class="auto-style1">User ID</th>
                            <th scope="col" class="auto-style1">Action</th>
                            <th scope="col" class="auto-style1">Login Time</th>
                        </tr>
                        <%}%>
                    </thead>
                    <tbody>
                        <%if (!datalogs.Any())
                            {%>
                            <tr>
                                <td>No data logs information found</td>
                            </tr>

                        <%}else
                            {
                                int count = 0;%>
                            <% foreach (var item in datalogs)
                                {
                                    count++;%>
                            <tr>
                            <td><%=count%></td>
                            <td><%=item.UserID%></td>
                            <td><%=item.Action%></td>
                            <td><%=item.StrTime%></td>
                            </tr>
                            <%}%>
                            <%}%>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
