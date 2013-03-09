using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
 //A global variable that will hold the current number of Rows
    //We set the values to 1 so that it will generate a default Row when the page loads
    private int numOfRows = 1;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        ronUtil2 get = new ronUtil2();
        Label1.Text = get.getName(100);
        Label2.Text = get.getDepartment(100);
        Label3.Text = get.getMonday(100);
        Label4.Text = get.getTuesday(100);
        Label5.Text = get.getWednesday(100);
        Label6.Text = get.getThursday(100);
        Label7.Text = get.getFriday(100);
        Label8.Text = get.getAvailableID(100, "03/05/2013").ToString();


        DateTime[] time= get.getSlots(100,"03/04/2013");
        DropDownList1.DataSource = time;
        DropDownList1.DataBind();

        DateTime[] time2 = get.getTaken(100, "03/04/2013");
        DropDownList2.DataSource = time2;
        DropDownList2.DataBind();


        DateTime[] time3 = get.getAvailability(time, time2);
        DropDownList3.DataSource = time3;
        DropDownList3.DataBind();


        string[] time5 = get.getDaysAvailable(100);
        DropDownList5.DataSource = time5;
        DropDownList5.DataBind();

        

        //ronUtil2 get = new ronUtil2();
        int[] ID = get.getAdvisorIDs();
        DropDownList4.DataSource = ID;
        DropDownList4.DataBind();

        for (int ii = 0; ii < ID.Length; ii++)
        {
            TableCell[] td = new TableCell[8];
            HyperLink link = new HyperLink();
            link.NavigateUrl = "~/Calendar.aspx?ID="+ID[ii];
            for (int i = 0; i < 8; i++) { td[i] = new TableCell(); }

            link.Text = get.getName(ID[ii]);
            td[0].Controls.Add(link);
            td[1].Text = get.getDepartment(ID[ii]);
            td[2].Text = get.getMonday(ID[ii]);
            td[3].Text = get.getTuesday(ID[ii]);
            td[4].Text = get.getWednesday(ID[ii]);
            td[5].Text = get.getThursday(ID[ii]);
            td[6].Text = get.getFriday(ID[ii]);

            TableRow tRow = new TableRow();
            myTable.Rows.Add(tRow);
            tRow.Cells.AddRange(td);
        }


    }
 

    
}