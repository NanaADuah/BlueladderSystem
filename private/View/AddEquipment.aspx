<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEquipment.aspx.cs" Inherits="bcms.AddEquipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Equipment</title>
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
            <h1 class="display-5"><a href="Equipment.aspx"><i class="fa fa-chevron-left" aria-hidden="true"></i></a> Add Equipment <i class="fa fa-wrench" aria-hidden="true"></i></h1>
            </div>
            <a class="btn btn-success float-right" href="Help.aspx">Help</a>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div class="container">
                <div>
                    <div class="container shadow-sm rounded p-2 mb-5">
                        <asp:Label ID="lblNoti" runat="server" Text=""></asp:Label>
                        <h5>Enter details for new equipment</h5>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Equipment name required" ControlToValidate="tbName" ForeColor="Red"></asp:RequiredFieldValidator>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Equipment Name</span>
                            </div>
                            <asp:TextBox runat="server" class="form-control" ID="tbName" Text="" TextMode="SingleLine"></asp:TextBox>
                        </div>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Category required" ControlToValidate="tbCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Category</span>
                            </div>
                            <asp:TextBox runat="server" class="form-control" ID="tbCategory" Text=""></asp:TextBox>
                        </div>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Serial number required" ControlToValidate="tbSerial" ForeColor="Red"></asp:RequiredFieldValidator>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Serial Number</span>
                            </div>
                            <asp:TextBox runat="server" class="form-control" ID="tbSerial" Text=""></asp:TextBox>
                        </div>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Manufacturer required" ControlToValidate="tbManufacturer" ForeColor="Red"></asp:RequiredFieldValidator>
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

                        <div class="form-group">
                            <label for="tbInfo">Details</label>
                            <asp:TextBox runat="server" class="form-control" ID="tbDetails" Rows="2" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="form-check-inline">
                            <asp:Button ID="btnAddEquipment" class="btn btn-dark" runat="server" Text="Add" OnClick="btnAddEquipment_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
