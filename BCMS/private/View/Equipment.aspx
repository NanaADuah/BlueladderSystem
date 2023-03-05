<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipment.aspx.cs" Inherits="bcms.Equipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Equipment</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/ViewAll.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/dashboard.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="px-5" id="main">
                <div class="form-check-inline">
                <h1 class="display-5"><a href="ManageEquipment.aspx" ><i class="fa fa-chevron-left"></i><a> Equipment Inventory</h1>
                </div>
                <a class="btn btn-success float-right" href="Help.aspx?tab=equipment">Help</a>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i aria-hidden="true" class="fa fa-search"></i></button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="equipment?filter=category">Category</a>
                            <a class="dropdown-item" href="equipment?filter=equipmentname">Name</a>
                            <a class="dropdown-item" href="equipment?filter=manufacturer">Manufacturer</a>
                            <a class="dropdown-item" href="equipment?filter=userid">UserID</a>
                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="tbSearch" class="form-control" aria-label="Search" placeholder="Search equipment database"/>
                    <asp:Button runat="server" ID="btnSearch" Text="SEARCH" class="btn btn-secondary rounded-0" OnClick="btnSearch_Click"/>
                </div>
            <div class="dropdown-divider"></div>
            </div>
            <div class="mx-5 my-2">
                <asp:Button runat="server" id="btnNewEquip" Text="Add New Equipment" class="btn btn-primary" OnClick="btnNewEquip_Click"></asp:Button>
                <asp:Button runat="server" id="btnDetials" Text="Add notes" class="btn btn-info mx-2" OnClick="btnDetials_Click"></asp:Button>
                <asp:Button runat="server" id="btnRequest" Text="Request for equipment return" class="btn btn-secondary float" OnClick="btnRequest_Click"></asp:Button>
                <asp:Button runat="server" id="btnReturn" Text="Return Equipment" class="btn btn-dark float-right" OnClick="btnReturn_Click1"></asp:Button>
                <asp:Button runat="server" id="btnCheckOuut" Text="Checkout Equipment" class="btn btn-success float-right mx-2" OnClick="btnCheckOuut_Click" ></asp:Button>
            </div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        <div id="tableView">
            <table class="table table-hover">
                <thead>
                    <%if (!equipment.Any())
                        {%>
                    <tr>
                    <th scope="col">Equipment Data</th></tr>
                    <%}
                        else
                        { %>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Category</th>
                        <th scope="col">EquipmentName</th>
                        <th scope="col">Manufacturer</th>
                        <th scope="col">SerialNumber</th>
                        <th scope="col">Modified by</th>
                        <th scope="col" class="text-center">Available</th>
                        <th scope="col"></th>
                    </tr>
                    <%}%>
                </thead>
                <tbody>
                    <%if (!equipment.Any())
                        {%>
                    <tr>
                        <td class="text-center">No equipment information found</td>
                    </tr>

                    <%}
                        else%>
                    <% foreach (var item in equipment)
                        {
                         %>
                    <tr>
                        <td><%=item.EquipmentID%></td>
                        <td><%=item.Category%></td>
                        <td><%=item.EquipmentName%></td>
                        <td><%=item.Manufacturer%></td>
                        <td><%=item.SerialNumber%></td>
                        <td><a class="text-decoration-none " href="profile.aspx?id=<%=item.UserID %>"><%=item.UserID%></a></td>
                        <%if(item.Available == true ) { %>
                                <td class="text-center"><i class="fa fa-check"></i></td>
                            <%}else 
                                { %>
                                <td class="text-center"><i class="fa fa-times"></i></td>
                            <%} %>
                        <td><a class="btn btn-primary badge" href="ViewEquipment.aspx?id=<%=item.EquipmentID%>">View</a></td>
                    </tr>
                    <%}%>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
