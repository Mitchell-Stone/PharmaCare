using PharmaCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace PharmaCare
{
    public partial class NursingStationListPharma : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
       
            string CS =ConfigurationManager.ConnectionStrings["PharmaCareDB"].ConnectionString;
            using(SqlConnection con =new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select NursingStationId from IndoorPrescriptions", con);
                con.Open();
                DropDownListNurse.DataSource = cmd.ExecuteReader();
               
                DropDownListNurse.DataTextField = "NursingStationId";
                DropDownListNurse.DataBind();
               
                GridView1.DataBind();
            }
        }
        
        }
        
        
    }

