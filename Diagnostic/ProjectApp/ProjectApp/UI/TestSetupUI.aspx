<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="WebApplication10.UI.TestSetupUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        label.error {
            color: red;
        }
         #feeLabel {
             color: red;
         }
        #messageLabel {
            color: red;
        }
         </style>
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
    <fieldset>
        <legend>Test Setup</legend>

        <br />
        <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
&nbsp;<asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label>
&nbsp;<asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="BDT"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Test Type"></asp:Label>
&nbsp;
        <asp:DropDownList ID="testTypeDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="saveButton" runat="server" OnClick="saveButton_Click" Text="Save" />
        <br />
        <asp:Label ID="messageLabel" runat="server"></asp:Label>

    </fieldset>
        <asp:GridView ID="testSetupGridView" runat="server" AutoGenerateColumns="False">
             <Columns>
                <asp:TemplateField HeaderText="SNo.">
                     <itemtemplate>
                           <%#Container.DataItemIndex + 1 %>                                                    
                     </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("TestName") %>'>'</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("Fee") %>'>'</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Label runat="server" text='<%#Eval("TypeName") %>'>'</asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
    
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script>
        $("#form1").validate({
            rules: {
                testNameTextBox: "required",
                feeTextBox: "required"

            },
            messages: {
                testNameTextBox: "Please provide test name",
                feeTextBox: "Please provide fee"
            }

        });
        $("#feeTextBox").keydown(function (e) {
            // Allow: backspace, delete, tab, escape, enter and .
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                // Allow: Ctrl+A, Command+A
                (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right, down, up
                (e.keyCode >= 35 && e.keyCode <= 40)) {
                // let it happen, don't do anything
                return;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });


        </script>
</body>
</html>
