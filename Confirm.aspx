<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
            <div class="post" id="post-5">
    <div class="post-title">
            <center>
                <h2>
                    Book An Advisor</h2>
            </center>
        </div>
        <div class="post-entry">
            <div class="post-entry-top">
                <div class="post-entry-bottom">
                <br />

                <div style="margin:0 auto; text-align:left; Width:201px">
        <asp:Label ID="Label1" runat="server" ForeColor="#CCCCCC" Text="Label"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" ForeColor="#CCCCCC" Text="Label"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" ForeColor="#CCCCCC" Text="Label"></asp:Label><br />
 
    
       <br /> <asp:Label ID="Label5" runat="server" ForeColor="#CCCCCC" Text="Time"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    
    
        <br />

        <asp:Label ID="Label6" runat="server" ForeColor="#CCCCCC" Text="Comments"></asp:Label>
  
  
        <br />
        <textarea id="TextArea1" name="S1" style="height: 63px; width: 176px" runat="server"></textarea><br />
  
      <br />  <asp:Button ID="Button1" runat="server" Text="Book" 
            onclick="Button1_Click" Visible="False" />
        <asp:Button ID="Button2" runat="server" Text="Cancel" Visible="False" />
    </p>
    <p>
    </p>
    </div>

    </div></div></div></div>
    </form>
</asp:Content>

