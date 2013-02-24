<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Advisor.aspx.cs" Inherits="Default2" %>
<script language="C#" runat="server">
    void cmd(Object sender, EventArgs e) 
    {

        //
    }
    </script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" style="height: 318px">
    <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Book An Advisor"></asp:Label>
    <br /><br /><br />
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
        ForeColor="Black" GridLines="Vertical" Height="104px" Width="594px" 
        onrowcreated="erow_c" Font-Size="Small">
        <AlternatingRowStyle BackColor="#FFFFFF" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="false" 
                        CommandName="Select" Text="Select"   Click="cmd" CommandArgument='<%# Eval("ID") %>' PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "ID", "~/calendar.aspx?ID={0}") %>' BorderWidth="0" Width="50" ForeColor="#333399" />
                     
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#003366" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="White" />
        <SortedDescendingCellStyle BackColor="#FFCCCC" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    </form>
</asp:Content>

