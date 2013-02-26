<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="Advisor.aspx.cs" Inherits="Default2" %>
<script language="C#" runat="server">
    void cmd(Object sender, EventArgs e) 
    {
        Session["Student"] = 822459053;
    }
    </script>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server" style="height: 318px">
    <asp:Label ID="Label1" runat="server" ForeColor="#CCCCCC" 
        Text="Book An Advisor"></asp:Label>
    <br /><br /><br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" Height="104px" Width="594px" 
        onrowcreated="erow_c" Font-Size="Small">
        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="false" 
                        CommandName="Select" Text="Select"   Click="cmd" CommandArgument='<%# Eval("ID") %>' PostBackUrl='<%# DataBinder.Eval(Container.DataItem, "ID", "~/calendar.aspx?ID={0}") %>' BorderWidth="0" Width="50" ForeColor="#333399" />
                     
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    </form>
</asp:Content>

