﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class UpdateUserPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            Response.Redirect("Security.aspx");

            if(Request.QueryString["token"] != null && Request.QueryString[""] != null)
            {
                string token = Request.QueryString["token"];
                string userID = Request.QueryString["userID"] ;

            }
            else
            {
                Response.Redirect("startup.aspx");
            }
        }
    }
}