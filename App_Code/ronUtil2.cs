using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
/// <summary>
/// Summary description for ronUtil2
/// </summary>
public class ronUtil2
{


    public string[] DaysAvailable { get; set; }
    public string FullName { get; set; }

    public ronUtil2()
    {
     
    }

	public ronUtil2( int id)
	{
        DaysAvailable = getDaysAvailable(id);

        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select First_Name,Last_Name From Advisor Where Employee_ID='" + id.ToString() + "'";


        DataView view3 = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table3 = view3.ToTable();


        FullName = table3.Rows[0][0].ToString() + " " + table3.Rows[0][1].ToString();


	}


    public string getName(int advisor_Id)
    {
        string advisorNames = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select (Last_Name+', ' + First_Name) As Name From Advisor Where Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { advisorNames = table.Rows[0][0].ToString(); }
        return advisorNames;
    }


    public string getDepartment(int advisor_Id)
    {
        string department = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select Dept_Name  From Advisor,Department Where Advisor.Dept_Id=Department.Dept_Id AND Employee_ID='" + advisor_Id + "'";
        

        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { department = table.Rows[0][0].ToString(); }

        return department;
    }



    public string getMonday(int advisor_Id)
    {
        string Monday = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (CONVERT(varchar, Time_Start, 100)+ '-'+CONVERT(varchar, Time_End, 100)) As Time From Availability Where DayAvailable='Monday' AND Employee_ID='" + advisor_Id + "'";


        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { Monday = table.Rows[0][0].ToString();
    
        }
        return Monday;
    }


    public string getTuesday(int advisor_Id)
    {
        string Tuesday = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (CONVERT(varchar, Time_Start, 100)+ '-'+CONVERT(varchar, Time_End, 100)) As Time From Availability Where DayAvailable='Tuesday' AND Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        {            Tuesday = table.Rows[0][0].ToString();        }
        return Tuesday;
    }

    public string getWednesday(int advisor_Id)
    {
        string Wednesday = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (CONVERT(varchar, Time_Start, 100)+ '-'+CONVERT(varchar, Time_End, 100)) As Time From Availability Where DayAvailable='Wednesday' AND Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        {Wednesday = table.Rows[0][0].ToString();}
        return Wednesday;
    }

    public string getThursday(int advisor_Id)
    {
        string Thursday = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (CONVERT(varchar, Time_Start, 100)+ '-'+CONVERT(varchar, Time_End, 100)) As Time From Availability Where DayAvailable='Thursday' AND Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { Thursday = table.Rows[0][0].ToString(); }
        return Thursday;
    }

    public string getFriday(int advisor_Id)
    {
        string Friday = "-";
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource2.SelectCommand = "Select (CONVERT(varchar, Time_Start, 100)+ '-'+CONVERT(varchar, Time_End, 100)) As Time From Availability Where DayAvailable='Friday' AND Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        if (table.Rows.Count > 0)
        { Friday = table.Rows[0][0].ToString(); }
        return Friday;
    }




    public DateTime[] getSlots(int advisor_Id, string date)
    { //inttime = total available time slots as int
        //doubletime = total available time slots as double
        DateTime dtdate = DateTime.Parse(date);
        SqlDataSource SqlDataSource = new SqlDataSource();
        SqlDataSource.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource.SelectCommand = "Select Time_Start,Time_End From Availability Where DayAvailable='" + dtdate.DayOfWeek.ToString() + "' And Employee_ID='" + advisor_Id + "'";
        DataView view = (DataView)SqlDataSource.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

      
            DateTime start = DateTime.Parse(table.Rows[0][0].ToString());
            DateTime end = DateTime.Parse(table.Rows[0][1].ToString());
               
            double dbltime = ((end - start).TotalHours) * 2;

            int inttime = Convert.ToInt32(dbltime);

            DateTime[] advisorSlots = new DateTime[inttime];

            for (int i = 0; i < inttime; i++)
            {

                advisorSlots[i] = start;
                start = start.AddMinutes(30);
            }                      
        
        return advisorSlots;
    }


    public DateTime[] getTaken(int advisor_Id, string date)
    {
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select Time From Appointment,Availability  Where Appointment.Availability_Id=Availability.Availability_Id AND Employee_ID='" + advisor_Id + "' AND Date='" + date + "'";
        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        DateTime[] slotsTaken = new DateTime[table.Rows.Count];

        for (int ii = 0; ii < table.Rows.Count; ii++)
        { slotsTaken[ii] = DateTime.Parse(table.Rows[ii][0].ToString()); }

        return slotsTaken;
    }





    public DateTime[] getAvailability(DateTime[] advisorAllSlots, DateTime[] taken)
    {

        int length = advisorAllSlots.Length - taken.Length;
        DateTime[] slots = advisorAllSlots;
        DateTime[] available = new DateTime[length];

        int counter = 0; int counter1 = 0;
        if (taken.Length == 0)
        { available = advisorAllSlots; }
        else
        {
            for (int i = 0; i < advisorAllSlots.Length; i++)
            {

                for (int ii = 0; ii < taken.Length; ii++)
                {
                    if (advisorAllSlots[i].ToShortTimeString() == taken[ii].ToShortTimeString())
                    {
                        slots[i] = DateTime.Now;

                    }

                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] != DateTime.Now)
                { available[counter1] = slots[i]; counter1++; }
            }


        }
        return available;

    }



    public int[] getAdvisorIDs()
    {
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select Employee_ID From Advisor";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];

        int[] Employee_ID = new int[table.Rows.Count];

        for (int ii = 0; ii < table.Rows.Count; ii++)
        { Employee_ID[ii] = Convert.ToInt16(table.Rows[ii][0].ToString()); }
        return Employee_ID;
    }


    public string[] getDaysAvailable(int id)
    {
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select Distinct(DayAvailable) From Availability Where Employee_Id='" + id + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        string[] days = new string[table.Rows.Count];
        for (int ii = 0; ii < table.Rows.Count; ii++)
        { days[ii] = table.Rows[ii][0].ToString(); }
        return days;
    }

    public int getAvailableID(int advisor_Id, string date)
    {
        DateTime datev2 = DateTime.Parse(date);
        SqlDataSource SqlDataSource2 = new SqlDataSource();
        SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        SqlDataSource2.SelectCommand = "Select Availability_ID From Availability  Where Employee_ID='" + advisor_Id + "' AND DayAvailable='" + datev2.DayOfWeek.ToString() + "'";
        DataView view = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        int AvailabilityID=0;
        if (table.Rows.Count > 0)
        AvailabilityID = Convert.ToInt16(table.Rows[0][0].ToString()); 

        return AvailabilityID;
    }


    public bool getCheck(int stID)
    {
        int Student_Id = Convert.ToInt32(stID);
        DateTime date = DateTime.Now;
        SqlDataSource SqlDataSource3 = new SqlDataSource();
        SqlDataSource3.ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        SqlDataSource3.SelectCommand = "Select Time From Appointment  Where Student_Id='" + Student_Id + "' AND Date>'" + date + "'";

        DataView view = (DataView)SqlDataSource3.Select(DataSourceSelectArguments.Empty);
        DataTable table = view.ToTable();

        //   string[] slotsTaken = new string[table.Rows.Count];
        bool check = false;
        if (table.Rows.Count == 0)
        { check = true; }

        return check;
    }

}