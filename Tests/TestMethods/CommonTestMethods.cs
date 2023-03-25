using AventStack.ExtentReports;
using NUnit.Framework;
using OpenDialogWindowHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Tests.Incoming;
using RovicareTestProject.Utilities;

namespace RovicareTestProject.TestMethods
{

    public class CommonTestMethods : BaseClass
    {

        public void Brow()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        //*****************************************************************************Start medical Record************************************************************************//
        public static void Test_MedicalRecords(
            string ModuleName,
            string PatientName,
            string FileName,
            string FilenameForSearch,
            string CategoryName
            )
        {

            //string patientName;

            // Navigate to Outgoing page
            if (ModuleName == "Outgoing Page")
            {
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                OutgoingPOM.WaitForSpinnerToDisappear(Driver.Value);
                // Test Medical records Pop Up TC_001 To verify that  Medical records pop up comes up after clicking on  Medical records icon under action items

                try
                {
                    OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Medical records Box TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under more action items");
                    OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Medical records Pop Up_TC_001 - Medical records Pop Up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"{ModuleName} :Test_Medical records Pop Up_TC_001 - Medical records Pop Up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }

            // Navigate to incoming page
            else if (ModuleName == "Incoming Page")
            {
                IncomingPOM.NavigateToIncomingPage(Driver.Value);

                // Test Medical records Pop Up TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under action items

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Medical records Pop Up TC_001 To verify that Medical records Pop Up up comes up after clicking on Medical records icon under action items");
                    IncomingPOM.ClickOriginMedicalRecordAction(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Medical records Pop Up_TC_001 - Medical records Pop Up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"{ModuleName} :Test_Medical records Pop Up_TC_001 - Medical records Pop Up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            //navigate to patient list page
            else if (ModuleName == "Patient List Page")
            {
                PatientListPOM.NavigateToPatientListPage(Driver.Value);

                // Test Medical records Pop Up TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under action items

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Medical records Pop Up TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under action items");
                    PatientListPOM.ClickMedicalRecordAction(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Medical records Pop Up_TC_001 - Medical records Pop Up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"{ModuleName} :Test_Medical records Pop Up_TC_001 - Medical records Pop Up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            //navigate to appointment page
            else if (ModuleName == "Appointment Page")
            {
                AppointmentPagePOM.NavigateToAppointment_Appointment(Driver.Value);

                // Test Medical records Pop Up TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under action items

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Medical records Pop Up TC_001 To verify that Medical records Pop Up comes up after clicking on Medical records icon under action items");
                    AppointmentPagePOM.ClickOnMedicalRecord_Appointment(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Medical records Pop Up_TC_001 - Medical records Pop Up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"{ModuleName} :Test_Medical records Pop Up_TC_001 - Medical records Pop Up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

            }
            //Test MedicalRecords_TC_002 - To verify that user can add files using add file button
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_002 - To verify that user can add files using add file button");
                //Add File button is display
                Thread.Sleep(2000);
                Assert.True(CommonMethodPOM.AddFileDisplay_MedicalRecordsPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_Medical Records Box_TC_002 - Add File button displayed Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(4000);
                //Add file by using Add file button
                CommonMethodPOM.ClickOn_AddFileButton_MedicalRecordPopUp(Driver.Value);
                Thread.Sleep(2000);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_002 - Clicked on Add File button successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                HandleOpenDialog hndOpen = new HandleOpenDialog();
                hndOpen.fileOpenDialog("C:\\Users\\IBZ\\Desktop\\rovi_care_testing\\rovicaretesting\\TestData\\ImportPatient_Files", FileName);
                Thread.Sleep(2000);
                Assert.That(Driver.Value.FindElement(By.XPath("//a[@class='cursor-pointer file-name-color']")).Displayed);
                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_002 -  Verified that the file got uploaded ,  Screenshot: ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test MedicalRecords_TC_002 - Unable to upload file in medical records " + ex, CaptureScreenShot(Driver.Value, Filename));
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test MedicalRecords_TC_003 - To verify that Search field is present, clickable and accept inputs as per requirement
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_003 - To verify that Search field is present, clickable and accept inputs as per requirement ");

                // 	Search the name of the file uploaded
                // Verify that Search result should show up

                CommonMethodPOM.EnterName_SearchField_MedicalRecordPopUp(Driver.Value, FilenameForSearch);

                WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='tblattachmed']/tbody/tr/td/div[1]/div[1]/div[2]/a")));
                string temp = Driver.Value.FindElement(By.XPath("//*[@id='tblattachmed']/tbody/tr/td/div[1]/div[1]/div[2]/a")).Text;

                Assert.That(temp.ToLower(), Is.EqualTo(FilenameForSearch.ToLower()));
                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_003 - Verified that Search field in Medical Records is working successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test MedicalRecords_TC_003 - Search  " + ex, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test Medical Records Box TC_004 - To verify that Search criteria can be cleared successfully								
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Medical Records Box TC_004 - To verify that Search criteria can be cleared successfully");
                CommonMethodPOM.ClearName_SearchField_MedicalRecordPopUp(Driver.Value);
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test_Medical records Box_TC_004 - Search criteria cleared successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test_Medical records Box_TC_004 - Search criteria do not cleared successfully error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test MedicalRecords_TC_005 - To verify that Catagory feild is present, clickable and value can be selected and set default value
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_005 - To verify that Catagory feild is present, clickable and value can be selected and set default value");
                // Caregory feild works properly
                CommonMethodPOM.SelectCategory_SearchField_MedicalRecordPopUp(Driver.Value, CategoryName);
                WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Provider_Filter']/descendant::option[5]")));
                Assert.That(Driver.Value.FindElement(By.XPath("//*[@id='Provider_Filter']/descendant::option[5]")).Displayed);
                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_005 - Verified that the search result is showing " + CategoryName + " successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                // feild set as default by "All"
                CommonMethodPOM.SelectCategory_SearchField_MedicalRecordPopUp(Driver.Value, "All");
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_005 - Search criteria cleared ", CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :MedicalRecords_TC_005 - Unable to verify that search result or Search criteria cant be cleared" + ex, CaptureScreenShot(Driver.Value, Filename));
            }


            // Test MedicalRecords_TC_006 - To verify that Edit button is working properly
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_006 - To verify that Edit button is working properly ");
                //  Edit button works properly
                CommonMethodPOM.ClickOn_EditButton_MedicalRecordPopUp(Driver.Value);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_006 - Clicked on top edit button");
                int count = Driver.Value.FindElements(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']")).Count();
                Assert.That(Driver.Value.FindElement(By.Id($"editInLineFileName")).Displayed);
                Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::input[@id='editInLineFileName']")).Displayed);
                Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::select[@name='EditFileType']")).Displayed);
                Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::select[@name='EditShareType']")).Displayed);
                Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::i[@class='fa fa-times fa-sm']")).Displayed);
                Assert.That(Driver.Value.FindElement(By.XPath($"//tbody[@class='table-tbody']//descendant::tr[@class='ng-star-inserted']//descendant::input[@id='EditFileComment']")).Displayed);
                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_006 - Verified that edit options is showing up in " + count + " rows of the table successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test MedicalRecords_TC_006 - Unable to verify edit option after clicking on top edit button " + ex, CaptureScreenShot(Driver.Value, Filename));
            }


            //Test MedicalRecords_TC_007 - To verify that Edit button inside the row is working properly 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_007 - To verify that Edit button inside the row is working properly ");
                //Search for the file name
                CommonMethodPOM.EnterName_SearchField_MedicalRecordPopUp(Driver.Value, FilenameForSearch);

                //Click on edit button under action column		Verify that Edit options should show up only for the that specific row
                // CommonPOM.ClickOnEditButton_ActionColumn_MedicalRecordPopUp(Driver.Value);
                // Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Clicked on edit button in the row 1");

                //CommonPOM.ClickOnEditButton_MedicalRecordPopUp(Driver.Value);
                //Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Edit button is clickable");

                Assert.That(CommonMethodPOM.ClickOnCategoryInnerTable_MedicalRecordPopUp(Driver.Value));
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Category button is clickable");

                Assert.That(CommonMethodPOM.ClickOnAccessboxInnerTable_MedicalRecordPopUp(Driver.Value));
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Access button is clickable");

                CommonMethodPOM.ClickOnDiscriptionFeildInnerTable_MedicalRecordPopUp(Driver.Value);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Description field is working");

                CommonMethodPOM.ClickOnSaveButton_MedicalRecordPopUp(Driver.Value);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_007 - Update medical record sucessfully");

                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_007 - Verified that all the edit options is getting displayed successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test MedicalRecords_TC_007 - Failed, Missing edit option " + ex, CaptureScreenShot(Driver.Value, Filename));
            }

            // Test MedicalRecords_TC_008 - To verify that delete button is displayed user can delete the file 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_008 - To verify that user can delete the file ");

                CommonMethodPOM.ClickOnDeleteButton_ActionColumn_MedicalRecordPopUp(Driver.Value, 1);
                Thread.Sleep(2000);
                WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_008 - Delete file by clicking delete button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} :Test MedicalRecords_TC_008 - Failed, Delete button did'nt respond " + ex);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test MedicalRecords_TC_009 - To verify that user can save the file
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test MedicalRecords_TC_009 - To verify that user can save the file ");
                //save button display
                Thread.Sleep(5000);
                CommonMethodPOM.SaveButtonDisplay_MedicalRecordsPopUp(Driver.Value);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_009 - Save button Displayed successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //save file by clicking save button
                CommonMethodPOM.ClickOn_SaveButton_MedicalRecordPopUp(Driver.Value);
                Test.Value.Log(Status.Info, "Test MedicalRecords_TC_009 - Clicked on Save button successfully ");
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                Thread.Sleep(5000);
                if (ModuleName == "Incoming Page")
                {
                    IncomingPOM.ClickOriginMedicalRecordAction(Driver.Value, 1);
                }
                else if (ModuleName == "Patient List Page")
                {
                    PatientListPOM.ClickMedicalRecordAction(Driver.Value, 1);
                }
                else if (ModuleName == "Outgoing Page")
                {
                    OutgoingPOM.ExpandMoreActions(Driver.Value, 1);
                    OutgoingPOM.DropDown_MoreAction_referralList(Driver.Value, 1);
                }
                else if (ModuleName == "Appointment Page")
                {
                    PatientListPOM.ClickMedicalRecordAction(Driver.Value, 1);
                }

                WebDriverWait Wait = new WebDriverWait(Driver.Value, TimeSpan.FromSeconds(10));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//div[@title='{FileName}']//a[@class='cursor-pointer file-name-color']")));

                Assert.That(Driver.Value.FindElement(By.XPath($"//div[@title='{FileName}']//a[@class='cursor-pointer file-name-color']")).Displayed);
                Test.Value.Log(Status.Pass, "Test MedicalRecords_TC_009 - Verified that the file got saved/uploaded successfully ,  Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception ex)
            {
                Test.Value.Log(Status.Fail, "Test MedicalRecords_TC_009 - Unable to verify that the file got saved/uploaded " + ex, CaptureScreenShot(Driver.Value, Filename));
            }
        }
        //*****************************************************************************End Medical Records************************************************************************//
        //*****************************************************************************Start Notes Method************************************************************************//

        public static void Test_Notes(string ModuleName)
        {

            string patientName;

            // Navigate to Outgoing page
            if (ModuleName == "Outgoing Page")
            {
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                Thread.Sleep(4000);
                // Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items");
                    OutgoingPOM.ClickOn_NotesAction(Driver.Value);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_001 - notes box pop up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_001 - Notes box pop up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up
                patientName = CommonPOM.GetPatientNameFromList(Driver.Value);

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up");

                    string actual = CommonMethodPOM.CheckPatientName_NotesPopUp(Driver.Value);

                    Assert.AreEqual(patientName.ToLower(), actual.ToLower());

                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_002 - Patient's name present at top of Notes box ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_002 - Patient's name not present at top of Notes box Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

            }

            // Navigate to incoming page
            else if (ModuleName == "Incoming Page")
            {
                IncomingPOM.NavigateToIncomingPage(Driver.Value);

                // Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items

                try
                {

                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items");
                    IncomingPOM.ClickNotesIcon(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_001 - notes box pop up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_001 - Notes box pop up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up
                patientName = CommonPOM.GetPatientNameFromList(Driver.Value);

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up");

                    string actual = CommonMethodPOM.CheckPatientName_NotesPopUp(Driver.Value);

                    Assert.AreEqual(patientName.ToLower(), actual.ToLower());

                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_002 - Patient's name present at top of Notes box ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_002 - Patient's name not present at top of Notes box Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

            }
            //navigate to patient list page
            else if (ModuleName == "Patient List Page")
            {
                PatientListPOM.NavigateToPatientListPage(Driver.Value);

                // Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items

                try
                {
                    PatientListPOM.OpenMoreActions(Driver.Value, 1);
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items");
                    PatientListPOM.ClickNotesAction(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_001 - notes box pop up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_001 - Notes box pop up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up
                patientName = CommonPOM.GetPatientNameFromList(Driver.Value);

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up");

                    string actual = CommonMethodPOM.CheckPatientName_NotesPopUp(Driver.Value);

                    Assert.AreEqual(patientName.ToLower(), actual.ToLower());

                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_002 - Patient's name present at top of Notes box ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_002 - Patient's name not present at top of Notes box Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

            }
            //navigate to appointment page
            else if (ModuleName == "Appointment Page")
            {
                AppointmentPagePOM.NavigateToAppointment_Appointment(Driver.Value);

                // Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items

                try
                {
                    //AppointmentPOM.ExpandMoreActions_Appointment(Driver.Value, 1);
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_001 To verify that Notes pop up comes up after clicking on Notes icon under action items");
                    AppointmentPagePOM.ClickOnNotesAction_Appointment(Driver.Value, 1);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_001 - notes box pop up open successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_001 - Notes box pop up does not open Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
                //Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up
                patientName = CommonPOM.GetPatientNameFromList(Driver.Value);

                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_002 To verify that patient's name present at top of Notes pop up");

                    string actual = CommonMethodPOM.CheckPatientName_NotesPopUp(Driver.Value);

                    Assert.AreEqual(patientName.ToLower(), actual.ToLower());

                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_002 - Patient's name present at top of Notes box ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Notes Box_TC_002 - Patient's name not present at top of Notes box Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                
            }

            // Test_Notes Box_TC_003 - To verify that a text field to enter the message, Add notes button (paper plane icon) and notes section are available

            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_003 - To verify that a text field to enter the Text, Add notes button (paper plane icon) and notes section are available ");
                // Text feild to enter messege available on notes pop-up
                Assert.True(CommonMethodPOM.CheckTextFeildDisplay_NotesPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_003 -Text field to enter Text available on Notes Pop-Up");
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //Add notes button (paper plane icon) available on Notes Pop-Up
                Assert.True(CommonMethodPOM.CheckAddIconDisplay_NotesPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_003 -Add notes button (paper plane icon) available on Notes Pop-Up ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //Notes section are available on Notes Pop-Up
                Assert.True(CommonMethodPOM.CheckNotesSectionDisplay_NotesPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_003 - Notes section are available on Notes Pop-Up ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_003 -Text field to enter the message, Add notes button (paper plane icon) or notes section have error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            // Test_Notes Box_TC_004 - To verify that in text field placeholder 'Please put the notes here' is present before typing text

            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test Notes Box TC_004  To verify that in text field placeholder 'Please put the notes here' is present before typing text");
                Assert.AreEqual("Please put the notes here", CommonMethodPOM.CheckTextFeild_Placeholder_NotesPopUp(Driver.Value));
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_004 - Enter Text placeholder is available");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_004 - Enter Text placeholder is not available Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Notes Box_TC_005 - To verify that user can save notes by clicking on Add notes button

            try
            {
                string expected = CommonMethodPOM.Entertext_NotesPopUp(Driver.Value);
                try   // Test_Chat Box_TC_006 - To verify that each notes has name with a timestamp next to it showing correct time stamp as per local timezone
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_005 - To verify that user can save notes by clicking on Add notes button");
                    Thread.Sleep(4000);
                    CommonMethodPOM.ClickAddNotesIcon_NotesPopUp(Driver.Value);
                    Thread.Sleep(4000);
                    string actualSend = CommonMethodPOM.NotesSaveSuccessfully_NotesPopUp(Driver.Value);
                    Assert.AreEqual(expected, actualSend);
                    Test.Value.Log(Status.Pass, "Test_Notes Box_TC_005 - Message saved successfully");

                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, " Test_Notes Box_TC_005 - Message could not save successfully Error: " + e);

                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                //origin name with a timestamp are showing
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_006 - To verify that every notes have day and timestamp ");

                CommonMethodPOM.CheckTimeeDisplay_NotesPopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_006 - Each message has timestamp ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonMethodPOM.CheckDayDisplay_NotesPopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_006 - Every messege is sequenced as per the day when messege is saved");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Notes Box_TC_006 - User name or timestamp or day is not available with message Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Chat Box_TC_007 - To verify that all the notes are catagorized as per date of when they were save
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_007 - To verify that all the notes are catagorized as per date of when they were save ");
                CommonMethodPOM.CheckDateTimeDisplay_NotesPopUp(Driver.Value);

                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_007 - All the notes are catagorized as per date of when they were saved ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Notes Box_TC_007 - Notes are not catagorized as per date of when they were saved with message Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Chat Box_TC_008 - To verify that pop-up comes after clicking on delete button on right top of each note

            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_008 - To verify that pop-up comes after clicking on delete button on right top of each note");

                //Delete button are available on Notes Pop-Up
                CommonMethodPOM.ClickDeleteIcon_NotesPopUp(Driver.Value);
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_008 - Check Delete button are available on Notes Pop-Up ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

                //  Delete button pop up open successfully
                CommonMethodPOM.CheckDeletePopUpDisplay_NotesPopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_008 - Delete button pop up open successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_008 - Delete button pop up does not open Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Chat Box_TC_009 - To verify that the confirmation pop-up of delete button have "ok" and " cancel" button also.

            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_009 - To verify that the confirmation pop-up of delete button have \"ok\" and \" cancel\" button also.");

                //Cancel button available on Delete Pop-Up
                Assert.True(CommonMethodPOM.DisplayCancelButton_DeletePopUp_NotesPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_009 -Confirmation pop-up of delete Pop-UP have \"Cancel\" button.");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //OK button available on Delete Pop-Up
                Assert.True(CommonMethodPOM.DisplayOkButton_DeletePopUp_NotesPopUp(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_009 - Confirmation pop-up of delete Pop-Up have \"ok\" button.");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                //Ok button can delete the perticular notes
                CommonMethodPOM.ClickOkButton_DeletePopUp_NotesPopUp(Driver.Value);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_009 - By clicking \"ok\" button Notes deleted successfully.");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_009 - the confirmation pop-up of delete button Does'nt have \"ok\" or \" cancel\" button with messege Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Chat Box_TC_010 -To verify that after deleting  each notes, there should be a copy button
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_010 -To verify that after deleting  each notes, there should be a copy button ");

                //Copy button available after Deleting notes
                CommonMethodPOM.DisplayCopyIcon_NotesPopUp(Driver.Value);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_010 -Copy button available after Deleting each notes.");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_010 -  After deleting  each notes, there is no copy button available with messege Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test_Chat Box_TC_011 - To verify that user can copy the message by clicking on copy button, right top of every deleted note
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Notes Box_TC_011 - To verify that origin user can copy the message by clicking on copy button, right top of every deleted note");
                CommonMethodPOM.ClickCopyIcon_NotesPopUp(Driver.Value);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test_Notes Box_TC_011 -Text Copied after clicking copy button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                // Assert.AreEqual("Hi", OutgoingNotesPopPOM.ActualSend_expectedText(Driver.Value));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Notes Box_TC_011 -  Text do not copy after clicking copy button with messege Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
        }
        //*****************************************************************************End Note_Method************************************************************************//
        //*****************************************************************************Start Chat Method************************************************************************//

        public static void Test_Chat(string ModuleName, string DestinationHandleName, string DestinationName,string OriginHandleName)
        {
            string patientName = "";
            //Create New DummyPatient and Refere it to the two provider
            try
            {

                CommonPOM.CreateDummyReferralSend(Driver.Value,DestinationName, "Outpatient");
                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to create DummyPatient with referral Error :" + e);
            }
            //Navigate to ChatFunction

            // For patient list page
            if (ModuleName == "Patient List Page")
            {
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_ChatBox_TC_001 - To verify that ChatBox Button Navigate to Chat PopUp");
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate to PatientList page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    try {
                        FiltersPOM.ClearFilter_PatientList(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                    catch { }
                    patientName = CommonPOM.GetPatientNameFromList(Driver.Value);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Chat PopUp Open Successfully");
                    Test.Value.Log(Status.Pass, "Test_Chat Box_TC_001 -ChatFunction Button Navigate to Chat PopUp");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Chat Box_TC_001 -ChatFunction Button did not Navigate to Chat PopUp Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            }            // for outgoing page
            else if (ModuleName == "Outgoing Page")
            {
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_ChatBox_TC_001 - To verify that ChatBox Button Navigate to Chat PopUp");
                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                    try
                    {
                        FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                    catch { }
                    Test.Value.Log(Status.Pass, "Navigate to Outgoing page");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    patientName = CommonPOM.GetPatientNameFromList(Driver.Value);
                    CommonMethodPOM.ClickOnChatBox(Driver.Value);
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Chat PopUp Open Successfully");
                    Test.Value.Log(Status.Pass, "Test_Chat Box_TC_001 -ChatFunction Button Navigate to Chat PopUp");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Test_Chat Box_TC_001 -ChatFunction Button did not Navigate to Chat PopUp Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


            }

            //Test_Chat Box_002 To verify that patient's name present at top of chat pop up
            try
            {

                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Chat Box_002 - To verify that patient's name present at top of chat pop up ");
                string actual = CommonMethodPOM.CheckTitleOfChatPopUp(Driver.Value);
                Assert.That(actual.ToLower(), Is.EqualTo(patientName.ToLower()));
                Test.Value.Log(Status.Pass, "Patient Name present at top of the Pop up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Patient Name not present on chat pop up Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }




            //Test_Chat Box_003 To verify that chat pop up have providers list and chat sections

            try
            {

                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Chat Box_003 To verify that chat pop up have providers list and chat sections ");
                Assert.That(CommonMethodPOM.Providerlist_ChatPopup(Driver.Value));
                Test.Value.Log(Status.Pass, "Chat popUp has a provider list section");
                Assert.That(CommonMethodPOM.Chatbox_ChatpopUp_OutgoingPage(Driver.Value));
                Test.Value.Log(Status.Pass, "Chat popUp has a Chat section");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Chat popUp do not have Provider list section and Chat section  Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_004 To verify that chat pop up shows single/multiple providers (Name) in providers list section based on time of referre
            try
            {
                Thread.Sleep(15000);
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} :Test_Chat Box_004 To verify that chat pop up shows single/multiple providers (Name) in providers list section based on time of referre ");
                Assert.True(CommonMethodPOM.ProviderName_ChatPopUp(Driver.Value));
                Test.Value.Log(Status.Pass, "Single/multiple provider shown in provider list section");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Single/multiple provider did not show in provider list section  Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_005 - To verify that providers name are clickable 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}: Test_Chat Box_TC_005 - To verify that providers name are clickable ");

                Assert.True(CommonMethodPOM.ProviderName_ChatPopUp(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_005 -  providers name are clickable ");


                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_005 - providers name are not clickable Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_005 -To verify that chat section have  Print and copy all button 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}: Test Chat Box TC_005 To verify that  Print and copy all button are enable");

                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "CopyAll").Enabled);
                Test.Value.Log(Status.Pass, " CopyAll button enable ");
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "Print").Enabled);


                Test.Value.Log(Status.Pass, " Print button is enable ");
                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_005 - Print button and CopyAll button are enable ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_005 - Print button and CopyAll button was disable Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_006 -To verify that in text field placeholder 'Please put the message here' is present before text typing
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test Chat Box TC_006  To verify that in text field placeholder 'Enter message' is present before text typing");
                Assert.AreEqual("Enter Message", CommonMethodPOM.PlaceholderInTextBox_ChatpopUp(Driver.Value));
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_006 - Enter Meassage placeholder is available");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_006 - Enter message placeholder is not available Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_007 -To verify that origin user can send chat by clicking on paper plane icon
            CommonMethodPOM.ClickOnproviderNameFirst_tosendMessage(Driver.Value, DestinationName);
            string expected = CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_007 - To verify that origin user can send chat by clicking on paper plane icon");
                Thread.Sleep(4000);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                Thread.Sleep(4000);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_007 - Message sent successfully from origine ");


                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_007 - Message could not sent successfully from origine Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_008 -To verify that each message has user's name 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_008 - To verify that each message has user's name ");
                string actualSend = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 1);
                Thread.Sleep(2000);
                Assert.AreEqual(OriginHandleName, actualSend);


                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_008 - To verify that each message has user's name  ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }

            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_008 - user name is not available with message Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_008 -To verify that all the messages are catagorized as per day/date of when they were sent
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_008 To verify that all the messages are catagorized as per day/date of when they were sent");


                Assert.AreEqual("Today", CommonMethodPOM.CheckDayOfCommunication_ChatPopUp(Driver.Value));



                Test.Value.Log(Status.Pass, "Test Chat_Box_TC_008 - Messages are categorized as per day/date");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_008 - Messages are not categorized as per day/date Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test Chat_Box TC_009 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test Chat_incomingPage TC_009 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section");

                CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "CopyAll").Click();
                Test.Value.Log(Status.Pass, "CopyAll button Clicked.");
                Assert.That(CommonMethodPOM.CheckCopyAllSuccessfulMessage_ChatPopup(Driver.Value));
                Test.Value.Log(Status.Pass, "'Copy all text' successfull message display");
                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_009 - Copy button copy all text from chat box");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_009 - Copy button did not copy all text from chat box Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_Box TC_010 To verify that origin user can copy the message by clicking on copy button next to the message
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test Cha_Box TC_010  To verify that origin user can copy the message by clicking on copy button next to the message");

                IncomingPOM.CheckCopyText_Function(Driver.Value);
                Test.Value.Log(Status.Pass, "Copy button clicked");
                Assert.That(CommonMethodPOM.CheckCopyTextSuccessfulMessage_ChatPopup(Driver.Value));
                Test.Value.Log(Status.Pass, "'Copy text' successful message display");
                Test.Value.Log(Status.Pass, "Test Chat_Box TC_010 - Copy function copy text successfully");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_Box TC_010 - Copy function unable to copy text successfully Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Switch Account To Destination 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} Switch Account successfully");
                CommonMethodPOM.CloseChatpopUp(Driver.Value);
                LoginPOM.SwitchAccount(Driver.Value, "destination");
                Test.Value.Log(Status.Pass, $"{ModuleName} Switch Account successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
                //Navigate to Chatbox on incoming page
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} Unable To Switch Account Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_011  To verify that destination user receives chat messages sent from origin user
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_011  To verify that destination user receives chat messages sent from origin user");

                IncomingPOM.NavigateToIncomingPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Navigate to Incoming Page");
                try
                {
                    FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
                catch { }
                FiltersPOM.EnterPatientNameInSearchField(Driver.Value,patientName);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                CommonMethodPOM.ClickOnChatBox(Driver.Value);
                Test.Value.Log(Status.Pass, "Click On ChatBox");
                Assert.AreEqual(OriginHandleName, IncomingPOM.IncomingMessageInChatBox(Driver.Value, 1));
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_011 Destination rceieved message successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_011  Destination did not received message successfully Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_012  To verify that destination user can reply to the incoming chat message 
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}: Test_Chat Box_TC_012  To verify that destination user can reply to the incoming chat message .");
                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                Thread.Sleep(3000);
                Assert.AreEqual(DestinationHandleName, CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 2));
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_012  Destination can Reply to origine Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_012  Destination unable to Reply  origine   Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Switch Account Destination to Origin
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName} Switch account to Origin successfully");
                IncomingPOM.ClickCloseIconInChat(Driver.Value);

                LoginPOM.SwitchAccount(Driver.Value, "Origin");
                Assert.That(true);
                Test.Value.Log(Status.Pass, $"{ModuleName} Switch Account To Origin Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
                if (ModuleName == "Outgoing Page")
                {
                    //Navigate to outgoing page
                    OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate To Outgoing Page");
                    try
                    {
                        FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        FiltersPOM.EnterPatientNameInSearchField(Driver.Value, patientName);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                    }
                    catch { }
                }
                else if (ModuleName == "Patient List Page")
                {
                    PatientListPOM.NavigateToPatientListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate To Patient List Page");
                    try
                    {
                        FiltersPOM.ClearFilter_PatientList(Driver.Value);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        FiltersPOM.EnterPatientNameInSearchField(Driver.Value, patientName);
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    }
                    catch { }
                }
                else if (ModuleName == "Medical Records")
                {
                    Medical_RecordsPagePOM.NavigateToMedicalRecordsPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate To Medical Records Page");
                   
                }
                CommonMethodPOM.ClickOnChatBox(Driver.Value);
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"{ModuleName} Unable To Switch Account To Origin Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test_Chat Box_TC_013  To verify that the origin user receives the reply message from destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_013  To verify that the origin user receives the reply message from destination user");
                CommonMethodPOM.ClickOnproviderNameFirst_tosendMessage(Driver.Value, DestinationName);

                Assert.AreEqual(DestinationHandleName, IncomingPOM.IncomingMessageInChatBox(Driver.Value, 2));
                Test.Value.Log(Status.Pass, "Origin receive message from destination Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Origin did not receive message from destination  Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

            //Test_Chat Box_TC_014 To verify that origin user can reply back to the destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest($"{ModuleName}:Test_Chat Box_TC_014  To verify that origin user can reply back to the destination user");
                string expectedted = CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                Thread.Sleep(4000);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                Thread.Sleep(4000);
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_014 Origin send message to destination Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_014  Origin can't send message to destination Successfully Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }



        }
        //*****************************************************************************End Chat Method************************************************************************//

    }
}





