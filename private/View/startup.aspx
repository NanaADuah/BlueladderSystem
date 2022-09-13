<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startup.aspx.cs" Inherits="bcms.startup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../public/font-awesome-4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/startup.css"/>
</head>
<body>
<section class="vh-100" id="background">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col col-xl-10">
        <div class="card" style="border-radius: 1rem;">
          <div class="row g-0">
            <div class="col-md-6 col-lg-5 d-none d-md-block">
              <img src="../../public/includes/SideImage.png"
                alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
            </div>
            <div class="col-md-6 col-lg-7 d-flex align-items-center">
              <div class="card-body p-4 p-lg-5 text-black">

                <form runat="server" id="form1">
                <asp:Label runat="server" id="infoDisplay"></asp:Label>
                  <h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Sign in <i class="fa fa-sign-in" aria-hidden="true"></i></h3>

                   <!-- the worker ID input-->
                  <div class="form-outline mb-4">
                    <asp:TextBox runat="server" id="tbWorkID" class="form-control form-control-lg" />
                    <label class="form-label" for="tbWorkID">Work ID</label>
                      <asp:RequiredFieldValidator class="float-right text-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Work ID required" ControlToValidate="tbWorkID"></asp:RequiredFieldValidator>
                  </div>

                   <!-- the password input-->
                  <div class="form-outline mb-4">
                    <asp:TextBox runat="server" id="tbPassword" class="form-control form-control-lg" TextMode="Password"/>
                    <label class="form-label" for="tbPassword">Password</label>
                      <asp:RequiredFieldValidator class="float-right text-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password required" ControlToValidate="tbPassword"></asp:RequiredFieldValidator>
                  </div>

                  <div class="pt-1 mb-4">
                      <asp:Button runat="server" Text="Login" class="btn btn-dark btn-lg btn-block" ID="btnLogin" OnClick="btnLogin_Click"></asp:Button>
                  </div>
                  <a class="small text-muted" href="ForgotPassword.aspx">Forgot password?</a>
                  <a href="#" class="small text-muted">Terms of use.</a>
                  <a href="#" class="small text-muted">Privacy policy</a>
                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</body>
</html>
