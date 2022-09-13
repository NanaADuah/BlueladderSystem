<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSettings.aspx.cs" Inherits="bcms.UserSettings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Settings</title>
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
                <h1 class="display-5">Employee Settings</h1>
                </div>
                <a class="btn btn-success float-right" href="Help.aspx">Help</a>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <button class="btn btn-outline-secondary dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><i aria-hidden="true" class="fa fa-search"></i></button>
                        <div class="dropdown-menu">
                            <%if (Request.QueryString["task"] != null && Request.QueryString["task"].Equals("permission", StringComparison.CurrentCultureIgnoreCase)){%>
                            <a class="dropdown-item">Permission</a>
                            <%}else
                              if (Request.QueryString["task"] != null && Request.QueryString["task"].Equals("setting", StringComparison.CurrentCultureIgnoreCase)) { %>
                            <a class="dropdown-item">Settings</a>
                            <%} %>
                        </div>
                    </div>
                </div>
            </div>
            <div class="dropdown-divider"></div>
            <div class="mx-5 my-2">
            </div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </div>
        <div id="tableView">
<%if ((Request.QueryString["task"] != null) && (Request.QueryString["task"].Equals("setting", StringComparison.CurrentCultureIgnoreCase))) { %>
        <div id="tableSettings">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Employee Settings</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="auto-style1">Allow viewing of other profiles</td>
                        <td class="auto-style1"><asp:CheckBox runat="server" ID="chkViewOther" Text=""/></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Enable device logging</td>
                        <td class="auto-style1"><asp:CheckBox runat="server" ID="chkDeviceSettingsOther" Text=""/></td>
                    </tr>
                </tbody>
            </table>
        </div>
            <%}else
               if(Request.QueryString["task"] != null && Request.QueryString["task"].Equals("permission", StringComparison.CurrentCultureIgnoreCase)){ 
                    %>
        <div id="tablePermission">
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">Employee Settings</th>
                        <th scope="col"></th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="auto-style1">Allow viewing other users</td>
                        <td class="auto-style1"><asp:CheckBox runat="server" ID="chkViewOthers" disabled Text=""/></td>
                    </tr>
                </tbody>
            </table>
            <asp:Button runat="server" id="btnSave" Text="Save" class="btn btn-dark float-right"></asp:Button>
        </div>
            <%} %>
        </div>

    </form>
</body>
</html>
