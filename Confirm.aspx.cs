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

        try { if (Session["date"].ToString() == null);if (Session["ID"].ToString() == null);}
        catch{ Server.Transfer("Advisor.aspx"); }
        
        int advisorId = Convert.ToInt16(Session["ID"].ToString());
        string date = Session["date"].ToString();
        ronUtil get = new ronUtil(advisorId);
        DateTime datev2 = DateTime.ParseExact(Session["date"].ToString(), "MM/dd/yyyy", null);


        

        
        
                  DateTime[] advisorAllSlots = get.getSlots(advisorId);
        DateTime[] taken = get.getTaken(advisorId, datev2.ToString("yyyy-MM-dd"));
        DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
        string[] shorttime = new string[availibility.Length];
        for (int i = 0; i < availibility.Length; i++)
        { shorttime[i] = availibility[i].ToShortTimeString(); }
        Label2.Text = get.FullName;
        Label3.Text = "AdvisorID:" + Session["ID"].ToString(); 
        Label1.Text = "Date:" + Session["date"].ToString();
        
        DropDownList1.DataSource = shorttime;
        DropDownList1.DataBind();
            


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
