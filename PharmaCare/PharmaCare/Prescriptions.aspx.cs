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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DgvPatients_PreRender(object sender, EventArgs e)
        {
            if (DgvPatients.HeaderRow != null)
            {
                DgvPatients.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}