﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="bcms.ViewReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
    <title>View Reports</title>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="navBar.html"-->
        <div class="px-5" id="main">
            <div id="header">
                <div class="form-check-inline">

            <h1 class="display-5">Generate Reports <i class="fa fa-bar-chart" aria-hidden="true"></i></h1>
                </div>
                <a href="Help.aspx?tab=reports" class="btn btn-success float-right">Help</a>
            <div class="dropdown-divider"></div>
            </div>

            <div id="tableView">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Options</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>View Revenue Report</td>
                            <td>
                                <a href="SummaryReport.aspx" class="btn btn-primary">View <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>View Employee Report</td>
                            <td>
                                <a href="EmployeeReport.aspx" class="btn btn-primary">View <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
                                </a >
                            </td>
                        </tr>
                        <tr>
                            <td>View Equipment Report</td>
                            <td>
                                <a href="EquipmentReport.aspx" class="btn btn-primary">View <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
                                </a >
                            </td>
                        </tr>
                        <tr>
                            <td>View System Reports</td>
                            <td>
                                <a href="SystemReport.aspx" class="btn btn-primary">View <i class="fa fa-arrow-circle-right" aria-hidden="true"></i>
                                </a >
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
