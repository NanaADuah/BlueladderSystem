﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
namespace bcms
{
    public partial class AddUser1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            User instance = new User();

            if (!instance.getRole(int.Parse(Session["UserID"].ToString())).Equals("Admin"))
                Response.Redirect("dashboard.aspx");

            lblMessages.Text = "";
            lblMessages.ForeColor = System.Drawing.Color.Black;

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Database database = new Database();

            string firstName = tbFirstName.Text;
            string lastName = tbLastName.Text;
            string email = inputEmail.Text;
            string gender = tbGender.Value;
            string jobStatus = inputStatus.Text;
            string defaultPassword = inputDefaultPassword.Text;
            string role = tbRole.Value.ToString();
            DateTime date = DateTime.Now.Date;

            if(!role.Equals("Worker"))
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Selected system role not allowed";
            }
            else
            {
                try
                {
                    int ID = database.UserAdd(int.Parse(Session["UserID"].ToString()), role, defaultPassword);
                    if(ID!= -1)
                    {
                        database.EmployeeAdd(int.Parse(Session["UserID"].ToString()),ID,jobStatus,date, firstName, lastName, gender, email);
                        lblMessages.Text = "Success"; lblMessages.ForeColor = System.Drawing.Color.Black;
                    }
                    else
                        lblMessages.Text = Database.getError();

                }
                catch(Exception ex)
                {
                    lblMessages.Text = $"Error: {ex.Message}";
                    lblMessages.ForeColor = System.Drawing.Color.Red;
                
                }
            }
        }
    }
}