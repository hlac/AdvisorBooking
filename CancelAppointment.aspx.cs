using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class CancelAppointment : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try { txtStudentID.Text = Session["StudentId"].ToString(); }
        catch { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
     }

    public void clear()
    {

      

    }
    protected void btnCheck_click(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       

        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ronUtil2 get = new ronUtil2();
        get.CancelAppointment(Session["StudentID"].ToString());

        if (Request.QueryString["AdvisorID"]!=null)
            Server.Transfer("Schedule.aspx");
        else
            Server.Transfer("Advisor.aspx");

        
    }
}