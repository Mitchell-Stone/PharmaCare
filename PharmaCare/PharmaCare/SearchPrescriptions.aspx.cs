﻿/*          Date created = 6 Nov 2018
 *          Page Create By Hsuan-Yi Lin(a.k.a Alex Pasalic) 
 *          purpose = to present the view page function for out door patient for the staff
 *          Student ID= 452400286
 *          Known bugs= sorting function might not work in some of the fields.
 */
using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;

namespace PharmaCare
{

    public partial class SearchPrescriptions : System.Web.UI.Page
    {
        //List<Prescription> prescription = new List<Prescription>();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            // if (!IsPostBack)
            //  {
            // PresentDataInTheList("All");
            // }
        }

        protected void BtnFindPatient_Click(object sender, EventArgs e)
        {
            //string search = txtSearchPatient.Text;


        }

        protected void dgvPrescriptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*private void PresentDataInTheList (string status)
{
SqlConnection con = PharmaCareDB.GetConnection();
List<string> tempList = new List<string>();

try
{
con.Open();
if (status == "All")
{
  SqlDataReader reader = PrescriptionDB.GetODPprescription(con, status);
  dgvPrescriptions.DataSource = reader;
  dgvPrescriptions.DataBind();
}
}
catch (SqlException ex)
{
throw ex;
}
finally
{
con.Close();
}
}*/
    }
}
