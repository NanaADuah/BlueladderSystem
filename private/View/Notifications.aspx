<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="bcms.Notifications" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests">
    <title>Notifications</title>
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
        <div id="heading" >
            <div class="form-check-inline">
                <h1 class="display-5">Notifications<i class="fa fa-bell" aria-hidden="true"></i></h1>
            </div>
            <a class="btn btn-success float-right" href="Help.aspx">Help</a>
            <div class="dropdown-divider"></div>
        </div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <%if (!notifications.Any())
                            {
                        %>
                        <tr>
                            <th scope="col">Data</th>
                        </tr>
                        <%}
                            else
                            { %>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Time</th>
                            <th scope="col">Sender ID</th>
                            <th scope="col">Notification</th>
                            <th scope="col">Optioon</th>
                        </tr>
                        <%} %>
                    </thead>
                    <tbody>
                        <%if (!notifications.Any())
                            {%>
                        <tr>
                            <td>No recent notifications</td>
                        </tr>

                        <%}
                            else%>
                        <% foreach (var item in notifications)
                            {%>
                        <tr>
                            <td><%=item.NotificationID%></td>
                            <td><%=item.Time.ToString("dd/MM/yyyy HH:mm")%></td>
                            <td><%=String.IsNullOrEmpty(item.SenderID.ToString()) ? "General" : item.SenderID.ToString()%></td>
                            <td><%=String.IsNullOrEmpty(Truncate(item.Title, 20)) ? "Notification" : Truncate(item.Title,20)%></td>
                            <td>
                                 <a class="btn btn-secondary btn-sm" href="ViewNotification.aspx?id=<%=item.NotificationID%>"><i class="fa fa-eye"></i></a>
                                 <a class="btn btn-danger btn-sm" href="DeleteNotification.aspx?id=<%=item.NotificationID%>"><i class="fa fa-trash"></i></a>
                            </td>

                        </tr>
                        <%}%>
                    </tbody>
                </table>
                <%if (role.Equals("Owner") || role.Equals("Admin"))
                    {%>
                <div class="dropdown-divider"></div>
                <div class="container shadow-sm rounded p-2 mb-5">
                <asp:Label ID="lblNoti" runat="server" Text=""></asp:Label>
                    <h5>Send a notification</h5>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text" >Recepient's UserID</span>
                        </div>
                        <asp:TextBox runat="server" class="form-control" ID="tbUserRecepientID" Text="" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text" >Notification Title</span>
                        </div>
                        <asp:TextBox runat="server" class="form-control" ID="tbTitle" Text="" ></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label for="tbInfo">Message</label>
                        <asp:TextBox runat="server" class="form-control" ID="tbInfo" rows="3" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-check-inline">
                        <asp:Button ID="btnSendNoti" class="btn btn-dark" runat="server" Text="Send" OnClick="btnSendNoti_Click"></asp:Button>
                    </div>
                </div>
                <%} %>
            </div>
        </div>
    </form>
</body>
</html>
