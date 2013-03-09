using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

public partial class AdvisorSchedule : System.Web.UI.Page
{
    #region Private

    [Serializable]
    private class MergedColumnsInfo
    {
        // indexes of merged columns
        public List<int> MergedColumns = new List<int>();
        // key-value pairs: key = first column index, value = number of merged columns
        public Hashtable StartColumns = new Hashtable();
        // key-value pairs: key = first column index, value = common title of merged columns 
        public Hashtable Titles = new Hashtable();

        //parameters: merged columns's indexes, common title of merged columns 
        public void AddMergedColumns(int[] columnsIndexes, string title)
        {
            MergedColumns.AddRange(columnsIndexes);
            StartColumns.Add(columnsIndexes[0], columnsIndexes.Length);
            Titles.Add(columnsIndexes[0], title);
        }
    }

    //property for storing of information about merged columns
    private MergedColumnsInfo info
    {
        get
        {
            if (ViewState["info"] == null)
                ViewState["info"] = new MergedColumnsInfo();
            return (MergedColumnsInfo)ViewState["info"];

        }
    }

    //method for rendering of columns's headers	
    private void RenderHeader(HtmlTextWriter output, Control container)
    {
        for (int i = 0; i < container.Controls.Count; i++)
        {
            TableCell cell = (TableCell)container.Controls[i];
            //stretch non merged columns for two rows
            if (!info.MergedColumns.Contains(i))
            {
                cell.Attributes["rowspan"] = "2";
                cell.RenderControl(output);
            }
            else //render merged columns's common title
                if (info.StartColumns.Contains(i))
                {
                    output.Write(string.Format("<th align='center' colspan='{0}'>{1}</th>",
                             info.StartColumns[i], info.Titles[i]));
                }
        }

        //close first row	
        output.RenderEndTag();
        //set attributes for second row
        gvAdvisorSchedule.HeaderStyle.AddAttributesToRender(output);
        //start second row
        output.RenderBeginTag("tr");

        //render second row (only merged columns)
        for (int i = 0; i < info.MergedColumns.Count; i++)
        {
            TableCell cell = (TableCell)container.Controls[info.MergedColumns[i]];
            cell.RenderControl(output);
        }
    }

    #endregion

   

    private const int _firstEditCellIndex = 2;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //merge the second, third and fourth columns with common title "Subjects"
            info.AddMergedColumns(new int[] { 2, 3}, "8:00 AM");
            info.AddMergedColumns(new int[] { 4, 5 }, "9:00 AM");
            info.AddMergedColumns(new int[] { 6, 7 }, "10:00 AM");
            info.AddMergedColumns(new int[] { 8, 9 }, "11:00 AM");
            info.AddMergedColumns(new int[] { 10, 11 }, "12:00 PM");
            info.AddMergedColumns(new int[] { 12, 13 }, "1:00 PM");
            info.AddMergedColumns(new int[] { 14, 15 }, "2:00 PM");
            info.AddMergedColumns(new int[] { 16, 17 }, "3:00 PM");
            info.AddMergedColumns(new int[] { 18, 19 }, "4:00 PM");
            //info.AddMergedColumns(new int[] { 2, 3 }, "8:00 AM");

