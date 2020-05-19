using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Introduzione
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EditUserID"] == null)
                Response.Redirect("Default.aspx", true);
            else if (!IsPostBack)
            {
                Person person = DAL.getPersonByID(Guid.Parse(Session["EditUserID"].ToString()));
                if (person != null)
                {
                    TXTNome.Text = person.Nome;
                    TXTCognome.Text = person.Cognome;
                    TXTEta.Text = person.Eta;
                    TXTUsername.Text = person.Username;
                    TXTPassword.Text = person.Password;
                }
                LBLWelcome.Text = "Editing user: " + person.Username + " (" + person.ID + ")";
            }
        }
        protected void BTNSubmit_Click(object sender, EventArgs e)
        {
            if (Session["EditUserID"] != null)
            {
                Person persona = new Person();
                persona.ID = Guid.Parse(Session["EditUserID"].ToString());
                persona.Nome = TXTNome.Text;
                persona.Cognome = TXTCognome.Text;
                persona.Eta = TXTEta.Text;
                persona.Username = TXTUsername.Text;
                persona.Password = TXTPassword.Text;
                LBLOutput.Text = DAL.updatePerson(persona);
            }
        }
        protected void BTNBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Import.aspx", true);
        }
    }
}