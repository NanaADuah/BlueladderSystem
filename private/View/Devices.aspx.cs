using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bcms
{
    public partial class Devices : System.Web.UI.Page
    {
        protected IList<Device> devices;
        protected void Page_Load(object sender, EventArgs e)
        {
            devices = new List<Device>();
            devices.Add(new Device()
            {
                Name = "Device 1",
                Type = "Device 2",
                DeviceID = 0
            }); ;
        }
    }

    public class Device
    {
        public string Name { get; set; }
        public string Type { get; set; } 
        public int DeviceID { get; set; }
        public int UserID { get; set; }
    }
}