<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Confirm.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Label"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Label"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Label"></asp:Label><br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
    </p>
    <p>
    </p>
    </form>
</asp:Content>

