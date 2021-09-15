/*summary :DataDriven and PageFactory Automation Of FaceBook
  Author: Vedhashni V
  Date  : 11-09-21
*/

using NUnit.Framework;

namespace DataDrivenForFB
{
    public class LoginTests : Base.BaseClass
    {
        LoginPageActions pageActions = new LoginPageActions();

        //Used to test the tile after launcing the browser
        [Test, Order(0)]
        public void TestMethodForTitleAfterLaunching()
        {
            pageActions.TitleAfterLaunching(driver);
        }

        //Used to read the data from excel
        [Test, Order(1)]
        public void TestMethodForReadDataFromExcel()
        {
            pageActions.ReadDataFromExcel(driver);
        }

        //Used to login into facebook with credentials given in the excel
        [Test, Order(2)]
        public void TestMethodForLoginIntoFaceBook()
        {
            pageActions.LoginToFaceBook(driver);
        }

        //Used to check we have login into our dashboard by using title
        [Test, Order(3)]
        public void TestMethodForTitleAfterLogin()
        {
            pageActions.LoginToFaceBook(driver);
            pageActions.TitleAfterLogin(driver);
        }
    }
}