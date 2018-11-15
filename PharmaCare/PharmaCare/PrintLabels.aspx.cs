using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = PharmaCareDB.GetLocalConnection();
            try
            {
                con.Open();
                SqlDataReader reader = PrescriptionDB.LabelsToPrint(con);
                gvLabelList.DataSource = reader;
                gvLabelList.DataBind();
            }
            catch (Exception)
            {

                throw;
            }          
        }

        protected void gvLabelList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}