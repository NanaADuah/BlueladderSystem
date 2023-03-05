<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewEquipment.aspx.cs" Inherits="bcms.ViewEquipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Equipment</title>
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
                    <h1 class="display-5">View Equipment</h1>
                </div>
                <a class="btn btn-success float-right" href="Help.aspx?tab=equipment">Help</a>
                <div class="input-group mb-3">
                </div>
                <div class="dropdown-divider"></div>
                <div class="mx-5 my-2">
                </div>
                <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
                <div class="tableView ">
                    <div class="container p-4"> 
                        <%if (currEquip != null)
                            { %>
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">Available</th>
                                    <th scope="col">Cost</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr >
                                    <%if (currEquip.Available == true)
                                        { %>
                                    <td><i class="fa fa-check"></i></td>
                                    <%}
                                        else
                                        { %>
                                    <td><i class="fa fa-times"></i></td>
                                    <%} %>
                                    <td><%=String.Format("R {0}",currEquip.Income.ToString("F2"))%></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="container shadow-sm p-3 rounded">
                        <asp:TextBox class="form-control mb-2" runat="server" ID="tbDetails" Text="" TextMode="MultiLine"></asp:TextBox>
                        <div class="row">
                            <div class="col-md-auto">
                                <asp:PlaceHolder ID="plBarCode" runat="server" Visible="false" />
                                <br />
                                <br />
                            </div>
                            <div class="col-8 w-50 flex-fill">
                                <div class="p-2">
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Equipment Name</span>
                                        </div>
                                        <asp:TextBox runat="server" class="form-control" ID="tbEquipmentName" Text=""></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Manufacturer</span>
                                        </div>
                                        <asp:TextBox runat="server" class="form-control" ID="tbManufacturer" Text=""></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Location</span>
                                        </div>
                                        <asp:TextBox runat="server" class="form-control" ID="tbLocation" Text=""></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">Last modified by</span>
                                        </div>
                                        <asp:TextBox runat="server" class="form-control" ID="tbModified" Text=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <asp:Label Text="" ID="lblQRCode" runat="server"></asp:Label>
                    </div>
                </div>
                <%}
%>
                <%else
                {  %>
                <div>
                    <h2 class="text-center mt-5">Specified equipment not found</h2>
                </div>
                <%}%><div>
                    <a class="btn btn-success m-2" href="Equipment.aspx">GO BACK</a>
                </div>
            </div>
    </form>
</body>
</html>
