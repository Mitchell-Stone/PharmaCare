/*          Date created = 6 Nov 2018
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
using System.Data.SqlClient;

namespace PharmaCare
{

    public partial class SearchPrescriptions : System.Web.UI.Page
    {
        //List<Prescription> prescription = new List<Prescription>();

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                PresentDataInTheList();
            }
        }

        private void PresentDataInTheList()
        {
            DataTable dt = PrescriptionDB.GetODPprescription();
                    
            gvPrescriptions.DataSource = dt;
            gvPrescriptions.DataBind();           
        }

        protected void dgvPrescriptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDrugs")
            {
                // Get the index of the row
                int index = Convert.ToInt32(e.CommandArgument);

                // Get the value of the prescription id column cell
                int prescriptionId = Convert.ToInt32(gvPrescriptions.Rows[index].Cells[0].Text);

                // Create a data table and bind it to the gridview
                DataTable dt = PrescriptionDB.GetDrugsByPrescriptionID(prescriptionId);
                gvDetailsPrescription.DataSource = dt;
                gvDetailsPrescription.DataBind();
            }
        }
    }
}
