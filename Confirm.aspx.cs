using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Prwvent excepts,corruptions.

            if (Session["date"] == null || Session["ID"] == null)
            {
                Server.Transfer("Advisor.aspx");
            }

        
        int advisorId = Convert.ToInt16(Session["ID"].ToString());
        string date = Session["date"].ToString();
        ronUtil get = new ronUtil(advisorId);
        DateTime datev2 = DateTime.ParseExact(Session["date"].ToString(), "MM/dd/yyyy", null);
        DateTime[] advisorAllSlots = get.getSlots(advisorId, datev2.ToString("yyyyMMdd"));
        DateTime[] taken = get.getTaken(advisorId, datev2.ToString("yyyy-MM-dd"));
        DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);
        string[] shorttime = new string[availibility.Length];
        for (int i = 0; i < availibility.Length; i++)
        { shorttime[i] = availibility[i].ToShortTimeString(); }
        Label3.Text = "For Advisor: " + get.FullName;
        Label2.Text = "Your StudentID: " + Session["Student"].ToString(); ; 
        Label1.Text = "Date:" + Session["date"].ToString();
      

            DropDownList1.DataSource = shorttime;
            if (!IsPostBack)
            { DropDownList1.DataBind(); }

            
            if (availibility.Length==0)
            {Response.Write("<script type='text/javascript'>alert('It is fully booked.');</script>");
                Server.Transfer("Calendar.aspx");}
            

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Prevent corruption. Double check availability. Delete cookies
        if (Session["date"] != null && Session["ID"] != null)
        {
            int advisorId = Convert.ToInt16(Session["ID"].ToString());
            string date = Session["date"].ToString();
            Session["date"] = null;
            Session["ID"] = null;
            ronUtil get = new ronUtil(advisorId);
            DateTime datev2 = DateTime.ParseExact(date, "MM/dd/yyyy", null);
            DateTime[] advisorAllSlots = get.getSlots(advisorId, datev2.ToString("yyyyMMdd"));
            DateTime[] taken = get.getTaken(advisorId, datev2.ToString("yyyy-MM-dd"));
            DateTime[] availibility = get.getAvailability(advisorAllSlots, taken);

            Session["date"] = null;
            

            bool proceed = false;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (DropDownList1.SelectedValue.ToString() == availibility[i].ToShortTimeString())
                {
                    proceed = true;
                }
            }

            if (proceed == true)
            {
                DateTime picked = new DateTime();
                picked = DateTime.ParseExact(DropDownList1.SelectedValue.ToString(), "h:mm tt", CultureInfo.InvariantCulture);

                int Student_Id = 822459073;
                int Advisor_Id = advisorId;
                string Time = picked.ToString("HH:mm:ss");
                string Date = datev2.ToString("yyyy-MM-dd");
                Label1.Text = Time;
                string Comments = TextArea1.Value.ToString();
                int Completed = 0;


                string sqlQuery = "INSERT INTO Scheduling (Student_Id,Advisor_Id,Time,Date,Comments,Completed)";
                sqlQuery += " VALUES (@Student_Id,@Advisor_Id,@Time,@Date,@Comments,@Completed)";
                string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
                using (SqlConnection dataConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand dataCommand = new SqlCommand(sqlQuery, dataConnection))
                    {

                        dataCommand.Parameters.AddWithValue("Student_Id", Student_Id);
                        dataCommand.Parameters.AddWithValue("Advisor_Id", Advisor_Id);
                        dataCommand.Parameters.AddWithValue("Time", Time);
                        dataCommand.Parameters.AddWithValue("Date", Date);
                        dataCommand.Parameters.AddWithValue("Comments", Comments);
                        dataCommand.Parameters.AddWithValue("Completed", Completed);

                        dataConnection.Open();
                        dataCommand.ExecuteNonQuery();
                        dataConnection.Close();
                    }
                }

                Response.Write("<script type='text/javascript'>alert('You are booked');</script>");
                Server.Transfer("Advisor.aspx");
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('Something went wrong. Try again later');</script>");
                Server.Transfer("Advisor.aspx");
            }


        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
