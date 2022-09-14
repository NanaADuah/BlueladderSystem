<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="bcms.dashboard" %>

<!doctype html>

     <style>
        img
        {
             -webkit-user-drag: none;
              -khtml-user-drag: none;
              -moz-user-drag: none;
              -o-user-drag: none;
              user-drag: none;
              tr
        }

        img:hover{
            padding:5px;
        }
    </style>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css"/>
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/dashboard.css">

    <title>Dashboard</title>
</head>


<body>
    <form runat="server" id="form1">
        <!--#include file="navBar.html"-->
        <div id="view" class="container-fluid p-0 shadow mx-auto justify-content-center row">
        <div>
            <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
        </div>
       
            <div id="viewGrid" class="row justify-content-center d-flex align-content-center flex-wrap">
                 
                <%if (role.Equals("Admin") || role.Equals("Owner"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/lock.png" alt="Image">
                    <a href="Security.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        SECURITY<div style="font-weight: lighter; font-size: 0.8rem">Manage security settings</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <%if (role.Equals("Admin") || role.Equals("Owner"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/graph.png" alt="Image">
                    <a href="ViewReports.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        REPORTS<div style="font-weight: lighter; font-size: 0.8rem">Manage company reports</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <%if (role.Equals("Admin") || role.Equals("Owner"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/user.png" alt="Image">
                    <a href="ManageUsers.aspx" class="text-reset text-decoration-none">
                        <div class="card-footer font-weight-bold">
                        USERS<div style="font-weight: lighter; font-size: 0.8rem">Manage system users</div>
                        </div>
                    </a>
                </div>
                <%} %>
                <%if (role.Equals("Admin") || role.Equals("Owner"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/device.png" alt="Image">
                    <a href="Devices.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        DEVICES<div style="font-weight: lighter; font-size: 0.8rem">Manage logged devices</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <%if (role.Equals("Owner") || role.Equals("Admin"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/backup.png" alt="Image">
                    <a href="Backup.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        BACKUPS<div style="font-weight: lighter; font-size: 0.8rem">Manage system backups</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <%if (!role.Equals("Admin") || !role.Equals("Owner") || !role.Equals("Worker"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/equipment.png" alt="Image">
                    <a href="Equipment.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        EQUIPMENT<div style="font-weight: lighter; font-size: 0.8rem">Manage equipment</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <%if (!role.Equals("Admin") || !role.Equals("Owner") || !role.Equals("Worker"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/warehouses.png" alt="Image">
                    <a href="Warehouse.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        WAREHOUSES<div style="font-weight: lighter; font-size: 0.8rem">Manage locations</div>
                    </div>
                    </a>
                </div>
                <%} %> 
                
                <%if (!role.Equals("Admin") || !role.Equals("Owner") || !role.Equals("Worker"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/noti.png" alt="Image">
                    <a href="Notifications.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        NOTIFICATIONS<div style="font-weight: lighter; font-size: 0.8rem">User Notifications</div>
                    </div>
                    </a>
                </div>
                <%} %>
                
                <%if (!role.Equals("Admin") || !role.Equals("Owner") || !role.Equals("Worker"))
                    { %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/storage.png" alt="Image">
                    <a href="DataLogs.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        SYSTEM LOGS<div style="font-weight: lighter; font-size: 0.8rem">Logs</div>
                    </div>
                    </a>
                </div>
                <%} %>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/cogs.png" alt="Image">
                    <a href="Settings.aspx" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        SETTINGS<div style="font-weight: lighter; font-size: 0.8rem">Setting</div>
                    </div>
                    </a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
