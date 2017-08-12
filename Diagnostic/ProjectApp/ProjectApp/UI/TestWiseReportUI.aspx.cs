using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterApp.DAL.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ProjectApp.BLL;

namespace ProjectApp.UI
{
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        DiagnosticManager aDiagnosticManager=new DiagnosticManager();
       
        protected void showButton_Click(object sender, EventArgs e)
        {
            List<TestWise> testList = new List<TestWise>(); 
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            
            testList=aDiagnosticManager.findTest(fromDate, toDate);
            testGridView.DataSource = testList;
            testGridView.DataBind();
            double totalAmount = 0;
            foreach (GridViewRow row in testGridView.Rows)
            {
                string total = ((Label)row.FindControl("totalAmountLabel")).Text;
                totalAmount += Convert.ToDouble(total);
            }
            totalTextBox.Text = totalAmount.ToString();
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Paragraph para = new Paragraph("\n \n Total = "+totalTextBox.Text+"\n \n");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=testWiseReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            testGridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
           
            htmlparser.Parse(sr);
            pdfDoc.Add(para);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            testGridView.AllowPaging = true;
            testGridView.DataBind();  
        }

        

      
    }
}