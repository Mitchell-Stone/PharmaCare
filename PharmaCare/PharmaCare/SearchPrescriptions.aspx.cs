/* 
 *          Page Create By Hsuan-Yi Lin(a.k.a Alex Pasalic) 
 *
 *          Student ID= 452400286
 *
 */
using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PharmaCare
{

    public partial class SearchPrescriptions : System.Web.UI.Page
    {
        List<Prescription> prescription = new List<Prescription>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PresentDataInTheList("All");
            }
        }
        
        protected void BtnFindPatient_Click(object sender, EventArgs e)
        {
            string search = txtSearchPatient.Text;

        }
        private void PresentDataInTheList (string status)
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
        }
    }
}
