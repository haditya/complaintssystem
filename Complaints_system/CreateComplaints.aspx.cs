using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Complaints_system.ComplaintsWS;

namespace Complaints_system
{
    public partial class CreateComplaints : System.Web.UI.Page
    {
        public int Userid {
            get
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                return ticket.Version;
            }
 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string rolename = ticket.UserData;
            int userid = ticket.Version;

            if (!rolename.Equals("employee"))
            {
                Response.Redirect("Error.aspx");
            }

        }

        protected void BtnComplaint_Click(object sender, EventArgs e)
        {
            string devicename = TxtDevice.Text;
            Service1 s = new Service1();
            int d = s.GetDeviceId(devicename);
           // int d = GetDeviceId(devicename);
            if (d > 0)
            {
              int complaintnumber=GetComplaintNumber(d);
              Lblmsg.Text = "Your Complaint number is"+ complaintnumber.ToString();
            }
            else
            {
                Lblmsg.Text = "device not found";
            }
        }
        private int GetComplaintNumber(int deviceid)
        {
            int complaintnumber = 0;
            SqlConnection obj = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnectionstringsNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[sp_add_complaints]";
            cmd.Parameters.Add("@Userid", SqlDbType.Int).Value = Userid;
            cmd.Parameters.Add("@compltdate", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@compltdes", SqlDbType.VarChar).Value = TxtDescription.Text;
            cmd.Parameters.Add("@compltstatus", SqlDbType.VarChar).Value = LblStatus.Text;
            cmd.Parameters.Add("@userclearancedate", SqlDbType.DateTime).Value = TxtClearancedate.Text;
            cmd.Parameters.Add("@complttype", SqlDbType.VarChar).Value = RadioButtonList1.SelectedValue;
            cmd.Parameters.Add("@device_id", SqlDbType.Int).Value = deviceid;
            cmd.Parameters.Add("@compltno", SqlDbType.Int).Value = ParameterDirection.Output;
            try
            {
                obj.Open();
                cmd.Connection = obj;
                cmd.ExecuteNonQuery();
                complaintnumber = (int)cmd.Parameters["@compltno"].Value;
                obj.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Lblexception.Text=ex.StackTrace + ex.Message;
                
            }
            return complaintnumber;
        }
        //private int GetDeviceId(string devicename)
        //{
        //    int deviceid=0;
        //    SqlConnection obj = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnectionstringsNew"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "[dbo].[sp_retrieve_device_id]";
        //    cmd.Parameters.Add("@device_name", SqlDbType.VarChar, 20).Value = devicename;
        //    try
        //    {
        //        obj.Open();
        //        cmd.Connection = obj;
        //        deviceid = (int)cmd.ExecuteScalar();
        //        obj.Close();
        //        cmd.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        Lblexception.Text = ex.StackTrace + ex.Message;
        //    }
        //    return deviceid;
        //}
    }
}