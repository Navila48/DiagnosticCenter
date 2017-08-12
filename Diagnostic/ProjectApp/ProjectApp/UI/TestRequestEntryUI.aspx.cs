using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.BLL;
using ProjectApp.DAL.MODEL;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace ProjectApp.UI
{
    public partial class TestRequestEntryUi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            feeTextBox.Enabled = false;
            if (!IsPostBack)
            {
                FindTestNameList();
            }
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        private void FindTestNameList()
        {
            RequestEntryManager diagnosticManager = new RequestEntryManager();
            List<TestSetup> aList = diagnosticManager.GetTestNameList();
            testDropDownList.DataSource = aList;
            testDropDownList.DataTextField = "TestName";
            testDropDownList.DataValueField = "TestName";
            testDropDownList.DataBind();
            testDropDownList.Items.Insert(0, new ListItem("--- Please Select ---", ""));
            totalTextBox.Text = (0.00).ToString();
            feeTextBox.Text = (0.00).ToString();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Enabled = false;
            

            TestSetup viewSetup = new TestSetup();
            List<TestSetup> testSetups = new List<TestSetup>();
            if (ViewState["TestSetup"] != null)
            {
              
                    testSetups = (List<TestSetup>) ViewState["TestSetup"];
                if (testDropDownList.Text != "")
                {
                    viewSetup.TestName = testDropDownList.Text;
                    viewSetup.Fee = Convert.ToDouble(feeTextBox.Text);
                    testSetups.Add(viewSetup);
                  
                    listGridView.DataSource = testSetups;
                    listGridView.DataBind();

                    totalTextBox.Text =
                        (Convert.ToDouble(feeTextBox.Text) + Convert.ToDouble(totalTextBox.Text)).ToString();
               
                }
                else
                {
                    resultLabel.Text = "Please Select a Valid Test";
                }
                   
            }
            else
            {
                if (testDropDownList.Text != "")
                {
                    viewSetup.TestName = testDropDownList.Text;
                    viewSetup.Fee = Convert.ToDouble(feeTextBox.Text);
                    testSetups.Add(viewSetup);
                    listGridView.DataSource = testSetups;
                    listGridView.DataBind();

                    totalTextBox.Text =
                        (Convert.ToDouble(feeTextBox.Text) + Convert.ToDouble(totalTextBox.Text)).ToString();
                    ViewState["TestSetup"] = testSetups;
                    ClearBox();
                }
                else
                {
                    resultLabel.Text = "Please Select a Valid Test";
                }
            }
          
        }

        public void ClearBox()
        {
            resultLabel.Text=String.Empty;

        }
        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = testDropDownList.Text;
            RequestEntryManager aRequestEntryManager = new RequestEntryManager();
            double fee = aRequestEntryManager.GetFee(test);
             feeTextBox.Text = fee.ToString();
        }

        protected void feeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            RequestEntryManager aRequestEntryManager = new RequestEntryManager();
            Patient aPatient = new Patient();
            TestData aData =new TestData();
            aPatient.PatientName = nameTextBox.Text;
            aPatient.Total = Convert.ToDouble(totalTextBox.Text);
           
                aPatient.DOB = Convert.ToDateTime(dob.Value);
            
            aPatient.MobileNo = mobileTextBox.Text;
          
            aPatient.BillNo = DateTime.Now.ToString().GetHashCode().ToString("x");

            string test = aRequestEntryManager.SavePatient(aPatient);
            if (test.Contains("successful"))
            {

                aData.MobileNo = mobileTextBox.Text;
                aData.Date = DateTime.Today;
                foreach (GridViewRow row in listGridView.Rows)
                {
                    aData.TestName = ((Label) row.FindControl("nameLabel")).Text;
                    aData.Fee = Convert.ToDouble(((Label) row.FindControl("feeLabel")).Text);
                    resultLabel.Text = aRequestEntryManager.SaveBillingInfo(aData);
                   

                }

                
                SaveButton.Enabled = false;
                Paragraph para =
                    new Paragraph("        Print Date  " + aData.Date.ToString("dd-MM-yy") + "     Bill No         " +
                                  aPatient.BillNo + "\n\n");
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=RequestEntry.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                listGridView.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(para);
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                listGridView.AllowPaging = true;
                listGridView.DataBind();

               
            }
            else
            {
                resultLabel.Text = test;
                
            }

            
        }
    }
}