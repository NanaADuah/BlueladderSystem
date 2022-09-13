<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewNotification.aspx.cs" Inherits="bcms.ViewNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <title>Notification</title>
</head>
<body>
    <form id="form1" runat="server">
            <!--#include file="navBar.html"-->
            <div class="px-5" id="main">
                <div class="form-check-inline">
                    <h3 class="display-6">Notification</h3>
                </div>
                <a class="btn btn-success float-right" href="Help.aspx">Help</a>
            </div>
        <div id="tableView">
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div>
                <%if (!singleNotification.Any())
                    {%>

                <div class="dropdown-divider"></div>
                <div class="table text-center mt-5 ">
                    <h2 class="font-weight-bold text-danger">Notification was deleted<i class="fa fa-file"></i></h2>

                    <h4 class="font-weight-light">Return back to notifications</h4>
                </div>
                <%}
                    else
                    {
                        foreach (var item in singleNotification)
                        { %>
                <div>
                    <div class="jumbotron p-2">
                        <h1 class="display-5"><%=item.Title %></h1>
                        <p class="lead">
                            Sent by 
                                <%=valueUser.getRole(item.SenderID).ToLower() %>
                        </p>
                        <hr class="my-4"/>
                        <p class="text-break"><%=item.Message %></p>
                        <a class="btn btn-primary btn-sm " href="Notifications.aspx" role="button">Clear</a>
                    </div>
                </div>
                <%} %>
                <%} %>
            </div>
        <a href="Notifications.aspx" class="btn btn-success">GO BACK</a>
        </div>


    </form>
</body>
</html>
