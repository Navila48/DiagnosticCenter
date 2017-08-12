<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="WebApplication10.UI.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/themes/base/style.css" rel="stylesheet" />
</head>
<body>

    <center><h1>Diagnostic Center Bill Management</h1></center>

   <ul>
    <li><a href="IndexUI.html">Home</a></li>
    <li class="dropdown">
        <a href="#" class="dropbtn">Setup</a>
        <div class="dropdown-content">
            <a href="TestTypeSetupUI.aspx">Test Type Setup</a>
            <a href="TestSetupUI.aspx">Test Setup</a>
        </div>
    </li>
    <li><a href="TestRequestEntryUI.aspx">Test Request Entry</a></li>
    <li><a href="PaymentUI.aspx">Payment</a></li>
    <li class="dropdown">
        <a href="#" class="dropbtn">Generate Report</a>
        <div class="dropdown-content">
            <a href="TestWiseReportUI.aspx">Test Wise Report</a>
            <a href="TypeWiseReportUI.aspx">Type Wise Report</a>
            <a href="UnpaidBillReport.aspx">Unpaid Bill Report</a>
        </div>
    </li>
</ul>


    <form id="form1" runat="server">
    <div>
    <fieldset><legend>Payment</legend>
        <fieldset>
            
            <asp:Label ID="Label1" runat="server" Text="Bill No"></asp:Label>
&nbsp;<asp:TextBox ID="billNoTextBox" runat="server"></asp:TextBox>
            &nbsp;<asp:Label ID="Label5" runat="server" Text="or"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Mobile No"></asp:Label>
&nbsp;<asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
            
            <br />
            
        </fieldset>
        <fieldset>
            
            <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
&nbsp;
            <asp:TextBox ID="amountTextBox" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Due Date"></asp:Label>
&nbsp;<asp:TextBox ID="dueDateTextBox" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click" Enabled="False" />
            <br />
            <asp:Label ID="messageLabel" runat="server"></asp:Label>
            
        </fieldset>
    </fieldset>
    </div>
    </form>
</body>
</html>
