using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCentreWebApp.DAL.Model;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ProjectApp.BLL;

namespace ProjectApp.UI
{
    public partial class TypeWiseReportUi : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TestManager aTestManager = new TestManager();
        protected void showButton_Click(object sender, EventArgs e)
        {
            List<TypeWiseReportVM> typeList = new List<TypeWiseReportVM>();
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;

            typeList = aTestManager.FindType(fromDate, toDate);
            showTypeGridView.DataSource = typeList;
            showTypeGridView.DataBind();
            double totalAmount = 0;
            foreach (GridViewRow row in showTypeGridView.Rows)
            {
                string total = ((Label)row.FindControl("FeeLabel")).Text;
                totalAmount += Convert.ToDouble(total);
            }
            totalTextBox.Text = totalAmount.ToString();



            
        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=RequestEntry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            showTypeGridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            showTypeGridView.AllowPaging = true;
            showTypeGridView.DataBind();  

        }
    }
}