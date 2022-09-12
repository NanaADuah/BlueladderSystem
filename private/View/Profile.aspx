<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="bcms.Profile" %>

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
    <link rel="stylesheet" href="css/ViewEmployees.css" />
    <link rel="stylesheet" href="css/Profile.css" />
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">

        <div id="heading">
            <!--#include file="navBar.html"-->
            <div class="container">
                <div clas="col">
                    <%if (profile != null)
                        { %>
                    <h1 class="display-5 mx-2">Profile - <%= profile.Name%>
                        <%} %>
                    </h1>
                </div>
                <div class="dropdown-divider"></div>
            </div>
            <asp:Label runat="server" ID="lblMessages" Text=""></asp:Label>
        </div>
        <%if (!isWorker)
            {%>
        <div>
            <h1>Unable to view this profile</h1>
        </div>
        <%}%>
        <%if (isWorker)
            {%>
        <div class="container-xl px-4 mt-4">
            <div class="row">
                <div class="col-xl-4">
                    <div class="card mb-4 mb-xl-0">
                        <div class="card-header">Profile Picture</div>
                        <div class="card-body text-center">
                            <img class="img-account-profile rounded-circle mb-2" src="../../public/includes/profile/female.jpg" alt="" />
                            <div class="small font-italic text-muted mb-4">JPG or PNG no larger than 5 MB</div>

                            <button class="btn btn-primary" type="button">Upload new image</button>
                        </div>
                    </div>
                </div>
                <div class="col-xl-8">
                    <div class="card mb-4">
                        <div class="card-header">Account Details</div>
                        <div class="card-body">
                            <div>
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputUserID">User ID for profile</label>
                                    <asp:TextBox class="form-control" runat="server" ID="inputUserID" placeholder="Username" disabled></asp:TextBox>
                                </div>
                                <div class="row gx-3 mb-3">
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="inputFirstName">First name</label>
                                        <asp:TextBox class="form-control" ID="inputFirstName" runat="server" placeholder="First name of user" value="First name of user"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="inputLastName">Last name</label>
                                        <asp:TextBox runat="server" class="form-control" ID="inputLastName" placeholder="Last name of user"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row gx-3 mb-3">
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="inputGender">Gender</label>
                                        <asp:TextBox class="form-control" ID="inputGender" runat="server" placeholder="User gender"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mb-3">
                                    <label class="small mb-1" for="inputEmailAddress">Email address</label>
                                    <asp:TextBox runat="server" class="form-control" ID="inputEmailAddress" placeholder="Email Address" />
                                </div>
                                <div class="row gx-3 mb-3">
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="inputJobStatus">Job Status</label>
                                        <asp:TextBox class="form-control" runat="server" ID="inputJobStatus" placeholder="Job Status"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="small mb-1" for="inputBirthday">Birthday</label>
                                        <asp:TextBox class="form-control" ID="inputBirthday" runat="server" name="birthday" placeholder="User's birthday"></asp:TextBox>
                                    </div>
                                </div>

                                <%if (role.Equals("Admin"))
                                    { %>
                                <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save changes" OnClick="btnSave_Click"></asp:Button>
                                <%} %>
                                <asp:Button ID="btnCancel" class="float-right btn btn-warning" runat="server" Text="Back" OnClick="btnCancel_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%} %>
    </form>
</body>
</html>
