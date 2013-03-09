<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.auto-style1 {
	border: 1px solid #000000;
}
.auto-style2 {
	font-size: small;
}
.auto-style4 {
	border-color: #000000;
	border-width: 1px;
	font-size: small;
	background-color: #C0C0C0;
}
.auto-style3 {
	border-color: #000000;
	border-width: 1px;
	font-size: small;
	background-color: #0000FF;
}
        #form1
        {
            height: 514px;
            width: 1036px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <font color="orange" size="2">

    <asp:Table ID="myTable" runat="server" Width="600px" BorderColor="Black" 
        BorderWidth="1px"> 
    <asp:TableRow ID="myTR" runat="server" Width="600px" BorderColor="Black">
       
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label><br />


    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="182px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server" Height="18px" Width="186px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList3" runat="server" Height="24px" Width="204px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList4" runat="server" Height="16px" Width="182px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList5" runat="server" Height="18px" Width="186px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList6" runat="server" Height="24px" Width="204px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList7" runat="server" Height="16px" Width="182px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList8" runat="server" Height="18px" Width="186px">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList9" runat="server" Height="24px" Width="204px">
    </asp:DropDownList>


    </font>
    </form>
</body>
</html>
