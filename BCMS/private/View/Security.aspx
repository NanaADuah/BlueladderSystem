<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Security.aspx.cs" Inherits="bcms.Security" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Security</title>
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
        <!--#include file="navBar.html"-->
        <div class="px-5" id="main">
            <h1 class="display-5">Security Settings <i class="fa fa-lock" aria-hidden="true"></i></h1>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div id="tableView">
                <div class="w-100 rounded shadow-sm p-2 m-2">
                    <div>
                        <h4>Update User Password</h4>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="p1">User ID</span>
                            </div>
                            <asp:TextBox runat="server" class="form-control" ID="tbUserID" />
                        </div>

                    </div>
                    <div>
                        <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text" id="p2">Password</span>
                            </div>
                            <asp:TextBox runat="server" class="form-control" ID="tbPassword" />
                        </div>

                    </div>
                    <asp:Button runat="server" class="btn btn-success" Text="UPDATE Password" OnClick="Unnamed1_Click" />

                </div>
            <div class="dropdown-divider"></div>
            

            <div class="w-100 rounded shadow-sm p-2 m-2">
                <h4>Disable/Enable User</h4>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="p3">User ID</span>
                    </div>
                    <asp:TextBox runat="server" class="form-control" ID="tbUpdateEnables" />
                </div>
                    <asp:Button class="btn btn-primary my-2" Text="CHECK" runat="server" id="btnUpdateEnable" OnClick="btnUpdateEnable_Click"/>
                    <div class="input-group mb-3">
                      <div class="input-group-prepend">
                      <asp:CheckBox runat="server" Visiable="false" ID="chkStatus" class="form-control" Text=" Enable/disable user" OnCheckedChanged="chkStatus_CheckedChanged" AutoPostBack="True"/>
                      </div>
                    </div>
            </div>
            </div>
        </div>
    </form>
</body>
</html>
