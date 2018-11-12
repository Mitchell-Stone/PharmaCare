using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{

    public partial class SearchPrescriptions : System.Web.UI.Page
    {
        private object patient;
        List<Prescription> prescription = new List<Prescription>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DgvPrescriptions_PreRender(object sender, EventArgs e)
        {
            if (dgvPrescriptions.HeaderRow != null)
            {
                dgvPrescriptions.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void BtnFindPatient_Click(object sender, EventArgs e)
        {
            string search = txtSearchPatient.Text;

        }
        private void GetPatientByName(string PatientID)
        {
            try
            {
                //patient = PatientDB.getPatientByName();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
