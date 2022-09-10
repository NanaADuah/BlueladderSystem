<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="bcms.AddUser1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add User</title>
    <link rel="stylesheet" href="css/AddUser.css"/>
    <link href="css/bootstrap-4.4.1.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="css/dashboard.css"/>
</head>
<body>
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
                    <h4>System Role</h4>
                  <div class="mb-2 pb-2">
                    <select class="select form-outline p-2">
                      <option value="Admin" disabled>Admin</option>
                      <option value="Owner" disabled>Owner</option>
                      <option value="Worker">Worker</option>
                    </select>
                  </div>

                  <div class="row">
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <input type="text" id="form3Examplev2" class="form-control form-control-lg" />
                        <label class="form-label" for="form3Examplev2">First name</label>
                      </div>

                    </div>
                    <div class="col-md-6 mb-4 pb-2">

                      <div class="form-outline">
                        <input type="text" id="form3Examplev3" class="form-control form-control-lg" />
                        <label class="form-label" for="form3Examplev3">Last name</label>
                      </div>

                    </div>
                  </div>

                  <div class="mb-4 pb-2 ">
                    <div class="form-outline">
                      <input type="text" id="form3Examplev4" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Examplev4">Email address</label>
                    </div>
                  </div>
                    <div class="dropdown-divider"></div>
                  <div class="row">
                    <div class="col-md-6 mb-2 pb-2 mb-md-0 pb-md-0">
                        Gender:
                    </div>
                    <div class="col-md-6">

                      <select class="select form-outline p-2">
                        <option value="1">Employees</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
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
                      <input type="text" id="form3Examplea2" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Examplea2">Job Status</label>
                    </div>
                  </div>

                  <div class="mb-2 pb-2">
                    <div class="form-outline form-white">
                      <input type="text" id="form3Examplea3" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Examplea3">Additional Information</label>
                    </div>
                  </div>

                  <div class="row">
                  </div>

                  <div class="mb-4">
                    <div class="form-outline form-white">
                      <input type="text" id="form3Examplea9" class="form-control form-control-lg" />
                      <label class="form-label" for="form3Examplea9">Your Email</label>
                    </div>
                  </div>

                    <div class="dropdown-divider"></div>
                    <div>
                  <button type="button" class="btn btn-light btn"
                    data-mdb-ripple-color="dark">Register User</button>
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
</body>
</html>
