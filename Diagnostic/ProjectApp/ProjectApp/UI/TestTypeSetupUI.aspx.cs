using System;
using System.Collections.Generic;
using ProjectApp.BLL;
using ProjectApp.DAL.MODEL;

namespace ProjectApp.UI
{
    public partial class TestTypeSetupUi : System.Web.UI.Page
    {

        TestManager aTestManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            showInGridView();
        }

        private void showInGridView()
        {
            List<TestType> testTypes = aTestManager.GetAllTestTypes();
            showTypeGridView.DataSource = testTypes;
            showTypeGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            TestType aTestType = new TestType();
            aTestType.TypeName = testTypeNameTextBox.Text;

            messageLabel.Text=aTestManager.Save(aTestType.TypeName);
            showInGridView();
        }
    }
}