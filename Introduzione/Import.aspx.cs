using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Introduzione
{
    public partial class Import : System.Web.UI.Page
    {
        //alle 19.15 faremo insieme la parte di edit !!

        /*
         implementare funzionalità di edit/delete:
            DELETE:
                - al click settare il campo Deleted sul DB come true
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("Default.aspx", true);
            LBLWelcome.Text = "Logged as: " + Session["username"].ToString();
            generatePersonsTable();
        }

        protected void BTNSubmit_Click(object sender, EventArgs e)
        {
            Person persona = new Person();
            persona.Nome = TXTNome.Text;
            persona.Cognome = TXTCognome.Text;
            persona.Eta = TXTEta.Text;
            persona.Username = TXTUsername.Text;
            persona.Password = TXTPassword.Text;
            DAL.insertPerson(persona);
            generatePersonsTable();
        }

        private void generatePersonsTable()
        {
            TBLPerson.Rows.Clear();
            TableRow headerRow = new TableRow();
            TableCell nameHeaderCell = new TableCell();
            TableCell lastNameHeaderCell = new TableCell();
            TableCell ageHeaderCell = new TableCell();
            nameHeaderCell.Text = "Nome";
            lastNameHeaderCell.Text = "Cognome";
            ageHeaderCell.Text = "Età";
            headerRow.Style.Add("font-weight", "bold");
            headerRow.Cells.Add(nameHeaderCell);
            headerRow.Cells.Add(lastNameHeaderCell);
            headerRow.Cells.Add(ageHeaderCell);
            TBLPerson.Rows.Add(headerRow);
            TBLPerson.Attributes.Add("class", "table");

            List<Person> persone = DAL.getAllPersons();
            foreach (Person p in persone)
            {
                TableRow row = new TableRow();
                TableCell nameCell = new TableCell();
                TableCell lastNamecell = new TableCell();
                TableCell ageCell = new TableCell();
                TableCell editButtonCell = new TableCell();
                nameCell.Text = p.Nome;
                lastNamecell.Text = p.Cognome;
                ageCell.Text = p.Eta;
                Button editButton = new Button();
                editButton.ID = p.ID.ToString();
                editButton.Text = "Edit";
                editButton.Click += this.EditButton_Click;
                editButton.Attributes.Add("class", "btn btn-warning btn-sm");
                editButtonCell.Controls.Add(editButton);
                row.Cells.Add(nameCell);
                row.Cells.Add(lastNamecell);
                row.Cells.Add(ageCell);
                row.Cells.Add(editButtonCell);
                TBLPerson.Rows.Add(row);
            }
            TBLPerson.DataBind();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Session["EditUserID"] = ((Button)sender).ID;
            Response.Redirect("EditUser.aspx", true);
        }
    }
}