using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public DataTable GetAdvisorSchedule(string AdvisorID)
    {
        SqlConnection sqlConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["AdvisorbookConnectionString"].ConnectionString);
        System.Data.DataSet ds = new System.Data.DataSet();

        try
        {
            SqlCommand sCommand = new SqlCommand("GetAdvisorCurrentSchedule", sqlConnect);
            sCommand.CommandType = CommandType.StoredProcedure;
            sCommand.CommandTimeout = 30;

            sCommand.Parameters.AddWithValue("@AdvisorID", AdvisorID);
            SqlDataAdapter daAdvisorSchedule = new SqlDataAdapter(sCommand);
            daAdvisorSchedule.Fill(ds, "AdvisorSchedules");
        }
        catch (Exception)
        {
            return null;
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

        return ds.Tables["AdvisorSchedules"]; ;
    }
}
