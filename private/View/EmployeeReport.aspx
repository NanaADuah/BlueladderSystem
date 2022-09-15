<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeReport.aspx.cs" Inherits="bcms.EmployeeReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>
<style>
    Chart1 
    {
        pointer-events: none;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Report</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.7/dist/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/dashboard.css" />
    <link rel="stylesheet" href="css/ManageUsers.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file="navBar.html"-->
        <div class="px-5" id="main">
            <div id="header">

                <h1 class="display-5"><a href="ViewReports.aspx"><i class="fa fa-chevron-left"></i></a>Employee Reports</h1>
                <div class="dropdown-divider"></div>
            </div>
            <div>
                <asp:Label runat="server" ID="lblInfo"></asp:Label>
            </div>
            <div id="tableView">
                <asp:Label ID="infoDisplay" runat="server" Text=""></asp:Label>
                <div class="input-group mb-3">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="inputGroup-sizing-default" disabled>Total employees</span>
                    </div>
                    <asp:TextBox type="text" class="form-control" ID="tbTotalEmp" runat="server" ReadOnly="True" />
                </div>
                <%if (report != null)
                    { %>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Job Types</th>
                            <th scope="col">Number of employees</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (var item in report.JobStatus)

                            { %>
                        <tr>
                            <td scope="col"><%=item.Name %></td>
                            <td scope="col"><%=item.Count %></td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
                <%}
                    else
                    { %>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-center">There is no data to show</td>
                        </tr>
                    </tbody>
                </table>
                <%} %>

                <asp:Chart runat="server" ID="Chart1" class="form-control mx-auto" AntiAliasing="None" Palette="EarthTones" Width="721px">
                    <Series>
                        <asp:Series Name="Series1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
                <div>
                    <%if (report != null)
                        { %>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Job Types</th>
                                <th scope="col">Average work hours per month</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%foreach (var item in report.EmployeeHours)

                                { %>
                            <tr>
                                <td scope="col"><%=item.Name %></td>
                                <td scope="col"><%=item.Hours %> hours</td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                    <%}
                        else
                        { %>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Options</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center">There is no data to show</td>
                            </tr>
                        </tbody>
                    </table>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
