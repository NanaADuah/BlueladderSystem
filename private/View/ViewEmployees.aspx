<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="bcms.ViewEmployees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Employees</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/ViewEmployees.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="heading">
        <!--#include file="navBar.html"-->
             <h1 class="display-5 mx-5">View Employees</h1>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
        </div>
        <div class="px-5" id="main">
            
            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col"></th>
                            <th scope="col">#</th>
                            <th scope="col">User ID</th>
                            <th scope="col">Name</th>
                            <th scope="col">Surname</th>
                            <th scope="col">Gender</th>
                            <th scope="col">BirthDate</th>
                            <th scope="col">Job Title</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%if (!employees.Any())
                            {%>
                            <tr>
                                <td>No employee information found</td>
                            </tr>

                        <%}else%>
                            <% foreach (var item in employees)
                                {%>
                            <tr>
                            <td> <img class="empImg" src="../../public/includes/profile/placeholder.png"</td>
                            <td><%=item.EmployeeID%></td>
                            <td><%=item.UserID%></td>
                            <td><%=item.Name%></td>
                            <td><%=item.Surname%></td>
                            <td><%=item.Gender%></td>
                            <td><%=item.Birthdate%></td>
                            <td><%=item.JobStatus%></td>
                            </tr>
                            <%}%>
                    </tbody>
                </table>
            </div>
        </div>

        </div>
    </form>
</body>
</html>
