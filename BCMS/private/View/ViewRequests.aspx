<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRequests.aspx.cs" Inherits="bcms.ViewRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Requests</title>
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
        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="px-5" id="main">
                <div class="form-check-inline">
                    <h1 class="display-5">View Equipment Requests</h1>
                </div>
                <a class="btn btn-success float-right" href="Help.aspx">Help</a>
                <div class="input-group mb-3">
                </div>
                <div class="dropdown-divider"></div>
                <div class="mx-5 my-2">
                </div>
                <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
                <div class="tableView mx-5">
                    <%if(!request.Any()){ %>
                    <table class="table table-hover text-center">
                        <thead>
                            <tr>
                                <th scope="col">Data</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>No equipment requests found for you</td>
                            </tr>
                        </tbody>
                    </table>
                    <%} else { %>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                 <th scope="col">Equipment Location</th>
                                 <th scope="col">Equipment ID</th>
                                 <th scope="col">Time</th>
                                 <th scope="col" class="text-center">Options</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <%foreach (var item in request)
                                    { %>
                                    <td><%=item.LocationID%></td>
                                    <td><%=item.EquipmentID%></td>
                                    <td><%=item.StrTime%></td>
                                    <td class="text-center "><a class="btn badge btn-danger" href="RemoveRequest.aspx?id=<%=item.EquipmentID%>"><i class="fa fa-trash"></i></a></td>
                                <%} %>
                            </tr>
                        </tbody>
                    </table>
                    <%}%>
                </div>
                <div>
                    <a class="btn btn-success m-2" href="ManageEquipment.aspx">GO BACK</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
