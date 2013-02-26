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
        Session["date"] = null;
        Session["ID"] = null;
        Session["Student"] = null;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ronUtil get=new ronUtil();

        if (get.getCheck(txtStudentID.Text.ToString()) == false)
            Response.Write("<script type='text/javascript'>alert('You are already booked');</script>");
        else
        {
            Session["Student"] = txtStudentID.Text.ToString();
            Server.Transfer("Advisor.aspx");
        }

    }

}