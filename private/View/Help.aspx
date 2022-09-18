<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="bcms.Help" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Help Page</title>
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
                <h1 class="display-5">Help Page</h1>
            </div>
            <div class="dropdown-divider"></div>
            <asp:Label ID="InfoDisplay" runat="server"></asp:Label>
            <div id="tableView">
                <div class="m-4">
                    <div class="container">
                        <nav class="justify-content-center text-center">
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=default">Home</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=dashboard">Dashboard</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=profile">Profile</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=notifications">Notifications</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=equipment">Managing Equipment</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=search">Search</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=users">Users</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=backups">Backups</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=settings">Settings </a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=devices">Devices</a>
                            <a class="btn btn-outline-primary m-1" href="Help.aspx?tab=reports">Reports</a>
                        </nav>
                    </div>
                    <%if (HelpText.Equals("default") || String.IsNullOrEmpty(Request.QueryString["tab"].ToString()))
                        {%>
                    <div id="defaultContainer text-center">
                        <div class="dropdown-divider"></div>
                        <h2 class="font-weight-bolder text-center">BlueLadder Construction Management</h2>
                        <h5 class="font-weight-light text-center">Select an option from the top to view some help on it</h5>
                    </div>
                    <%}
                        else
                    if (HelpText.Equals("notifications"))
                        {  %>
                    <div id="notificationsContainer">
                        <div class="dropdown-divider"></div>
                        <div>
                            <h2 class="font-weight-bolder text-center">Notifications Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="cointainer ">
                                <div class="row">
                                    <div class="card col-2 shadow rounded m-2 p-0 text-center" style="pointer-events: none">
                                        <img class="image" src="../../public/includes/noti.png" alt="Image" />
                                        <a class="text-reset text-decoration-none">
                                            <div class="card-footer font-weight-bold">
                                                NOTIFICATIONS<div style="font-weight: lighter; font-size: 0.8rem">Manage notificatons</div>
                                            </div>
                                        </a>
                                    </div>
                                    <div>
                                        <p>The notification page provides a means of communication within the system</p>
                                        <p>Users will primarily receive notifications about requested/returned equipment.</p>
                                        <p>Users will also occasionally receive messages from admins/the system about maintenance.</p>
                                        <p>Notifications all contain times on them on which they were sent.</p>
                                        <p>Users are able to clear any notifications that they have already viewed.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                    if (HelpText.Equals("dashboard"))
                        {  %>
                    <div id="dashboardContainer">
                        <div class="dropdown-divider"></div>
                        <div class="container">
                            <h2 class="font-weight-bolder text-center">Dashboard Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="container">
                                <div class="row">
                                    <div class="card col-2 shadow rounded m-2 p-0 text-center" style="pointer-events: none">
                                        <img class="image" src="../../public/includes/equipment.png" alt="Image" />
                                        <a class="text-reset text-decoration-none">
                                            <div class="card-footer font-weight-bold">
                                                EQUIPMENT<div style="font-weight: lighter; font-size: 0.8rem">Manage equipment</div>
                                            </div>
                                        </a>
                                    </div>
                                    <div>
                                        <p>The dashboard provides a user-friendly manner to select an option for your task.</p>
                                        <p>The dashboard page will be the first thing you see when you log in.</p>
                                        <p>In order to access the respective panel, referred to as cards, shown on the left.</p>
                                        <p>The user must click on the text under the card view, not the image.</p>
                                        <p>The cards are dynamic in terms of your user account and will show specific cards in regards to your account.</p>
                                        <p>All cards provide back buttons that will return you back to the dashboard.</p>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <%}
                        else
                        if (HelpText.Equals("backups"))
                        {  %>
                    <div id="backupContainer">
                        <div class="dropdown-divider"></div>
                        <div class="container">
                            <h2 class="font-weight-bolder text-center">Backup Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="container">
                                <div class="row">
                                    <div style="pointer-events: none" class="m-2">
                                        <button href="#" class="btn btn-secondary">BACKUP DATABASE</button>
                                        <button href="#" class="btn btn-danger">REMOVE BACKUP</button>
                                    </div>
                                    <div class="col-6">
                                        <p>This page is only available for users with higher administration priviledges</p>
                                        <p>The backup page provides means of admin to back up database and data used by the system for maintenance</p>
                                        <p>The backup interface provides a selection of databases to choose from to back up</p>
                                        <p>There is also an option to remove any selected backup which however only removes the file on the system, and not the files downloaded by the user</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                    if (HelpText.Equals("search"))
                        {  %>
                    <div id="searchContainer">
                        <div class="dropdown-divider"></div>
                        <div class="container text-center">
                            <h2 class="font-weight-bolder text-center">Search Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="container">
                                <div style="pointer-events: none;" class="m-4">
                                    <div class="form-inline my-2 my-lg-0">
                                        <input class="form-control mr-sm-2" id="tbInput" name="tbInput" type="text" placeholder="Search for users, settings, etc." aria-label="Search" style="min-width: 500px" />
                                        <button class="btn btn-outline-success my-2 my-sm-0 float-right" onclick="searchData()"><i class="fa fa-search" aria-hidden="true"></i>Search</button>
                                    </div>
                                </div>
                                <p>The search bar that is contained on the navigation bar at the top provides a means to search for different options available on the system</p>
                                <p>Each search will open up a new tab to prevent you from losing any information you're working with at the moment</p>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                        if (HelpText.Equals("settings"))
                        {  %>
                    <div id="settingsContainer">
                        <div class="dropdown-divider"></div>
                        <h2 class="font-weight-bolder text-center">Settings Help</h2>
                        <div class="dropdown-divider"></div>
                        <div class="container text-center">
                            <p>The settings page provides additional means of accessing features such as your account settings and this help page</p>
                            <p>The setting page also incldues a dark mode setting, but has been disabled for the time being</p>

                        </div>
                    </div>
                    <%}
                        else
                            if (HelpText.Equals("users"))
                        {  %>
                    <div id="usersContainer">
                        <div class="dropdown-divider"></div>
                        <div class="container">
                            <h2 class="font-weight-bolder text-center">Users Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="container">
                                <div class="row">
                                    <div class="card col-2 shadow rounded m-2 p-0 text-center" style="pointer-events: none">
                                        <div class="card-header">Profile</div>
                                        <img class="image rounded-circle p-1" src="../../public/includes/profile/female.jpg" alt="Image" />
                                        <button class="btn btn-primary m-2" type="button">Upload new image</button>
                                    </div>
                                    <div>
                                        <p>This page is only available for users with higher administration priviledges</p>
                                        <p>The interface provides a meanas of managing users on the system and also includes</p>
                                        <p>Disabling or enabling user accounts</p>
                                        <p>Changing profile images</p>
                                        <p>Changing email addresses</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                        if (HelpText.Equals("profile"))
                        {  %>
                    <div id="profilesContainer">
                        <div class="dropdown-divider"></div>
                        <h2 class="font-weight-bolder text-center">Profile Help</h2>
                        <div class="dropdown-divider"></div>
                        <div class="row">
                            <div class="card col-2 shadow rounded m-2 p-0 text-center" style="pointer-events: none">
                                <div class="card-header">Profile</div>
                                <img class="image rounded-circle p-1" src="../../public/includes/profile/female.jpg" alt="Image" />
                                <button class="btn btn-primary m-2" type="button">Upload new image</button>
                            </div>
                            <div>
                                <p>The profile page provides a quick overview of your account, as an employee</p>
                                <p>Available to all users</p>
                                <p>The profile page also provides a link to have your password reset.</p>
                                <p>The user is able to choose and upload a new profile image from the profile page.</p>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                    if (HelpText.Equals("equipment"))
                        {  %>
                    <div id="equipmentContainer">
                        <div class="dropdown-divider"></div>
                        <h2 class="font-weight-bolder text-center">Equipment Help</h2>
                        <div class="dropdown-divider"></div>
                        <div class="container ">
                            <div class="row">
                                <div class="card col-2 shadow rounded m-2 p-0 text-center" style="pointer-events: none">
                                    <img class="image" src="../../public/includes/equipment.png" alt="Image" />
                                    <a class="text-reset text-decoration-none">
                                        <div class="card-footer font-weight-bold">
                                            EQUIPMENT<div style="font-weight: lighter; font-size: 0.8rem">Manage equipment</div>
                                        </div>
                                    </a>
                                </div>
                                <div>
                                    <p>The equipment page provides the user with the option in reference to equipment.</p>
                                    <p>The main equipment page provides the user with the options to either check out or return equipment.</p>
                                    <p>All the buttons contain text indicating their purpose.</p>
                                    <p>The user must click on the text under the card view, not the image.</p>
                                    <p>The cards are dynamic in terms of your user account and will show specific cards in regards to your account.</p>
                                    <p>All cards provide back buttons that will return you back to the dashboard.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                        if (HelpText.Equals("devices"))
                        {  %>
                    <div id="dashContainer">
                        <div class="dropdown-divider"></div>
                        <h2 class="font-weight-bolder text-center">Devices Help</h2>
                        <div class="dropdown-divider"></div>
                        <div class="container">
                            <div class="container text-center">
                                <p>This page is only available for users with higher administration priviledges.</p>
                                <p>The page is provided to manage and view all devices that log onto the system.</p>
                                <p>This is for analytics purposes and also includes the user IDs used to sign in.</p>
                            </div>
                        </div>
                    </div>
                    <%}
                        else
                        if (HelpText.Equals("reports"))
                        {  %>
                    <div id="reportContainer">
                        <div class="dropdown-divider"></div>
                        <div class="container">
                            <h2 class="font-weight-bolder text-center">Reports Help</h2>
                            <div class="dropdown-divider"></div>
                            <div class="container text-center">
                                <p>This page is only available for users with higher administration priviledges.</p>
                                <p>The report page provided to give the appropriate accounts the ability to view generated and summarised infomation of the system</p>
                                <p>This is for analytics purposes and also includes the user IDs used to sign in.</p>
                                <p>This is for analytics purposes.</p>
                                <p>Reports generated would include equipment reports, system logs, revenue summaries and labour reports.</p>
                            </div>
                        </div>
                    </div>
                    <%} %>
                    <div class="dropdown-divider"></div>
                </div>
            </div>
            <a href="dashboard.aspx" class="btn btn-success btn-lg">GO BACK</a>
    </form>
</body>
</html>
