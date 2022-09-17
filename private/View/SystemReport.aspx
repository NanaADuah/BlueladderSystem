<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemReport.aspx.cs" Inherits="bcms.SystemReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Reports</title>
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
        <div>
           <div class="px-5" id="main">
            <div class="form-check-inline">

            <h1 class="display-5">System Logs Report<i class="fa fa-laptop" aria-hidden="true"></i></h1>
            </div>
            <a href="ViewReports.aspx" id="btnExport" class="btn btn-success float-right">GO BACK</a>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div class="tableView">
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="span1" disabled>Average daily logins </span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbAverage" runat="server" ReadOnly="True" />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="span2" disabled>Total logins</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbTotal" runat="server" ReadOnly="True" />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="span3" disabled>Average logins monthly</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbMonthlyTotal" runat="server" ReadOnly="True" />
                </div>
                
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="span4" disabled>Total password change requests</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbPasswordRequest" runat="server" ReadOnly="True" />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="spa5" disabled>Total notifications sent</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbNotifications" runat="server" ReadOnly="True" />
                </div>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="spa5" disabled>Average notifications sent daily</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbDailyNoti" runat="server" ReadOnly="True" />
                </div>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
