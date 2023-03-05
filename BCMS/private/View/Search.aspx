﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="bcms.Search" %>

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
    <title>Search</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="px-5" id="main">

                <h1 class="display-5">Search Results</h1>
                <div class="dropdown-divider">
                </div>
                <%if (results.Any())
                    { %>
                <div id="tableView ">
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Were you perhaps looking for?</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                                <%foreach (var item in results)
                            
                                    {  %>
                            <tr>
                                        <td><%=item.Name%></td>
                                        <td><a class="btn btn-primary" href="<%=item.Link%>">Go to <i class="fa fa-eye"></i></a></td>
                            </tr>
                                <%} %>
                        </tbody>
                    </table>
                    <%
                        }
                        else
                        {
                    %><table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Search results</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="text-center">We couldn't find any search results for '<%=Request.QueryString["search"]%>'</td>
                            </tr>
                        </tbody>
                    </table>
                    <%}
                    %>
                </div>
            </div>
        </div>
        <div>
        </div>
    </form>
</body>
</html>
