<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="TestLogin.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Login" />

           <asp:RequiredFieldValidator ID="rfvStudentID" runat="server" 
                                    ErrorMessage="Student ID should not be blank" ControlToValidate="txtStudentID" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvStudentID" runat="server" ControlToValidate="txtStudentID" 
                                    ErrorMessage="Student ID must be between 1 to 999999999" ForeColor="#FF3300" 
                                    MaximumValue="999999999" MinimumValue="1" Type="Integer">*</asp:RangeValidator>


    </form>
</asp:Content>

