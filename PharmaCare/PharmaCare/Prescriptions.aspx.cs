using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class Prescriptions : System.Web.UI.Page
    {
        List<Patient> patient = new List<Patient>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPatients_Click(object sender, EventArgs e)
        {
            this.GetAllPatients();
            this.DisplayPatients();
        }

        private void GetAllPatients()
        {
            try
            {
                patient = PatientDB.GetAllPatients();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DisplayPatients()
        {
            txtPatients.Text = patient.ToString();
        }
    }
}