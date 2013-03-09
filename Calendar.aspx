<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Default3" %>
<script runat=server>
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["ID"] == null)
        //{
        //    Server.Transfer("Advisor.aspx");
        //}
        
        ronUtil2 get = new ronUtil2(Convert.ToInt16(Request.QueryString["ID"]));

        //Label1.Text = "Advisor:" + get.FullName ;

        Session["Student"] = 822459053;

        

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
       
    }
    
    </script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <% Session["date"] = Calendar1.SelectedDate.ToString("MM/dd/yyyy"); %>
    <% Session["ID"] = Request.QueryString["ID"]; %>
    
        <div class="post" id="post-5">
    <div class="post-title">
            <center>
                <h2>
                    <a href="#">Book An Advisor</a></h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                <br />

      <div style="margin:0 auto; text-align:center; Width:401px">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
            BorderColor="Black" Font-Names="Times New Roman" 
            Font-Size="10pt" ForeColor="Black" Height="23px" NextPrevFormat="FullMonth" 
            Width="401px" ondayrender="Calendar1_DayRender" onprerender="Calendar1_SelectionChanged" 
            onselectionchanged="Calendar1_SelectionChanged" DayNameFormat="Shortest" 
            TitleFormat="Month" ShowNextPrevMonth="False" style="margin:0 auto; text-align:center;">
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" ForeColor="#333333" 
                Height="10pt" BackColor="#EEEEEE" />
            <DayStyle Width="14%" />
            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#EEEEEE" ForeColor="White" />
            <SelectorStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Verdana" 
                Font-Size="8pt" ForeColor="#333333" Width="1%" BorderColor="#CCCCCC" />
            <TitleStyle BackColor="#5D7B9D" Font-Bold="True" 
                Font-Size="13pt" ForeColor="White" Height="14pt" />
            <TodayDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>

    

          <div style="margin:0 auto; text-align:left; Width:401px">
 <asp:Button ID="Button2" runat="server" Text="Continue" 
        CausesValidation="false" OnClick="cmd" /></div>

    
           </div>
           <br />

    </div></div></div></div>
    </form>

</asp:Content>

