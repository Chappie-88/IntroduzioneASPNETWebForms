using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Introduzione
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void BTNLogin_Click(object sender, EventArgs e)
        {
            bool isValidUser = DAL.validateLogin(TXTUserName.Text, TXTPassword.Text);
            if (isValidUser)
            {
                Session["username"] = TXTUserName.Text;
                //Session["islogged"] = true;
                Response.Redirect("Import.aspx", true);
            }
            LBLOutput.Text = "Non autorizzato";
        }
    }
}