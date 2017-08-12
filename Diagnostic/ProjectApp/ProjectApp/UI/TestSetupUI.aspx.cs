using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectApp.BLL;
using ProjectApp.DAL.MODEL;
using WebApplication10.BLL;
using WebApplication10.DAL.Model;

namespace WebApplication10.UI
{
    public partial class TestSetupUi : System.Web.UI.Page
    {
        TestSetupManager aTestSetupManager = new TestSetupManager();
        TestTypeManager aTestTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TestType> testTypes = aTestTypeManager.GetAllTestTypes();
                testTypeDropDownList.DataSource = testTypes;
                testTypeDropDownList.DataTextField = "TypeName";
                testTypeDropDownList.DataValueField = "Id";

                testTypeDropDownList.DataBind();

            }

            PopulateGridview();
        }
        private void PopulateGridview()
        {
            List<TestSetupVM> types = aTestSetupManager.GetAllTestDetails();
            testSetupGridView.DataSource = types;
            testSetupGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestSetup aTestSetup = new TestSetup();
            double result;

            aTestSetup.TestName = testNameTextBox.Text;
            if (double.TryParse(feeTextBox.Text, out result) == false)
            {
                ClearTextBoxes();
                messageLabel.Text = "Please Enter your input correctly";
            }
            else
            {
                aTestSetup.Fee = Convert.ToDouble(feeTextBox.Text);
            }

            aTestSetup.TypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            messageLabel.Text = aTestSetupManager.SaveTest(aTestSetup);

            PopulateGridview();
            ClearTextBoxes();
        }
        public void ClearTextBoxes()
        {
            testNameTextBox.Text = string.Empty;
            feeTextBox.Text = String.Empty;
        }
    }
}