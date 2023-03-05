﻿<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="nBar" style="top: 0;">
            <nav class="navbar navbar-expand-lg navbar-light ">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <a class="navbar-brand" href="dashboard.aspx"><i class="fa fa-home fa-fw logoNav"></i>BlueLadder</a>
                    <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li class="nav-item active">
                            <a class="nav-link" href="#"><span class="sr-only">(current)</span></a>
                        </li>
                    </ul>

                    <div class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" id="tbInput" name="tbInput" type="text" placeholder="Search for users, settings, etc." aria-label="Search" style="min-width: 500px" />
                        <button class="btn btn-outline-success my-2 my-sm-0" onclick="searchData()"><i class="fa fa-search" aria-hidden="true"></i>Search</button>
                    </div>
                    <div class="dropdown mx-2" style="overflow: visible">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenu2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Options
                        </button>
                        <div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenu2">
                            <a class="dropdown-item" href="Settings.aspx">Settings</a>
                            <div class="dropdown-divider"></div>
                            <a class="dropdown-item" href="startup.aspx">Log Out</a>
                        </div>
                    </div>
                </div>

            </nav>
            <div class="dropdown-divider"></div>
            <nav class="navbar navbar-light">
                <a class="btn btn-primary text-white" href="dashboard.aspx" aria-pressed="true"><i class="fa fa-arrow-circle-left" aria-hidden="true"></i>Go Back</a>
            </nav>
        </div>

    </form>
</body>
</html>
