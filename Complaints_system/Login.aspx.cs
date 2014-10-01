using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.Security;

namespace Complaints_system
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Txtuname_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Txtpwd_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            if (Txtuname.Text != string.Empty && Txtpwd.Text != string.Empty)
            {
                SqlConnection obj = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnectionstringsNew"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[sp_login]";
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = Txtuname.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = Txtpwd.Text;
                cmd.Parameters.Add("@userid", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@rolename", SqlDbType.VarChar,20).Direction = ParameterDirection.Output;
                string rolename="";
                int Uid;
               try
                {
                    obj.Open();
                    cmd.Connection = obj;
                    cmd.ExecuteNonQuery();
                    Uid=Convert.ToInt32(cmd.Parameters["@userid"].Value);
                   rolename=cmd.Parameters["@rolename"].Value.ToString();
                  
                   CreateCookie(Uid, rolename);
                
                }
                catch (Exception ex)
                {
                    exceplbl.Text = ex.StackTrace + ex.Message;
                }
                finally
                {
                    obj.Close();
                    cmd.Dispose();
                }
               
              
            }
            else
            {
                Lbltxt.Text = "Please make sure that the username and the password is Correct";
            }

          

        }

        private void CreateCookie(int Uid, string rolename)
        {
            FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket(Uid, "empcookie", DateTime.Now, DateTime.Now.AddMinutes(20), false, rolename);
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName,FormsAuthentication.Encrypt(ticket1));
            Response.Cookies.Add(cookie1);
            string returnUrl1="";
            if (Request.QueryString["returnUrl"] == null)
            {
                if (rolename == "employee")
                    returnUrl1 = "EmployeeComplaints.aspx";
                
                else if(rolename == "vendor") 
                    returnUrl1 = "VendorComplaints.aspx";
            }
            else
            {
                returnUrl1 = Request.QueryString["returnUrl"];
            }
            Response.Redirect(returnUrl1);

           

            
        }
    }
}