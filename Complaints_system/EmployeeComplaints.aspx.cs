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

namespace Complaints_system
{
    public partial class EmployeeComplaints : System.Web.UI.Page
    {
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

            DataSet temp = GetComplaintDetails(userid);
            BindtoGrid(temp);
        }

        private DataSet GetComplaintDetails(int userid)
        {
            DataSet ds = new DataSet();
            SqlConnection obj = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnectionstringsNew"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[sp_employee_retrieve_complaints]";
            cmd.Parameters.Add("@Userid", SqlDbType.Int).Value = userid;
            try
            {
                obj.Open();
                cmd.Connection = obj;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                obj.Close();
                cmd.Dispose();
            }
            catch (Exception ex)
            {

            }
            return ds;
        }

        private void BindtoGrid(DataSet dst)
        {
            gvComplaints.DataSource = dst;
            gvComplaints.DataBind();
        }


    }
}
    
