<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="bcms.Backup" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Backups</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="navBar.html"-->
        <div class="px-5" id="main">
            <div class="form-check-inline">
                <h1 class="display-5">Manage Backups</h1>
            </div>
            <asp:Button class="btn btn-primary float-right" ID="btnViewOptions" runat="server"  Text="Backup Options" OnClick="btnViewOptions_Click" />
            <div class="dropdown-divider"></div>
            <asp:Label ID="InfoDisplay" runat="server"></asp:Label>
            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <%if (!backups.Any())
                            {
                                InfoDisplay.Text = "";
                        %>
                        <tr>
                            <th scope="col">Data</th>
                        </tr>
                        <% }
                        else
                        { %>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Date Executed</th>
                            <th scope="col">Type</th>
                            <th scope="col">UserID</th>
                            <th scope="col">File Name</th>
                        </tr>
                            <%} %>
                    </thead>
                    <tbody>
                        <%if (!backups.Any())
                            {%>
                        <tr>
                            <td class="text-center">No database backups found</td>
                        </tr>

                        <%}
                        else%>
                        <% foreach (var item in backups)
                        {%>
                        <tr>
                            <td><%=item.BackupID%></td>
                            <td><%=item.Time.ToString("dd/MM/yyyy HH:mm")%></td>
                            <td><%=item.Type%></td>
                            <td><%=item.UserID%></td>
                            <td><a href="ViewReport?backupid=<%=item.BackupID%>"><%=item.FileName.Substring(15)%></a></td>
                        </tr>
                        <%}%>
                    </tbody>
                </table>

            
            </div>
        </div>


    </form>
</body>
</html>
