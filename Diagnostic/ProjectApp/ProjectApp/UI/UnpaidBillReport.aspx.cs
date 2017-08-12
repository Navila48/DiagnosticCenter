using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ProjectApp.BLL;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.UI
{
    public partial class UnpaidBillReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            UnpaidManager aManager = new UnpaidManager();
           List<Patient> unPaidBilList = new List<Patient>();
            UnPaidBill aBill = new UnPaidBill();
            aBill.FromDate = Convert.ToDateTime(fromDateTextBox.Value);
            aBill.ToDate = Convert.ToDateTime(toDateTextBox.Value);
            double total=0;
          
            unPaidBilList = aManager.GetUnPaidBiilInfo(aBill);
           
            showGridView.DataSource = unPaidBilList;
            showGridView.DataBind();
         
            foreach (GridViewRow row in showGridView.Rows)
            {
                total += Convert.ToDouble(((Label)row.FindControl("totalLabel")).Text); 
            }
              totalTextBox.Text = total.ToString();



        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=RequestEntry.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            showGridView.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            showGridView.AllowPaging = true;
            showGridView.DataBind();  

            
        }
    }
}