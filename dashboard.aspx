<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="bcms.includes.WebForm1" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<link rel="stylesheet" href="css/dashboard.css">
<link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<title>Dashboard</title>
</head>

<body>
	<div class="header">
		<div class="topnav"> 	
            <nav class="navbar navbar-expand-lg navbar-light " >
                  <a class="navbar-brand" style="pointer-events:none;">
                      <!--<img id="logo" src="includes/Logo.png" alt="Image">-->
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
                    <span class="navbar-text">
                        <form class="form-inline">
                            <input class="form-control mr-sm-2" type="search" placeholder="Search for users, settings, etc." style="min-width:500px" aria-label="Search">
                            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                        </form>
                    </span>
                      <div class="dropdown show mx-2">
                      <a class="btn btn-secondary dropdown-toggle" href="#" role="button" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Dropdown link
                          </a>

                          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
                            <a class="dropdown-item" href="#">Action</a>
                            <a class="dropdown-item" href="#">Another action</a>
                            <a class="dropdown-item" href="#">Something else here</a>
                          </div>
                    </div>
                  </div>
            </nav>            
		</div>
        <div id="breaker"></div>
        <div style="margin-left:20px;margin-bottom:5px">
            <button type="button" class="btn btn-outline-primary" style="border: 1px solid #00719C; color:  #00719C">Return to main page</button>
        </div>
        
	</div>
    <div id="view" class="container-fluid p-0 shadow mx-auto justify-content-center row">    
        <div id="viewGrid" class="row d-flex justify-content-center">
            <div class="card col-2 shadow rounded m-2 p-0"><img class="image" src="includes/security.png" alt="Image"><div class="card-footer font-weight-bold">SECURITY<div style="font-weight:lighter;font-size:0.8rem">Manage security settings</div></div></div>
            <div class="card col-2 shadow rounded m-2 p-0"><img class="image" src="includes/indicator.png" alt="Image"><div class="card-footer font-weight-bold" >REPORTS<div style="font-weight:lighter;font-size:0.8rem">Manage company reports</div></div></div>
            <div class="card col-2 shadow rounded m-2 p-0"><img class="image" src="includes/user.png" alt="Image"><div class="card-footer font-weight-bold">USERS<div style="font-weight:lighter;font-size:0.8rem">Manage system users</div></div></div>
            <div class="card col-2 shadow rounded m-2 p-0"><img class="image" src="includes/device1.png" alt="Image"><div class="card-footer font-weight-bold">DEVICES<div style="font-weight:lighter;font-size:0.8rem">Manage connected devices</div></div></div>
            <div class="card col-2 shadow rounded m-2 p-0"><img class="image" src="includes/file.png" alt="Image"><div class="card-footer font-weight-bold">BACKUPS<div style="font-weight:lighter;font-size:0.8rem">Manage system backups</div></div></div>
        </div>
	</div>
</body>
</html>
