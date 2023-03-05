﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="bcms.ViewAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/ViewEmployees.css" />
    <title>View All</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="display-5 mx-5">
                <div>
                    <h1 class=""><a href="ManageUsers.aspx"><i class="fa fa-chevron-left" aria-hidden="true"></i></a> View System Users
                    </h1>
                </div>
                <div clas="col form-inline">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text" id="basic-addon1">@</span>
                        </div>
                        <asp:TextBox ID="lblFilter" runat="server" class="form-control" placeholder="User ID" aria-label="Role" aria-describedby="basic-addon1" />
                        <asp:Button runat="server" ID="btnSearch" Text="SEARCH" class="btn btn-secondary rounded-0" OnClick="btnSearch_Click"/>
                    </div>
                </div>
                <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            </div>
        </div>
        <div class="px-5" id="main">

            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <%if (!users.Any())
                            {                        %>
                        <tr>
                            <th scope="col">
                                Search
                            </th>
                        </tr>
                         <%}
                            else { %>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">User ID</th>
                            <th scope="col">Role</th>
                        </tr>
                        <%} %>
                    </thead>
                    <tbody>
                        <%if (!users.Any())
                            {
                                %>
                        <tr>
                            <td class="text-center">No matching employee information found</td>
                        </tr>

                        <%}
                            else {
                                int count = 0;%>
                        <% foreach (var item in users)
                            {
                                count++;
                                    %>
                        <tr>
                            <td><%=count %></td>
                            <td><%=item.UserID%></td>
                            <td><%=item.Role%></td>
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
