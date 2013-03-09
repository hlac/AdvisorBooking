<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Advisor.aspx.cs" Inherits="Default2" %>


<script language="C#" runat="server">
    void cmd(Object sender, EventArgs e) 
    {
        Session["Student"] = 822459053;
    }
    </script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" style="height: 318px">
<style type="text/css">
a{color:white;}
</style>

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
    <br />
        <asp:Table ID="myTable" runat="server" Width="720px" 
  ForeColor="#FFCC99" Font-Size="Smaller"> 
    <asp:TableRow ID="myTR" runat="server" Width="720px"  BackColor="#3366CC" ForeColor="White">
       
        		<asp:TableCell>Advisor</asp:TableCell>
                <asp:TableCell>Department</asp:TableCell>
		<asp:TableCell>Monday</asp:TableCell>
		<asp:TableCell>Tuesday</asp:TableCell>
		<asp:TableCell>Wedneday</asp:TableCell>
		<asp:TableCell>Thursday</asp:TableCell>
		<asp:TableCell>Friday</asp:TableCell>	
    </asp:TableRow>
</asp:Table>  
<br />

</div></div></div></div>

    </form>
</asp:Content>

