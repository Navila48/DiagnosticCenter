<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWiseReportUI.aspx.cs" Inherits="ProjectApp.UI.TestWiseReportUI"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/themes/base/style.css" rel="stylesheet" />
    <link href="../Content/themes/base/jquery-ui.css" rel="stylesheet" />
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


    <form id="form2" runat="server">
    <div>
    <fieldset>
        <legend>Test Wise Report
            </legend>

        &nbsp;&nbsp;&nbsp;&nbsp; From Date&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="fromDateTextBox" runat="server" ></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; To Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="showButton" runat="server" OnClick="showButton_Click" Text="Show" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="testGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate >
                        <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("Name") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total test">
                    <ItemTemplate >
                        <asp:Label ID="testLabel" runat="server" Text='<%#Eval("TotalTest") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total Amount">
                    <ItemTemplate >
                        <asp:Label ID="totalAmountLabel" runat="server" Text='<%#Eval("Totalamount") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
        </asp:GridView>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="pdfButton" runat="server" Height="20px" style="margin-top: 1px" Text="PDF" Width="51px" OnClick="pdfButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="totalTextBox" runat="server" ></asp:TextBox>

        </fieldset></div>
    </form>
   
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
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
