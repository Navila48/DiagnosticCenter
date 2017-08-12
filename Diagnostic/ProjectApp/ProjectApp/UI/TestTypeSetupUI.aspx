<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="ProjectApp.UI.TestTypeSetupUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/themes/base/style.css" rel="stylesheet" />
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




    <form id="form1" runat="server" width="50%">
    <div style="width: 700px"  >
      
         <fieldset style="width:700px">
    <legend style="align-self: auto" >Test Type Setup</legend>
     
       
    
    
  
        
        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
<asp:TextBox ID="testTypeNameTextBox" runat="server" Width="220px"></asp:TextBox>
        <br />
        <br />
        
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"  />
        <br />
        <br />
         
        
        </fieldset>
            
             <br />
             <asp:Label ID="messageLabel" runat="server"></asp:Label>
            
    </div>
       
        
        
            

            <asp:GridView ID="showTypeGridView" runat="server" AutoGenerateColumns="False" Width="450px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:TemplateField HeaderText="SL">
        <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Test Type">
        <ItemTemplate>
             <label><%#Eval("TypeName") %></label>
        </ItemTemplate>
    </asp:TemplateField>
            </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        
      
        
     
    </form>
</body>
</html>

