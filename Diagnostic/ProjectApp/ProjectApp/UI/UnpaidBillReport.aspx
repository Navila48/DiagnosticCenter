<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReport.aspx.cs" Inherits="ProjectApp.UI.UnpaidBillReport"  EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/themes/base/style.css" rel="stylesheet" />
     <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
    <style type="text/css">
        #dob {
            width: 279px;
        }
    </style>
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
        <a href="PaymentUI.aspx" class="dropbtn">Generate Report</a>
        <div class="dropdown-content">
            <a href="TestWiseReportUI.aspx">Test Wise Report</a>
            <a href="TypeWiseReportUI.aspx">Type Wise Report</a>
            <a href="UnpaidBillReport.aspx">Unpaid Bill Report</a>
        </div>
    </li>
</ul>

    <form id="form1" runat="server">
    <div>
        <center>
    <fieldset>
        <legend>Unpaid Bill Report</legend>
        <table>
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Label">From Date</asp:Label></td>
                
                    <td><input type="text" id="fromDateTextBox" runat="server" name="from" /></td>
            </tr>
            <tr>
                <td> <asp:Label ID="Label2" runat="server" Text="Label">To Date</asp:Label></td>
                <td><input type="text" id="toDateTextBox" runat="server" name="to" /></td>
            </tr>
        </table>
        <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
        <br />
        <br />
        <asp:GridView ID="showGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                 <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>

                <asp:TemplateField HeaderText="Name Of PatientForPayment">
                    <ItemTemplate >
                        <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("PatientForPaymentName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Bill No">
                    <ItemTemplate >
                        <asp:Label ID="billLabel" runat="server" Text='<%#Eval("BillNo") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile No">
                    <ItemTemplate >
                        <asp:Label ID="mobileLabel" runat="server" Text='<%#Eval("MobileNo") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Total ">
                    <ItemTemplate >
                        <asp:Label ID="totalLabel" runat="server" Text='<%#Eval("Total") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>
        <br />
    </fieldset>
            </center>
    </div>
    </form>
     <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script>
        $(function () {
            $("#fromDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true
            });
            $("#toDateTextBox").datepicker({
                changeMonth: true,
                changeYear: true
            });

        });
    </script>
</body>
</html>
