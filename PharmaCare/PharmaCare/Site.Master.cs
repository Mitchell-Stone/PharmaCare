/*
 *      Date Created = 20th October 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This is the master page for the entire site and manages the header and footer content for each page
 *      Bugs = No known bugs
 */

using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PharmaCare
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // do on initial load
            {
                // loop the navigation li tags to mark the active page 
                foreach (Control ctl in navList.Controls)
                {
                    if (ctl is HtmlGenericControl)
                    {
                        // get the current li tag and its child <a> tag
                        var li = (HtmlGenericControl)ctl;
                        var a = (HyperLink)li.Controls[1];

                        // if the current navigation li tag is the active page...
                        if (Page.AppRelativeVirtualPath.Contains(a.NavigateUrl))
                        {
                            // set Bootstrap active class
                            li.Attributes.Add("class", "active");

                            return; // exit loop because we've marked the current navigation link as active 
                        }
                    }
                }
            }
        }
    }
}