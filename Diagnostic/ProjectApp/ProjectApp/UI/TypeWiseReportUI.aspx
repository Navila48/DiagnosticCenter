<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeWiseReportUI.aspx.cs" Inherits="ProjectApp.UI.TypeWiseReportUi" EnableEventValidation="false" %>

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
        <a href="PaymentUI.aspx" class="dropbtn">Generate Report</a>
        <div class="dropdown-content">
            <a href="TestWiseReportUI.aspx">Test Wise Report</a>
            <a href="TypeWiseReportUI.aspx">Type Wise Report</a>
            <a href="UnpaidBillReport.aspx">Unpaid Bill Report</a>
        </div>
    </li>
</ul>


   <form id="form1" runat="server" width="50%">
    <div style="width: 700px"  >
      
         <fieldset style="width:700px">
    <legend style="align-self: auto" >Type Wise Report</legend>
     
    
   <center>
        
        <asp:Label ID="Label1" runat="server" Text="From Date"  ></asp:Label>
<asp:TextBox ID="fromDateTextBox" runat="server" Width="220px"></asp:TextBox>
        <br />
        <br />
        
        <asp:Label ID="Label2" runat="server" Text="To Date" Width="70px"></asp:Label>
<asp:TextBox ID="toDateTextBox" runat="server" Width="220px"></asp:TextBox>
       
        <br />
       
       <table>
           <tr>
               <td>
                   <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
               </td>
               
           </tr>
           
       </table>
        <br />
        <br />
 
        
  

            <asp:GridView ID="showTypeGridView" runat="server" AutoGenerateColumns="False" Width="450px">
            <Columns>
                <asp:TemplateField HeaderText="SL">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Type Name">
        <ItemTemplate>
             <label><%#Eval("TestTypeName") %></label>
        </ItemTemplate>
    </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total No Of Test">
        <ItemTemplate>
             <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("TotalNoofTest") %>'>></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Total Amount">
        <ItemTemplate>
              <asp:Label ID="FeeLabel" runat="server" Text='<%#Eval("TotalFee") %>'>></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
            </Columns>
        </asp:GridView>
       <br/>
       <br/>
       
       <table>
           
           <tr>
               <td>
                   <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" />
               </td>
           <td>
               <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
               </td>    
           <td>
               <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>
               </td>    
           </tr>
           
       </table>
   </center>
         </fieldset>
    </div>
       
       
       

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

