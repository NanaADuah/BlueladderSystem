<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackupInfo.aspx.cs" Inherits="bcms.BackupInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database</title>
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
                <h1 class="display-5">Backup Options <i class="fa fa-wrench" aria-hidden="true"></i></h1>
            </div>
            <a class="btn btn-success float-right" href="Help.aspx">Help</a>
            <div class="dropdown-divider"></div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
            <div class="container">
                <div class="row">

                    <div id="data" class="w-100 rounded shadow shadow-sm p-2 mb-2">
                        <h3>Backup a Database</h3>
                        <h6>Select an option from below and click execute to create a backup of the database</h6>
                        <div class="dropdown-divider"></div>
                        <div>
                            <div style="display:grid">
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbUser" Text="User Database" OnCheckedChanged="rbUser_CheckedChanged" />
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbEqipment" Text ="Equipment Database" OnCheckedChanged="rbEqipment_CheckedChanged" />
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbEmployee"  Text="Employee Database" OnCheckedChanged="rbEmployee_CheckedChanged"/>
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbDevice" Text="Device Database" OnCheckedChanged="rbDevice_CheckedChanged" />
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbRequest" Text="Equipment Request Database" OnCheckedChanged="rbRequest_CheckedChanged" />
                                <asp:RadioButton runat="server" class="" GroupName="rbOption" id="rbDataLog" Text="Data Logs Database" OnCheckedChanged="rbDataLogs_CheckedChanged" />
                            </div>
                            <div class="dropdown-divider"></div>
                            <asp:Button Text="EXECUTE" runat="server" ID="btnExecute" class="btn btn-secondary m-2" OnClick="btnExecute_Click"></asp:Button>
                        </div>
                    </div>
                    <h2>
                        OR
                    </h2>
                    <div class="w-100 rounded shadow shadow-sm p-2 mb-5">
                        <div class="form-check-inline"> 
                        <h3 class="fw-bold">Delete A Logged Backup </h3>
                        </div>
                        <a href="Backup.aspx" class="btn btn-secondary float-right">VIEW BACKUPS</a>
                        <h6 class="font-weight-light">Enter the backup ID of the database backup to remove</h6>
                        <div class="dropdown-divider"></div>
                            <asp:Label ID="lblDelMessage" runat="server" Text=""></asp:Label>
                        <div class="input-group mb-3">
                          <span class="input-group-text rounded-0" id="inputGroup-sizing-default">#</span>
                          <asp:TextBox runat="server" class="form-control" id="tbDeleteBackup" aria-label="Backup Delete ID"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" class="btn btn-danger m-2" Text="REMOVE" ID="btnRemoveBackup" OnClick="btnRemoveBackup_Click" ></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
