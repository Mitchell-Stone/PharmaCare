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
            

        }
        private void SearchPatientIDbyName()
        {
            int patientID = PatientDB.SearchPatientIDbyName(txtSearchPatient.Text);

        }

    }
}
