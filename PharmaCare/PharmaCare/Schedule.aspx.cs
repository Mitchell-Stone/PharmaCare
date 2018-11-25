/*
 *      Date Created = 1st November 2018
 *      Created By = 
 *      Purpose = 
 *      Bugs = No known bugs
 */

using PharmaCare.Models;
using System;
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