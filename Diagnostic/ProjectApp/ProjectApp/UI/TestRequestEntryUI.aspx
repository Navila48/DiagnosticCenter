<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="ProjectApp.UI.TestRequestEntryUi"  EnableEventValidation="false" %>

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
        <center>
    <fieldset style="width: 611px">
        <legend>Test Request Entry</legend>
        <table style="width: 564px">
            <tr>
                <td><label>Name Of Patient</label></td>
                <td>
                    <asp:TextBox ID="nameTextBox" name="nameTextBox" runat="server" Width="283px"></asp:TextBox></td>
            </tr>
           
            <tr>
                <td><label>Date Of Birth</label></td>
                <td><input type="text" id="dob"  runat="server" name="dob" /></td>
            </tr>
            <tr>
                <td><label>Mobile No</label></td>
                <td>
                    <asp:TextBox ID="mobileTextBox" name="mobileTextBox" runat="server" Width="278px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label>Select Test</label></td>
                <td>
                    <asp:DropDownList ID="testDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>Fee <asp:TextBox ID="feeTextBox" runat="server" OnTextChanged="feeTextBox_TextChanged"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td >
                    <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" /></td>
            </tr>
        </table>
    </fieldset>
            <br />
            <asp:Label ID="resultLabel" runat="server"></asp:Label>
            <br />
            <br />
        
        <asp:GridView ID="listGridView" runat="server" AutoGenerateColumns="False">
            <columns>
                 <asp:TemplateField HeaderText="Serial No">
                         <ItemTemplate>
                         <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                         </asp:TemplateField>

                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate >
                        <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("TestName") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate >
                        <asp:Label ID="feeLabel" runat="server" Text='<%#Eval("Fee") %>'>>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
               
                </columns>
        </asp:GridView>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
        <br />
            </center>
    </div>
    </form>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script>
        $(function () {
            $("#dob").datepicker({
                changeMonth: true,
                changeYear: true
            });
            $("#form1").validate({
                rules: {
                    nameTextBox: "required",
                    dob: {
                        required: true,
                    },
                    mobileTextBox: {
                        required: true,
                        minlength: 11,
                        maxlength:11
                    }

                },
                messages: {
                    nameTextBox: "  provide your name",
                    dob: {
                        required: "     please provide your date of birth"
                       
                    },
                    mobileTextBox: {
                        required: "     please provide your mobile number",
                        minlength: "length must be 11 digit",
                        maxlength:"length must be 11 digit"
                    }
                  

                }
            });
            $("#mobileTextBox").keydown(function (e) {
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
        });
    </script>
</body>
</html>
