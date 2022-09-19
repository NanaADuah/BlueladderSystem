<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SummaryReport.aspx.cs" Inherits="bcms.SummaryReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cost Summary Report</title>
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

                <h1 class="display-5"><a href="ViewReports.aspx"><i class="fa fa-chevron-left"></i></a>Revenue Report</h1>
                <div class="dropdown-divider"></div>
            </div>
            <div>
                <asp:Label ID="lblMessages" Text="" runat="server"></asp:Label>
                <div class="text-align">
                    <div class="text-align mx-auto">
                        <a class="btn btn-outline-primary m-1" href="SummaryReport.aspx?tab=overview">OVERVIEW</a>
                        <a class="btn btn-outline-primary m-1" href="SummaryReport.aspx?tab=employee">EMPLOYEE SALARIES</a>
                        <a class="btn btn-outline-primary m-1" href="SummaryReport.aspx?tab=total">TOTAL</a>
                    </div>
                </div>
            </div>
            <%if (tabView.Equals("overview") || String.IsNullOrWhiteSpace(tabView))
                { %>
            <div id="overview">
                <div id="container">

                    <div id="tableView">


                        <%if (!categoryData.Any())

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
                        <%}
                            else
                            { %>
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">Job Type</th>
                                    <th scope="col">Salary per hour</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in categoryData)
                                    { %>
                                <tr>
                                    <td><%=item.Type %></td>
                                    <td>R <%=item.Amount.ToString("F2")%></td>
                                </tr>
                                <%} %>
                            </tbody>
                        </table>
                        <% }

                        %>
                    </div>
                </div>
            </div>
            <%}
                else
  if (tabView.Equals("employee"))
                {%>
            <div class="container">
                <div class="tableView">
                    <%if (!empData.Any())
                        {%>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Information</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center">No data could be found or calculated</td>
                            </tr>
                        </tbody>
                    </table>
                    <%}
                        else
                        { %>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th>Employee ID</th>
                                <th>Employee Name</th>
                                <th>Employee Hours</th>
                                <th>Final Salary</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%foreach (var item in empData)
                                { %>
                            <tr>

                                <td><%=item.EmployeeID%></td>
                                <td><%=item.EmployeeFName %> <%=item.EmployeeLName %></td>
                                <td><%=item.EmployeeHours%></td>
                                <td>R <%=item.FinalSalary.ToString("F2")%></td>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                    <%} %>
                </div>
            </div>
            <%}
                else
                if (tabView.Equals("total"))
                {%>
            <div>
                <div class="container">
                    <div class="tableView">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Information</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputIncome" disabled>Total Company Income</span>
                                            </div>
                                            <asp:TextBox type="text" class="form-control" ID="tbIncome" runat="server" ReadOnly="True" />
                                        </div>

                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputSalary" disabled>Total Salaries</span>
                                                
                                            </div>
                                            <asp:TextBox type="text" class="form-control" ID="tbTotal" runat="server" ReadOnly="True" />
                                        </div>
                                        
                                        <div class="input-group mb-3">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text" id="inputRevenue" disabled>Total Revenue</span>
                                            </div>
                                            <asp:TextBox type="text" class="form-control" ID="tbRevenue" runat="server" ReadOnly="True" />
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <%} %>
        </div>
        <!--<asp:ListBox ID="SumList" runat="server" Height="361px" Width="1477px"></asp:ListBox>-->
        <p>
            <asp:Label ID="infoDisplay" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
