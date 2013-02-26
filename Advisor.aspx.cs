using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        ronUtil get= new ronUtil();
        GridView1.DataSource = get.loadAdvisorsToGrid();        
        GridView1.DataBind();


        //if (Session["Student"] == null)
        //{ Server.Transfer("Advisor.aspx"); }
    }


    protected void erow_c(object sender, GridViewRowEventArgs e)
    {
       e.Row.Cells[5].Visible = false;
    }
}
