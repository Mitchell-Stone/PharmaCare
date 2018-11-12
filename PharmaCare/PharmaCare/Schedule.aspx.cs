using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string NursingStationID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NursingStationID = ddlNurseStations.SelectedValue;
                ScheduleDB BindData = new ScheduleDB(NursingStationID, scheduleList);
            }
        }

        protected void NurseStationSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ddlNurseStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            NursingStationID = ddlNurseStations.SelectedValue;
            ScheduleDB BindData = new ScheduleDB(NursingStationID, scheduleList);
        }
    }
}