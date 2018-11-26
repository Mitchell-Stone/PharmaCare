/*
 *      Date Created = 1st November 2018
 *      Created By = Kyle
 *      Purpose = To interact with the ScheduleDB Class and return data.
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
            btnPrintbtn.Visible = false;
        }

        protected void NurseStationSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void ddlNurseStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlNurseStations.SelectedIndex != 0)
            {
                ddlNurseStations.Items.FindByText("Please select a Nursing Station").Enabled = false;
                btnPrintbtn.Visible = true;
            }
            // Call user defined method
            NursingStationID = ddlNurseStations.SelectedValue;
            ScheduleDB BindData = new ScheduleDB(NursingStationID, scheduleList);
        }
    }
}