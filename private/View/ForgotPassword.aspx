<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="bcms.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" href="css/ForgotPassword.css" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link rel="stylesheet" href="css/dashboard.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container padding-bottom-3x mb-2 mt-5">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-md-10 p-2 " id="holder">
                    <div class="forgot">

                        <asp:Label runat="server" ID="lblMessages"></asp:Label>
                        <h2>Forgot your password?</h2>
                        <p>Change your password in three easy steps. This will help you to secure your password!</p>
                        <ol class="list-unstyled">
                            <li><span class="text-primary text-medium">1. </span>Enter your email address below.</li>
                            <li><span class="text-primary text-medium">2. </span>Our system will send you a temporary link</li>
                            <li><span class="text-primary text-medium">3. </span>Use the link to reset your password</li>
                        </ol>

                    </div>
                    <div class="card mt-4">
                        <div class="card-body">
                            <div class="form-group">
                                <label for="email-for-pass">Enter your email address</label>
                                <asp:TextBox class="form-control" runat="server" id="emailReset" ></asp:TextBox>
                                <asp:RegularExpressionValidator class="float-right" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email address" ControlToValidate="emailReset" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="form-group">
                                <label for="email-for-pass">Enter your User ID</label>
                                <asp:TextBox class="form-control" runat="server" id="tbID" ></asp:TextBox>
                            </div>
                                 <small class="form-text text-muted">Enter the email address used on the BlueLadder System. Then we'll email a link to this address.</small>
                        </div>
                        <div class="card-footer">
                            <asp:Button class="btn btn-success float-right text-white" runat="server" Text="Get New Password" OnClick="Unnamed1_Click"></asp:Button>
                            <a class="btn btn-danger text-white" href="startup.aspx">Back to Login <i class="fa fa-sign-in" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
