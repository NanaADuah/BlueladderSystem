<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="bcms.Settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <title>Settings</title>
</head>

<body>
    <form id="form1" runat="server">
        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="px-5" id="main">
                <h1 class="display-5">Settings</h1>
                <div class="dropdown-divider">
                </div>
            </div>
        </div>
        <div id="tableView" class="w-75">
            <table class="table">
                <tbody>
                    <tr>
                        <th scope="row">Dark mode</th>
                        <td>
                                <div class="toggle-container">
                            <div class="custom-control custom-switch">
                            <!-- 
                                    <button class="theme-btn light btn btn-primary" onclick="setTheme('light')" title="Light mode">
                                    </button>
                                    <button class="theme-btn dark btn btn-primary" onclick="setTheme('dark')" title="Dark mode">
                                    </button>
        -->
                                <input type="checkbox" class="custom-control-input" id="darkMode" onclick="change()">
                                <label class="custom-control-label" for="customSwitch1"></label>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">Account</th>
                        <td>
                           <a href="MyProfile.aspx" class="btn btn-secondary w-25">VIEW</a>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">Help</th>
                        <td>

                            <a href="Help.aspx" class="btn btn-secondary w-25">VIEW</a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <script type="text/javascript">
            function setTheme(theme)
            {
                const setTheme = theme => document.documentElement.className = theme;
                console.log(theme);
            }
        </script>
    </form>
</body>
</html>
