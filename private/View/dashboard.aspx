<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="bcms.dashboard" %>

<!doctype html>
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
        <!--<div id="nBar">
            <nav class="navbar navbar-expand-lg navbar-light ">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <a class="navbar-brand" href="#">BlueLadder</a>
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled" href="#">Disabled</a>
                        </li>
                    </ul>

                    <div class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Search for users, settings, etc." aria-label="Search" style="min-width: 500px">
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </div>
                    <div class="dropdown mx-2" style="overflow: visible">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Options
                        </button>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenu2">
                            <button class="dropdown-item" type="button">Settings</button>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="startup.aspx">Log Out</a>
                        </div>
                    </div>
                </div>

            </nav>
            <div class="dropdown-divider"></div>
            <nav class="navbar navbar-light">
                <asp:Button Text="Go Back" runat="server" class="btn btn-primary" data-toggle="button" aria-pressed="false" ID="btnBack" OnClick="btnBack_Click"></asp:Button>
            </nav>
        </div>-->
        <!--#include file="navBar.html"-->

        <div id="view" class="container-fluid p-0 shadow mx-auto justify-content-center row">
            <div id="viewGrid" class="row d-flex justify-content-center">
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/security.png" alt="Image">
                    <a href="#" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        SECURITY<div style="font-weight: lighter; font-size: 0.8rem">Manage security settings</div>
                    </div>
                    </a>
                </div>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/indicator.png" alt="Image">
                    <a href="#" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        REPORTS<div style="font-weight: lighter; font-size: 0.8rem">Manage company reports</div>
                    </div>
                    </a>
                </div>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/user.png" alt="Image">
                    <a href="ManageUsers.aspx" class="text-reset text-decoration-none">
                        <div class="card-footer font-weight-bold">
                        USERS<div style="font-weight: lighter; font-size: 0.8rem">Manage system users</div>
                        </div>
                    </a>
                </div>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/device1.png" alt="Image">
                    <a href="#" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        DEVICES<div style="font-weight: lighter; font-size: 0.8rem">Manage connected devices</div>
                    </div>
                    </a>
                </div>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/file.png" alt="Image">
                    <a href="#" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        BACKUPS<div style="font-weight: lighter; font-size: 0.8rem">Manage system backups</div>
                    </div>
                    </a>
                </div>
                <div class="card col-2 shadow rounded m-2 p-0">
                    <img class="image" src="../../public/includes/file.png" alt="Image">
                    <a href="#" class="text-reset text-decoration-none">
                    <div class="card-footer font-weight-bold">
                        BACKUPS<div style="font-weight: lighter; font-size: 0.8rem">Manage system backups</div>
                    </div>
                    </a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
