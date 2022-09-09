<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="old_dashboard.aspx.cs" Inherits="bcms.includes.WebForm1" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/dashboard.css">
    <title>Dashboard</title>
</head>

<body>
    <div id="nBar">
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

                <form class="form-inline my-2 my-lg-0">
                    <input class="form-control mr-sm-2" type="search" placeholder="Search for users, settings, etc." aria-label="Search" style="min-width: 500px">
                    <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                </form>
            </div>
            <div class="dropdown mx-2" style="overflow: visible">
                <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Options
                </button>
                <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenu2">
                    <button class="dropdown-item" type="button">Settings</button>
                    <div class="dropdown-divider"></div>
                    <button class="dropdown-item" type="button">Log Out</button>
                </div>
            </div>

        </nav>
        <div class="dropdown-divider"></div>
    <!-- Image and text -->
    <nav class="navbar navbar-light">
        <button type="button" class="btn btn-primary" data-toggle="button" aria-pressed="false" autocomplete="off">
            Go Back
        </button>
    </nav>
    </div>

    <!--
	<div class="header">
		<div class="topnav"> 	
            <nav class="navbar navbar-expand-lg navbar-light " >
                  <a class="navbar-brand" style="pointer-events:none;">
                      <h3 style="font-weight:bolder; color: #00719C; text-transform:uppercase">BlueLadder CMS</h3>
                </a>
                  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                  </button>
                  <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav mr-auto">
                      <li class="nav-item active">
                        
                      </li>
                      <li class="nav-item">
                        
                      </li>
                      <li class="nav-item">
                        
                      </li>
                    </ul>
                        <form class="form-inline" id="form1"> 
                    <span class="navbar-text">
                            <input class="form-control mr-sm-2" type="search" placeholder="Search for users, settings, etc." style="min-width:500px" aria-label="Search">
                            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </span>
                        </form>
                   
            </nav>            
		</div>
        <form runat="server" id="form2"> 

        <div id="breaker"></div>
        <div style="margin-left:20px;margin-bottom:5px">
            <asp:Button id="btnReturn" runat="server" Text="Return" class="btn btn-outline-primary" OnClick="btnReturn_Click"></asp:Button>
        </div>
        </form>
	</div>-->

    <div id="view" class="container-fluid p-0 shadow mx-auto justify-content-center row">
        <div id="viewGrid" class="row d-flex justify-content-center">
            <div class="card col-2 shadow rounded m-2 p-0">
                <img class="image" src="../../public/includes/security.png" alt="Image"><div class="card-footer font-weight-bold">
                    SECURITY<div style="font-weight: lighter; font-size: 0.8rem">Manage security settings</div>
                </div>
            </div>
            <div class="card col-2 shadow rounded m-2 p-0">
                <img class="image" src="../../public/includes/indicator.png" alt="Image"><div class="card-footer font-weight-bold">
                    REPORTS<div style="font-weight: lighter; font-size: 0.8rem">Manage company reports</div>
                </div>
            </div>
            <div class="card col-2 shadow rounded m-2 p-0">
                <img class="image" src="../../public/includes/user.png" alt="Image"><div class="card-footer font-weight-bold">
                    USERS<div style="font-weight: lighter; font-size: 0.8rem">Manage system users</div>
                </div>
            </div>
            <div class="card col-2 shadow rounded m-2 p-0">
                <img class="image" src="../../public/includes/device1.png" alt="Image"><div class="card-footer font-weight-bold">
                    DEVICES<div style="font-weight: lighter; font-size: 0.8rem">Manage connected devices</div>
                </div>
            </div>
            <div class="card col-2 shadow rounded m-2 p-0">
                <img class="image" src="../../public/includes/file.png" alt="Image"><div class="card-footer font-weight-bold">
                    BACKUPS<div style="font-weight: lighter; font-size: 0.8rem">Manage system backups</div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
