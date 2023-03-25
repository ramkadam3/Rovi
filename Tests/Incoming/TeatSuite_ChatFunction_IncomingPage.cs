using AventStack.ExtentReports;
                                        
using NUnit.Framework;
using RovicareTestProject.PageObjects;
using RovicareTestProject.TestMethods;
using RovicareTestProject.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RovicareTestProject.Tests.Incoming
{
    [TestFixture]   
    public class TeatSuite_ChatFunction_IncomingPage: BaseClass
    {
        [SetUp]
        public void BrowLaunch()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email,Origin_Password);

        }
        //*******************************Test Execution E2E_IncomingPage Chat_Function****************************************




        [Test, Order(1)]
        [TestCaseSource("ChatTD")]
        public void ChatIncomingTest(string DestinationHandleName,string DestinationName,string OriginHandleName)
        {   
            CommonPOM.CreateDummyReferralSend(Driver.Value, DestinationName, "Outpatient");
            LoginPOM.SwitchAccount(Driver.Value, "Destination");
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            try
            {
                FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            }
            catch { }
            string patientName = OutgoingPOM.GetPatientNameFromList(Driver.Value);
            string ReferrerName = IncomingPOM.GetReferrerNameFromIncomingList(Driver.Value, 1);
            //Test Chat_incomingPage TC_001 To verify that chat pop up comes up after clicking on chat icon under action items
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_001 To verify that chat pop up comes up after clicking on chat icon under action items");
                IncomingPOM.ClickChatAction(Driver.Value, 1);
                IncomingPOM.WaitForChatPopUp(Driver.Value);
                Assert.That(true);



                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_001 - Chat box pop up open successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_001 - Chat box pop up does not open Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_002 To verify that patient's name present at top of chat pop up
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_002 To verify that patient's name present at top of chat pop up");

                Assert.AreEqual(patientName, CommonMethodPOM.CheckTitleOfChatPopUp(Driver.Value));


                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_002 - Patient's name present on pop up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_002 - Patient's name did not present on pop up Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_003 To verify that Chat Pop up show Referrer Name at top of the pop up
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_003 To verify that Chat Pop up show Referrer Name at top of the pop up");


                Assert.AreEqual(ReferrerName, CommonMethodPOM.CheckTitleReferrerNameOnPopUp(Driver.Value, "IncomingPage"));


                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_003 - Referrer name available at top of pop up");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_003 - Referrer name did not available at top of pop upError :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_004 To verify that  Print and copy all button are enable 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_004 To verify that  Print and copy all button are enable");

                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "CopyAll").Enabled);
                Test.Value.Log(Status.Pass, "- CopyAll button enable ");
                Assert.True(CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "Print").Enabled);


                Test.Value.Log(Status.Pass, "- Print button is enable ");
                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_004 - Print button and CopyAll button are enable ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_004 - Print button and CopyAll button was disable Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_005 To verify that origin user can send chat by clicking on paper plane icon
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_005 To verify that origin user can send chat by clicking on paper plane icon");

                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "User can Enter message successfulyy");
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "Paper plane(send button) is enable");
                Assert.That(true);



                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_005 - Origin user can send message by clicking on paper plane button ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_005 - Origin user unable to send message by clicking on paper plane button Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_006 To verify that Sent message display with sender's name
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_006 To verify that Sent message display with sender's name");


                Assert.AreEqual(DestinationHandleName, CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 1));


                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_006 - Sent message display with sender's name");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_006 - Sent message did not display with sender's name Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_007 To verify that all the messages are catagorized as per day/date of when they were sent
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_007 To verify that all the messages are catagorized as per day/date of when they were sent");


                Assert.AreEqual("Today", CommonMethodPOM.CheckDayOfCommunication_ChatPopUp(Driver.Value));



                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_007 - Messages are categorized as per day/date");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_007 - Messages are not categorized as per day/date Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_008 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_008 To verify that origin user can copy all the text from chat by clicking on copy all button under chat section");

                CommonMethodPOM.CheckCopyAll_PrintButton_ChatPopUp(Driver.Value, "CopyAll").Click();
                Test.Value.Log(Status.Pass, "CopyAll button Clicked.");
                Assert.That(CommonMethodPOM.CheckCopyAllSuccessfulMessage_ChatPopup(Driver.Value));
                Test.Value.Log(Status.Pass, "'Copy all text' successfull message display");
                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_008 - Copy button copy all text from chat box");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_008 - Copy button did not copy all text from chat box Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_009 To verify that origin user can copy the message by clicking on copy button next to the message
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_009  To verify that origin user can copy the message by clicking on copy button next to the message");

                IncomingPOM.CheckCopyText_Function(Driver.Value);
                Test.Value.Log(Status.Pass, "Copy button clicked");
                Assert.That(CommonMethodPOM.CheckCopyTextSuccessfulMessage_ChatPopup(Driver.Value));
                Test.Value.Log(Status.Pass, "'Copy text' successful message display");
                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_009 - Copy function copy text successfully");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_009 - Copy function unable to copy text successfully Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }



            try
            {
                Test.Value = ExtentTestManager.CreateTest("Switch Account successfully");
                CommonMethodPOM.CloseChatpopUp(Driver.Value);
                LoginPOM.SwitchAccount(Driver.Value, "Origin");
                Test.Value.Log(Status.Pass, "Switch Account successfully ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                Thread.Sleep(2000);
                OutgoingPOM.NavigateToOutgoingPage(Driver.Value);
                try
                {
                    FiltersPOM.ClearFilter_OutgoingPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
                catch { }
                //Navigate to Chatbox on incoming page
                OutgoingPOM.ClickOnChatBox(Driver.Value);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, " Unable To Switch Account Error: " + e);

                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            //Test Chat_incomingPage TC_010 To verify that destination user receives chat messages sent from origin user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_010  To verify that destination user receives chat messages sent from origin user");
                CommonMethodPOM.ClickOnproviderNameFirst_tosendMessage(Driver.Value,DestinationName);
                
                string actualSend = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 1);
                Thread.Sleep(2000);
                Assert.AreEqual(DestinationHandleName, actualSend);



                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_010 -Destination user receive message successfully ");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_010 - Destination user did not receive message successfully Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_011 To verify that destination user can reply to the incoming chat message 
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_011  To verify that destination user can reply to the incoming chat message ");
                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "Destination enter text in text box");
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);

                Assert.That(true);
                Test.Value.Log(Status.Pass, "Destination sent message successfully");


                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_011 -Destination user reply to origin message successfully ");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonMethodPOM.CloseChatpopUp(Driver.Value);
                Test.Value.Log(Status.Pass, "ChatBox popUp close successfully");

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_011 - Destination user unable to reply origin message Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            // Test Chat_incomingPage TC_012 To verify that the origin user receives the reply from destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_012  To verify that the origin user receives the reply from destination user ");


                LoginPOM.SwitchAccount(Driver.Value, "Destination");
                try
                {
                    FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
                catch { }
                IncomingPOM.ClickChatAction(Driver.Value, 1);
                string actualSend1 = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 2);
                Thread.Sleep(2000);
                Assert.AreEqual(OriginHandleName, actualSend1);



                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_012 - Origin user receives reply from destination successfully ");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_012 - Origin user did not receive reply from destination Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            //Test Chat_incomingPage TC_013 To verify that origin user can reply back to the destination user
            try
            {
                Test.Value = ExtentTestManager.CreateTest("Test Chat_incomingPage TC_013  To verify that origin user can reply back to the destination user ");
                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                string actualSend = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 3);
                Thread.Sleep(2000);
                Assert.AreEqual(DestinationHandleName.ToLower(), actualSend.ToLower());
                CommonMethodPOM.EntertextIntextBox_ChatpopUp(Driver.Value);
                CommonMethodPOM.SendButton_ChatPopUp(Driver.Value);
                string actualSend2 = CommonMethodPOM.SenderNameShowWithMessage_ChatPopUp(Driver.Value, 3);
                Thread.Sleep(2000);
                Assert.AreEqual(DestinationHandleName, actualSend2);


                Test.Value.Log(Status.Pass, "Test Chat_incomingPage TC_013 - Origin user reply back successfully ");

                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test Chat_incomingPage TC_013 - Origin user unable to reply back Error " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }

        }
            //**************************************TestData******************************************


          
            public static IEnumerable<TestCaseData> ChatTD()
            {
                String Path = GetDataParser().TestData_Path("ChatTD");
                yield return new TestCaseData(
                    GetDataParser().TestData("DestinationHandleName", Path),
                    GetDataParser().TestData("DestinationName", Path),
                    GetDataParser().TestData("OriginHandleName", Path)


                    );
            }





        
        
    }
}
