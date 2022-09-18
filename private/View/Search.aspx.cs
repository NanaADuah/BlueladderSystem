using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class Search : System.Web.UI.Page
    {
        protected IList<SearchResults> results;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("startup.aspx");
            if (Request.QueryString["search"] != null)
            {
                string search = Request.QueryString["search"].ToString().ToLower();
                results = new List<SearchResults>();

                if (search.Contains("device"))
                {
                    results.Add(new SearchResults() { Name = "Devices", Link = "Devices.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=devices", });
                }

                if (search.Contains("equipment"))
                {
                    results.Add(new SearchResults() { Name = "Devices", Link = "Equipment.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=equipment", });
                }

                if (search.Contains("dashboard"))
                {
                    results.Add(new SearchResults() { Name = "Dashboard", Link = "dashboard.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=dashboard", });
                }

                if (search.Contains("profile"))
                {
                    results.Add(new SearchResults() { Name = "MyProfile", Link = "MyProfile.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=profile", });
                }

                if (search.Contains("user"))
                {
                    results.Add(new SearchResults() { Name = "Users", Link = "ManageUsers.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=users", });
                }

                if (search.Contains("backup"))
                {
                    results.Add(new SearchResults() { Name = "Back-ups", Link = "Backup.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=backup", });
                }
                if (search.Contains("settings"))
                {
                    results.Add(new SearchResults() { Name = "Settings", Link = "Settings.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=settings", });
                }
                if (search.Contains("notifications"))
                {
                    results.Add(new SearchResults() { Name = "Notificationss", Link = "Notifications.aspx", });
                    results.Add(new SearchResults() { Name = "Help", Link = "Help.aspx?tab=notifications", });
                }
            }
        }

        public class SearchResults
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }
    }
}