<%@ Page Title="" Language="C#" MasterPageFile="~/AdvisorBookingServiceMasterPage.master" AutoEventWireup="true" CodeFile="CancelAppointment.aspx.cs" Inherits="CancelAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        
          <div class="post" id="post-5">
            <div class="post-title">
              <center><h2><a href="#">Student Registration</a></h2></center>
            </div>
            <div class="post-entry">
              <div class="post-entry-top">
                <div class="post-entry-bottom">
                
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="lblStudentID" runat="server" style="font-weight: 700" 
                                    Text="Student I.D."></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtStudentID" runat="server" Width="174px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvStudentID" runat="server" 
                                    ErrorMessage="Student ID should not be blank" ControlToValidate="txtStudentID" 
                                    Font-Bold="True" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="rgvStudentID" runat="server" ControlToValidate="txtStudentID" 
                                    ErrorMessage="Student ID must be between 1 to 999999999" ForeColor="#FF3300" 
                                    MaximumValue="999999999" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
                            </td>
                            <td valign="middle">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="top">
                                <asp:Button ID="btncheck" runat="server" Text="See your appointments" 
                                    Width="219px" onclick="btnCheck_click" />
                            </td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                        <tr>
                        <td style="width: 137px; text-align: right" valign="middle">
                                <asp:Label ID="Llbcomment" runat="server" style="font-weight: 700" 
                                    Text="Reason to Cancel"></asp:Label>
                            </td>
                            <td style="width: 221px" valign="middle">
                                <asp:TextBox ID="txtComments" runat="server" Width="217px" Height="42px"></asp:TextBox>
                            </td>

                        </tr>

                        <tr>
                            <td style="width: 137px; text-align: right" valign="middle">
                                &nbsp;</td>
                            <td style="width:500px" valign="middle">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                     autogenerateselectbutton="True" selectedindex="0" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                    onrowdeleting="GridView1_RowDeleting">
                                    <Columns>
                                    <asp:BoundField DataField="Appointment_ID" HeaderText="Appointment_ID" 
                                            SortExpression="Appointment_ID" />
                                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" 
                                            SortExpression="Student_Id" />
                                            <asp:BoundField DataField="Comment" HeaderText="Comment" 
                                            SortExpression="Comment" />
                                            <asp:BoundField DataField="Date_Start" HeaderText="Date_Start" 
                                            SortExpression="Date_Start" />
                                            <asp:BoundField DataField="Time_Start" HeaderText="Time_Start" 
                                            SortExpression="Time_Start" />
                                    </Columns>
                                     <selectedrowstyle backcolor="LightCyan"
                                        forecolor="DarkBlue"
                                    font-bold="true"/> 
                                </asp:GridView>
                                
                            </td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                         <tr>
                            <td style="width: 137px" valign="middle">
                                &nbsp;</td>
                            <td style="width: 221px" valign="middle">
                                &nbsp;</td>
                            <td valign="middle">
                                &nbsp;</td>
                        </tr>
                             
                    </table>
             




                </div>
              </div>
            </div>
          </div>
          <div class="navigation">
            <div class="navigation-previous"></div>
            <div class="navigation-next"></div>
          </div>
          <div class="clear"></div>
        
    
</form>
</asp:Content>