<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="bcms.AddUser1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add User</title>
    <link rel="stylesheet" href="css/AddUser.css" />
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/dashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="h-100 h-custom gradient-custom-2">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12">
                        <div class="card card-registration card-registration-2" style="border-radius: 15px;">
                            <div class="card-body p-0">
                                <div class="row g-0">
                                    <div class="col-lg-6">
                                        <div class="p-5">
                                            <h3 class="fw-normal mb-2" style="color: #4835d4;">ADD NEW USER</h3>
                                            <div class="dropdown-divider"></div>
                                            <asp:Label ID="lblMessages" runat="server" Text=""></asp:Label>
                                            <div class="row">
                                            <div class="col-md-6 mb-2 pb-2 mb-md-0 pb-md-0">
                                                    System Role:
                                                </div>
                                            <div class="mb-2 pb-2 float-right">
                                                <select class="select form-outline p-2" id="tbRole" runat="server">
                                                    <option value="Admin" disabled>Admin</option>
                                                    <option value="Owner" disabled>Owner</option>
                                                    <option value="Worker">Worker</option>
                                                </select>
                                            </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-6 mb-4 pb-2">

                                                    <div class="form-outline">
                                                        <asp:TextBox id="tbFirstName" class="form-control form-control-lg" runat="server"/>
                                                        <label class="form-label" for="tbFirstName">First name</label>
                                                    </div>

                                                </div>
                                                <div class="col-md-6 mb-4 pb-2">

                                                    <div class="form-outline">
                                                        <asp:TextBox id="tbLastName" class="form-control form-control-lg" runat="server" />
                                                        <label class="form-label" for="tbLastName">Last name</label>
                                                    </div>

                                                </div>
                                            </div>

                                            <div class="mb-4 pb-2 ">
                                                <div class="form-outline">
                                                    <asp:TextBox ID="inputEmail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                                    <label class="form-label" for="tbEmail">Email address</label>
                                                </div>
                                            </div>
                                            <div class="dropdown-divider"></div>
                                            <div class="row">
                                                <div class="col-md-6 mb-2 pb-2 mb-md-0 pb-md-0">
                                                    Gender:
                                                </div>
                                                <div class="col-md-6">

                                                    <select class="select form-outline p-2" id="tbGender" runat="server">
                                                        <option value="Female">Female</option>
                                                        <option value="Male">Male</option>
                                                        <option value="Other">Other</option>
                                                    </select>

                                                </div>
                                            </div>
                                            <div class="dropdown-divider"></div>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 bg-indigo text-white">
                                        <div class="p-5">
                                            <h3 class="fw-normal mb-2">Employee Details</h3>
                                            <div class="dropdown-divider"></div>
                                            <div class="mb-2 pb-2">
                                                <div class="form-outline form-white">
                                                    <asp:TextBox id="inputStatus" class="form-control form-control-lg" runat="server"/>
                                                    <label class="form-label" for="inputStatus">Job Status</label>
                                                </div>
                                            </div>

                                            <div class="mb-2 pb-2">
                                                <div class="form-outline form-white">
                                                    <asp:TextBox id="inputAdditional" class="form-control form-control-lg" runat="server"/>
                                                    <label class="form-label" for="inputAdditional">Additional Information</label>
                                                </div>
                                            </div>

                                            <div class="row">
                                            </div>

                                            <div class="mb-4">
                                                <div class="form-outline form-white">
                                                    <asp:TextBox id="inputDefaultPassword" class="form-control form-control-lg" runat="server"/>
                                                    <label class="form-label" for="inputDefaultPassword">Default password</label>
                                                </div>
                                            </div>

                                            <div class="dropdown-divider"></div>
                                            <div>
                                                <asp:Button runat="server" class="btn btn-info" ID="btnRegister" Text="Register" OnClick="btnRegister_Click"></asp:Button>
                                                <a class="btn btn-outline-warning float-right" href="dashboard.aspx">Cancel</a>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
