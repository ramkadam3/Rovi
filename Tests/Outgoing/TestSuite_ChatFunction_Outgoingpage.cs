using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RovicareTestProject.PageObjects;
using RovicareTestProject.TestMethods;
using RovicareTestProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RovicareTestProject.Tests.OutgoingChat
{
    [TestFixture]
    public class TestSuite_ChatFunction_Outgoingpage :BaseClass

    { //IWebDriver Driver;
       // OutgoingPOM Out ;
        [SetUp]
        public void Brow()
        {
            
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value,Origin_Email, Origin_Password);

        }
        //***************************************Test Execution E2E_OutgoingPage Chat *************************************

        [Test]
        [Ignore("Ignore a Test")]
        public void Outgoing()
        {
            string patientName;

            // Navigate to Outgoing page
            OutgoingPOM.NavigateToOutgoingPage(Driver.Value);

            Thread.Sleep(4000);

            // Test Chat Box TC_001 To verify that chat pop up comes up after clicking on chat icon under action items
            patientName = OutgoingPOM.GetPatientNameFromList(Driver.Value);
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_001  To verify that chat pop up comes up after clicking on chat icon under action items");
                
                OutgoingPOM.ClickOnChatBox(Driver.Value);
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_001 - Chat box pop up open successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_001 - Chat box pop up does not open Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat Box TC_002 To verify that patient's name present at top of chat pop up
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_002 To verify that patient's name present at top of chat pop up");

                string actual = CommonMethodPOM.CheckTitleOfChatPopUp(Driver.Value);
                
                Assert.AreEqual(patientName.ToLower(), actual.ToLower());

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_002 - Patient's name present at top of chat box ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_002 - Patient's name not present at top of chat box Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            // Test_Chat Box_TC_003 - To verify that chat pop up have providers list and chat sections
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_003 - To verify that chat pop up have providers list and chat sections");
                Assert.True(CommonMethodPOM.Providerlist_ChatPopup(Driver.Value));

                Thread.Sleep(4000);

                Assert.True(CommonMethodPOM.Chatbox_ChatpopUp_OutgoingPage(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_003 - provider list and chat box available on chat box ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_003 - provider list and chat box available on chat box Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_004 - To verify that chat pop up shows single/multiple providers (Name) in providers list section 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_004 - To verify that chat pop up shows single/multiple providers (Name) in providers list section ");

                Assert.True(CommonMethodPOM.ProviderName_ChatPopUp(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_004 - Single/multiple provider shows in provider list section ");


                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_004 - Single/multiple provider not shows in provider list section Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_005 - To verify that providers name are clickable
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_005 - To verify that providers name are clickable ");

                Assert.True(CommonMethodPOM.ProviderName_ChatPopUp(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_005 -  providers name are clickable ");


                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_005 - providers name are not clickable Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test_Chat Box_TC_006 To verify that chat section have Print and copy all button 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_006 To verify that chat section have provider name at the top , Print and copy all button");


                // verify that copy button is active
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value,"CopyAll").Enabled);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_006 Copy All button is enable ");
                // verify that print button is active
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value,"Print").Enabled);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_006 Print button is enable ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_006 provider name at headline/copy button/print button not enable Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            //Test Chat Box TC_007  To verify that in text field placeholder 'Please put the message here' is present before text typing
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_007  To verify that in text field placeholder 'Enter message' is present before text typing");
                Assert.AreEqual("Enter Message", CommonMethodPOM.PlaceholderInTextBox_ChatpopUp(Driver.Value));
                Thread.Sleep(2000);
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_007 - Enter Meassage placeholder is available");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_007 - Enter message placeholder is not available Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

            try
            {
            //Test_Chat Box_TC_008 To verify that origin user can send chat by clicking on paper plane icon
                    CommonMethodPOM.ClickOnproviderNameFirst_tosendMessage(Driver.Value, "Friendship Village Of Tempe");
                string expected = CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                try   
                {
                    Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_008 - To verify that origin user can send chat by clicking on paper plane icon");
                    Thread.Sleep(4000);
                    CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                    Thread.Sleep(4000);
                    Assert.That(true);
                    Test.Value.Log(Status.Pass, "Test_Chat Box_TC_008 - Message sent successfully from origine ");


                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, " Test_Chat Box_TC_008 - Message could not sent successfully from origine Error: " + e);

                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }
            // Test_Chat Box_TC_009 To verify that each message has user's name with a timestamp 
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_009 - To verify that each message has user's name with a timestamp ");
                string actualSend = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 1);
                Thread.Sleep(2000);
                Assert.AreEqual("Rovicare, Arizona", actualSend);


                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_009 - To verify that each message has user's name with a timestamp ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Test_Chat Box_TC_009 - user name is not available with message Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test Chat Box TC_010 To verify that all the messages are catagorized as per day/date of when they were sent
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_010 To verify that all the messages are catagorized as per day/date of when they were sent");
                Thread.Sleep(2000);
                Assert.AreEqual("Today",CommonMethodPOM.CheckDayOfCommunication_ChatPopUp(Driver.Value));
                
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_010 - Day Of Communication Shown In Chat Box");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_010 - Day Of Communication Do Not Show In Chat Box Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat Box TC_011  To verify that print button and copy all button is enable
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_011  To verify that print button and copy all button is enable");
                Thread.Sleep(2000);
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "Print").Enabled);
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value,"CopyAll").Enabled);

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_011 - Print Button and Copy All Button are Enable");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_011 - Print Button and Copy All Button are Disable Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat Box TC_012 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_012 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section");
                CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value,"CopyAll").Click();
                Thread.Sleep(1000);
                Assert.True(CommonMethodPOM.CheckCopyAllSuccessfulMessage_ChatPopup(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_012 - Copy All Button Working Properly ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_012 - Copy All Button Do Not Work Properly Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat Box TC_013 To verify that origin user can copy the message by clicking on copy button next to the message
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat Box TC_013 To verify that origin user can copy the message by clicking on copy button next to the message");
                CommonMethodPOM.ClickcopyTextfunction_ChatpopUp(Driver.Value);
                Thread.Sleep(1000);
                Assert.True(CommonMethodPOM.CheckCopyTextSuccessfulMessage_ChatPopup(Driver.Value));

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_013 - Copy Function Working Properly ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_013 - Copy Function Do Not Work Properly Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            // Logout from origine account
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Switch Account successfully");
                CommonMethodPOM.CloseChatpopUp(Driver.Value);
                LoginPOM.SwitchAccount(Driver.Value, "Destination");
                IncomingPOM.WaitForIncomingPageToLoadUp(Driver.Value);
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Switch Account successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
            //Navigate to Chatbox on incoming page
                IncomingPOM.ClickChatAction(Driver.Value, 1);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Unable To Switch Account Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            
           


            //Test_Chat Box_TC_014  To verify that destination user receives chat messages sent from origin user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_014  To verify that destination user receives chat messages sent from origin user");
                Assert.AreEqual("Rovicare, Arizona", IncomingPOM.IncomingMessageInChatBox(Driver.Value,1));
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_014 Destination rceieved message successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_014  Destination did not received message successfully Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            
            //Test_Chat Box_TC_015  To verify that destination user can reply to the incoming chat message 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_015  To verify that destination user can reply to the incoming chat message .");
                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);    
                Thread.Sleep(1000);
               Assert.AreEqual("Jack, Jack Jack", CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value,2));
                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_015  Destination can Reply to origine Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_015  Destination unable to Reply  origine   Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Logout Destination account successfully
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Switch account to Origin successfully");
                IncomingPOM.ClickCloseIconInChat(Driver.Value);

                LoginPOM.SwitchAccount(Driver.Value, "Origin");
                Assert.That(true);
                Test.Value.Log(Status.Pass, "Switch Account To Origin Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
            //Navigate to outgoing page
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                CommonMethodPOM.ClickOnChatBox(Driver.Value);
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable To Switch Account To Origin Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
           
           

            //Test_Chat Box_TC_016  To verify that the origin user receives the reply message from destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_019  To verify that the origin user receives the reply message from destination user");
                Assert.AreEqual("Jack, Jack Jack", IncomingPOM.IncomingMessageInChatBox(Driver.Value,2));
                Test.Value.Log(Status.Pass, "Origin receive message from destination Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Origin did not receive message from destination  Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test_Chat Box_TC_017 To verify that origin user can reply back to the destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test_Chat Box_TC_017  To verify that origin user can reply back to the destination user");
                string expected = CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                Thread.Sleep(4000);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                Thread.Sleep(4000);
                Assert.That(true);

                Test.Value.Log(Status.Pass, "Test_Chat Box_TC_017 Origin send message to destination Successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
             catch (Exception e)
            {

                Test.Value.Log(Status.Fail, "Test_Chat Box_TC_017  Origin can't send message to destination Successfully Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }

        }

        [Test, Order(1)]
        [TestCaseSource("ChatTD")]
        public void Chat(string ModuleName,string DestinationHandleName,string DestinationName, string OriginHandleName)
        {
            CommonTestMethods.Test_Chat(ModuleName,DestinationHandleName,DestinationName, OriginHandleName);
        }

        //*************************************************Testdata_Retrive***********************************
        //testdata_Chatfunction
        public static IEnumerable<TestCaseData> ChatTD()
        {
            String Path = GetDataParser().TestData_Path("ChatTD");
            yield return new TestCaseData(
                GetDataParser().TestData("ModuleName", Path),
                GetDataParser().TestData("DestinationHandleName", Path),
                GetDataParser().TestData("DestinationName",Path),
                GetDataParser().TestData("OriginHandleName", Path)


                );
        }


    }
}
