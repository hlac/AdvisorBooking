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

        ronUtil2 get = new ronUtil2();
        int[] ID = get.getAdvisorIDs();

        for (int ii = 0; ii < ID.Length; ii++)
        {
            TableCell[] td = new TableCell[8];
            HyperLink link = new HyperLink();
            link.NavigateUrl = "~/Calendar.aspx?ID=" + ID[ii];
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


    protected void erow_c(object sender, GridViewRowEventArgs e)
    {
        //e.Row.Cells[5].Visible = false;
    }
}