            GetAdvisorSchedule("100");
        }
        //if (!IsPostBack)
        //{
        //    _sampleData = null;
        //   // this.gvAdvisorSchedule.DataSource = _sampleData;
        //   // this.gvAdvisorSchedule.DataBind();
        //}

        //if (this.gvAdvisorSchedule.SelectedIndex > -1)
        //{
        //    // Call UpdateRow on every postback
        //    this.gvAdvisorSchedule.UpdateRow(this.gvAdvisorSchedule.SelectedIndex, false);
        //}      


    }

    protected void btnEditSchedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdvisorAvailability.aspx");
    }

    public void GetAdvisorSchedule(string AdvisorID)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorbookConnectionString"].ConnectionString);
        DataTable dtAdvisorSchedule = new  DataTable();

        try
        {
            //SqlCommand sCommand = new SqlCommand("GetAdvisorCurrentSchedule", sqlConnect);
            //sCommand.CommandType = CommandType.StoredProcedure;
            //sCommand.CommandTimeout = 30;

            //sCommand.Parameters.AddWithValue("@AdvisorID", AdvisorID);
            //SqlDataAdapter daAdvisorSchedule = new SqlDataAdapter(sCommand);
            //daAdvisorSchedule.Fill(dtAdvisorSchedule);

            gvAdvisorSchedule.DataSource = _sampleData;
            gvAdvisorSchedule.DataBind();

            DataTable dtSchedule = _sampleData;

            //if (dtSchedule == null)
            //{
            //    foreach (DataRow dr in dtSchedule.Rows)
            //    { 
            //        gvAdvisorSchedule.Rows.add(
            //        foreach
                
            //    }


            //    dt.Columns.Add(new DataColumn("AdvisorSchuduleID", typeof(int)));
            //    dt.Columns.Add(new DataColumn("Day", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Week", typeof(string)));
            //    dt.Columns.Add(new DataColumn("Year", typeof(string)));
            //    dt.Columns.Add(new DataColumn("StartTime", typeof(string)));
            //    dt.Columns.Add(new DataColumn("EndTime", typeof(string)));

            //    dt.Rows.Add(new object[] { 1, "Mondy", 4, 2013, "9:00", "12:30"});
            //    dt.Rows.Add(new object[] { 2, "Mondy", 4, 2013, "14:00", "15:30" });

            //    // Add the id column as a primary key
            //    DataColumn[] keys = new DataColumn[1];
            //    keys[0] = dt.Columns["AdvisorSchuduleID"];
            //    dt.PrimaryKey = keys;

            //    _sampleData = dt;
            //}























           // gvAdvisorSchedule.ce
        }
        catch (Exception)
        {
           // return null;
        }
        finally
        {
            if (sqlConnect != null)
            {
                if (sqlConnect.State == ConnectionState.Open)
                {
                    sqlConnect.Close();
                    sqlConnect.Dispose();
                    sqlConnect = null;

                }
            }
        }
    }


     #region gvAdvisorSchedule

    protected void gvAdvisorSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the LinkButton control in the first cell
            LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
            // Get the javascript which is assigned to this LinkButton
            string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");

            // If the page contains validator controls then call 
            // Page_ClientValidate before allowing a cell to be edited
            if (Page.Validators.Count > 0)
                _jsSingle = _jsSingle.Insert(11, "if(Page_ClientValidate())");

            // Add events to each editable cell
            for (int columnIndex = _firstEditCellIndex; columnIndex < e.Row.Cells.Count; columnIndex++)
            {
                // Add the column index as the event argument parameter
                string js = _jsSingle.Insert(_jsSingle.Length - 2, columnIndex.ToString());
                // Add this javascript to the onclick Attribute of the cell
                e.Row.Cells[columnIndex].Attributes["onclick"] = js;
                // Add a cursor style to the cells
                e.Row.Cells[columnIndex].Attributes["style"] += "cursor:pointer;cursor:hand;";
            }
        }
    }

    protected void gvAdvisorSchedule_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView _gridView = (GridView)sender;

        switch (e.CommandName)
        {
            case ("SingleClick"):
                // Get the row index
                int _rowIndex = int.Parse(e.CommandArgument.ToString());
                // Parse the event argument (added in RowDataBound) to get the selected column index
                int _columnIndex = int.Parse(Request.Form["__EVENTARGUMENT"]);
                // Set the Gridview selected index
                _gridView.SelectedIndex = _rowIndex;
                // Bind the Gridview
                //_gridView.DataSource = _sampleData;
                //_gridView.DataBind();

                // Write out a history if the event
                //this.Message.Text += "Single clicked GridView row at index " + _rowIndex.ToString() + " on column index " + _columnIndex + "<br />";

                // Get the display control for the selected cell and make it invisible
                Control _displayControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[1];
                _displayControl.Visible = false;
                // Get the edit control for the selected cell and make it visible
                Control _editControl = _gridView.Rows[_rowIndex].Cells[_columnIndex].Controls[3];
                _editControl.Visible = true;
                // Clear the attributes from the selected cell to remove the click event
                _gridView.Rows[_rowIndex].Cells[_columnIndex].Attributes.Clear();

                // Set focus on the selected edit control
                ScriptManager.RegisterStartupScript(this, GetType(), "SetFocus",
                    "document.getElementById('" + _editControl.ClientID + "').focus();", true);
                // If the edit control is a dropdownlist set the
                // SelectedValue to the value of the display control
                if (_editControl is DropDownList && _displayControl is Label)
                {
                    ((DropDownList)_editControl).SelectedValue = ((Label)_displayControl).Text;
                }
                // If the edit control is a textbox then select the text
                if (_editControl is TextBox)
                {
                    ((TextBox)_editControl).Attributes.Add("onfocus", "this.select()");
                }
                // If the edit control is a checkbox set the
                // Checked value to the value of the display control
                if (_editControl is CheckBox && _displayControl is Label)
                {
                    ((CheckBox)_editControl).Checked = bool.Parse(((Label)_displayControl).Text);
                }

                break;
        }
    }

    protected void gvAdvisorSchedule_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //call the method for custom rendering of columns's headers	
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.SetRenderMethodDelegate(RenderHeader);

    } 
     
     
     #endregion

        #region Sample Data

    /// <summary>
    /// Property to manage data
    /// </summary>
    private DataTable _sampleData
    {
        get
        {
            DataTable dt = (DataTable)Session["TestData"];

            if (dt == null)
            {
                // Create a DataTable and save it to session
                dt = new DataTable();

                dt.Columns.Add(new DataColumn("AdvisorSchuduleID", typeof(int)));
                dt.Columns.Add(new DataColumn("Day", typeof(string)));
                dt.Columns.Add(new DataColumn("Week", typeof(string)));
                dt.Columns.Add(new DataColumn("Year", typeof(string)));
                dt.Columns.Add(new DataColumn("StartTime", typeof(string)));
                dt.Columns.Add(new DataColumn("EndTime", typeof(string)));

                dt.Rows.Add(new object[] { 1, "Mondy", 4, 2013, "9:00", "12:30"});
                dt.Rows.Add(new object[] { 2, "Mondy", 4, 2013, "14:00", "15:30" });

                // Add the id column as a primary key
                DataColumn[] keys = new DataColumn[1];
                keys[0] = dt.Columns["AdvisorSchuduleID"];
                dt.PrimaryKey = keys;

                _sampleData = dt;
            }

            return dt;
        }
        set
        {
            Session["TestData"] = value;
        }
    }

    #endregion    



}