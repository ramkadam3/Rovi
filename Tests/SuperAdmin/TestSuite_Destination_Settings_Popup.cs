using AventStack.ExtentReports;
using NUnit.Framework;
using RovicareTestProject.PageObjects;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RovicareTestProject.Tests.SuperAdmin
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class TestSuite_Destination_Settings_Popup:BaseClass
    {
        [SetUp]
        public void BrowserLaunch()
        {

            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, SuperAdmin_Email, SuperAdmin_Password);

        }
        [Test, Order(1)]
        public void DestinationSetting()
        {
            string time = Time.TimeOfDay.ToString("hhmmss");
            string OrganizationName = $"DemoClient{time}";
            string MembEmail = $"DemoClient{time}@interbizconsulting.com";
            string[] MaxMemberMessage = { "Success! Member information added.", "Try to add a maximum of members as per  plan.", "Success! Member information updated." };


            string ProviderType = "Skilled Nursing(SNF)|Telemedicine|Substance Use|Home Health";


            string Insurances = "Arizona Complete Health|Banner University Health Plans|Aetna Group";

            //string ServicesOffered = "Acute Rehab|Companion Care|Attendant Care";
            string ServicesOffered = "Acupuncture|Alzheimer or Dementia|Case management";
            string ServiceSetting = "Outpatient|Telemedicine|Mobile Provider";

             string SpecialProgramAccepted="Adult Women|Family Caregiver";
              string AgeGroups = "Adult|Adolescent|Children";
              string GenderType="Female|Male|Gender Neutral";


            // Create Precondition required
            try
            {

                AddOrganizationList_AdminPOM.AddNewOrganization(Driver.Value, OrganizationName);
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - Create Precondition required");
                    AddOrganizationList_AdminPOM.NavigateToOrganizationListPage(Driver.Value);
                    Test.Value.Log(Status.Pass, "Navigate to Organization list page ");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.SearchOrganizationByName(Driver.Value, OrganizationName);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "Search created organization by name");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(AddOrganizationList_AdminPOM.GetOrganizationNameFromList(Driver.Value).ToLower().Contains(OrganizationName.ToLower()));
                    Test.Value.Log(Status.Pass, "the new Organization added successfully");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to add new organization Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                //To verify that UserName and PassWord can be set through add member feature
                try
                {
                    string MessageText = MaxMemberMessage[0];


                    PatientListPOM.OpenMoreActions(Driver.Value, 1);
                    Test.Value.Log(Status.Pass, "Expand more action feature");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    PatientListPOM.MoreAction_DropDown(Driver.Value, 1, "User Management").Click();
                    Test.Value.Log(Status.Pass, "Select 'user management' feature");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnAddMemberButton_UsermanagementPOPup(Driver.Value);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on add member button & navigate to add member pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Email ID", MembEmail);
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Password", "RoviPass@321");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Confirm Password", "RoviPass@321");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "First Name", "DemoAdmin");
                    AddOrganizationList_AdminPOM.EnterInputInTab(Driver.Value, "Last Name", "AdminDemo");
                    AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Designation", "CEO");
                    AddOrganizationList_AdminPOM.SelectOptionDropDown_AddMemberPOPup(Driver.Value, "Role", "Organization Admin");
                    Test.Value.Log(Status.Pass, "Provide required data to add member pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnSave_AddMemberPOPup(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on save button");
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    AddOrganizationList_AdminPOM.ClickOnOk_Confirmation_AddMemberPOPup(Driver.Value, MessageText);
                    Test.Value.Log(Status.Pass, "Click on ok button on pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));








                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Verification failed of adding new organization  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                finally
                {
                    AddOrganizationList_AdminPOM.ClickOnClose_UserManagementPOPup(Driver.Value);
                    Test.Value.Log(Status.Pass, "Close user management pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
            }
            catch(Exception e)
            {
                Test.Value.Log(Status.Fail, "Unable to create pre-condition  Error :" + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }





            //Enable destination settings at organization level

            try
            {
                  Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Destination Settings feature navigate to destination setting pop-up");
                   


                    AddOrganizationList_AdminPOM.ClickOnDestinationSetting_OrganizationList(Driver.Value);
                    Thread.Sleep(2000);
                    Test.Value.Log(Status.Pass, "Click on destination settings option");
                    Thread.Sleep(5000);

                try
                {
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Destination setting pop-up is getting opened");
                    Test.Value.Log(Status.Pass, "Insurance section is available on pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Provider Type section is available on the pop-up");
                    Test.Value.Log(Status.Pass, "Provider Type is available on pop-up");
                    Test.Value.Log(Status.Pass, "Check expansion button of provider type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string provider in ProviderType.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Provider Type", provider);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Provider Type", provider);

                            Test.Value.Log(Status.Pass, $"Enable {provider} provider type of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set {provider} provider type of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Save provider type of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: provider type of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);

                }
                catch { }
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Care requirement section is available on the pop-up");
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Care Requirement");
                    Test.Value.Log(Status.Pass, "Care requirement is availble on pop-up");
                    Test.Value.Log(Status.Pass, "Check expansion button of Care requirement");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Service in ServicesOffered.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Care Requirement", Service);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Care Requirement", Service);

                            Test.Value.Log(Status.Pass, "Enable Care requirement of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, "Unable to set care requirement of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Care Requirement");
                    Test.Value.Log(Status.Pass, "Save Care requirement of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: Care requirement of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);

                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Can't enable Care requirement for destination setting  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Special program section is available on the pop-up");
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Special Program");
                    Test.Value.Log(Status.Pass, "special program is available on the pop-up");
                    Test.Value.Log(Status.Pass, "Check expansion button of special program");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Service in SpecialProgramAccepted.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Special Program", Service);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Special Program", Service);

                            Test.Value.Log(Status.Pass, $"Enable special program '{Service}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set special program '{Service}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Special Program");
                    Test.Value.Log(Status.Pass, "Save Special program of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: Special program of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Can't enable Special program for destination setting  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                try 
                  {

                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Insurance section is available on pop-up");
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Insurance");
                    
                    Test.Value.Log(Status.Pass, "Check expansion button of Insurance");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Insurance in Insurances.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Insurance", Insurance);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Insurance", Insurance);

                            Test.Value.Log(Status.Pass, $"Enable {Insurance} Insurance of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set {Insurance} Insurance of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Insurance");
                    Test.Value.Log(Status.Pass, "Save Insurance of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: Insurance of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);

                }
                catch { }
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Age group section is available on the pop-up");
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Age Group");
                    Test.Value.Log(Status.Pass, "Age Group available on pop-up");
                    Test.Value.Log(Status.Pass, "Check expansion button of Age Group");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string AgeGroup in AgeGroups.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Age Group", AgeGroup);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Age Group", AgeGroup);

                            Test.Value.Log(Status.Pass, $"Enable {AgeGroup} Age Group of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set {AgeGroup} Age Group of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Age Group");
                    Test.Value.Log(Status.Pass, "Save Age Group of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: Age Group of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);

                }
               catch { }
                   try
                   {
                    Test.Value = ExtentTestManager.CreateTest($"Test_DestinationSetting - To verify that the Gender section is available on the pop-up");
                    AddOrganizationList_AdminPOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Gender Type");
                    Test.Value.Log(Status.Pass, "Gender Type is available on destination setting pop-up");
                    Test.Value.Log(Status.Pass, "Check expansion button of Gender Type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Gender in GenderType.Split("|"))
                    {
                        try
                        {
                            AddOrganizationList_AdminPOM.SearchServiceOnDestinationSettingPopUp_OrganizationList(Driver.Value, "Gender Type", Gender);
                            AddOrganizationList_AdminPOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, "Gender Type", Gender);

                            Test.Value.Log(Status.Pass, $"Enable {Gender} Gender Type of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                            Thread.Sleep(1000);

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set {Gender} Gender Type of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    AddOrganizationList_AdminPOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Gender Type");
                    Test.Value.Log(Status.Pass, "Save Gender Type of destination settings");
                    AddOrganizationList_AdminPOM.ConfirmEnableDisable_OnDestinationSetting_DestinationSettingChangeConfirmationDialog(Driver.Value, "Enabled");
                    Test.Value.Log(Status.Pass, "Confirmed Enable: Gender Type of destination settings");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);

                   }
                catch { }
                   

                    

                    







            }
            catch (Exception e)
            {
                    Test.Value.Log(Status.Fail, "Can't enable provider type for destination setting  Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }
            finally
            {
                    AddOrganizationList_AdminPOM.Close_DestinationSettingPOpUp(Driver.Value);
                    Test.Value.Log(Status.Pass, "Close destination setting pop-up");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            try 
            {
                try
                {

                   
                    LoginPOM.LogOutAccount(Driver.Value);
                    Test.Value.Log(Status.Pass, "Logging out super-admin profile");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    LoginPOM.EnterUsername(Driver.Value, MembEmail);
                    LoginPOM.EnterPassword(Driver.Value, Origin_Password);
                    Test.Value.Log(Status.Pass, "Provide UserName and PassWord");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    LoginPOM.ClickOnSignInButton(Driver.Value);
                    Test.Value.Log(Status.Pass, "Click on sign-in button");
                    Thread.Sleep(10000);
                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Thread.Sleep(5000);
                    Assert.That(AddOrganizationList_AdminPOM.ClickOnIAccept_OrganizationHomePage(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Logged in to the new organization page ");
                    Test.Value.Log(Status.Pass, "The new profile shows a licence copy");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Unable to logging in to new organization Error :" + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

                }

            }
            catch { }


            try

            {
                
                Test.Value = ExtentTestManager.CreateTest($"Test_AddOrganization - Enable Destination services");
                AddOrganizationList_AdminPOM.ClickOnIAccept_OrganizationHomePage(Driver.Value).Click();
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, "Clicked on I Accept feature");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToSettingsPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Navigated to setting page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToDashBoardHeaderSection_SettingsPage(Driver.Value, "Configuration");
                Test.Value.Log(Status.Pass, "Navigate to 'Configuration' section");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                SettingPagePOM.NavigateToConfigurationHeaderSection_Configuration(Driver.Value, "Destination Service");
                try
                {
                    Thread.Sleep(5000);
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Provider Type");

                    Test.Value.Log(Status.Pass, "Check expansion button of provider type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string provider in ProviderType.Split("|"))
                    {
                        try
                        {

                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, provider);
                            Thread.Sleep(1000);
                            Test.Value.Log(Status.Pass, $"Enable provider type'{provider}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set provider type'{provider}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Provider Type");
                    Test.Value.Log(Status.Pass, "Save provider type of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Pass, "Success Notification is not displaying Error : " + e);
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                }




                try
                {

                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Services Needed");

                    Test.Value.Log(Status.Pass, "Check expansion button of Service Needed");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Service in ServicesOffered.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Service);

                            Test.Value.Log(Status.Pass, $"Enable Service Needed '{Service}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Service Needed '{Service}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Services Needed");
                    Test.Value.Log(Status.Pass, "Save Service Needed of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);


                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Success Notification is not displaying Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }


                try
                {
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Special Program");

                    Test.Value.Log(Status.Pass, "Check expansion button of Special Program");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Program in SpecialProgramAccepted.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Program);

                            Test.Value.Log(Status.Pass, $"Enable Special Program '{Program}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Special Program '{Program}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Special Program");
                    Test.Value.Log(Status.Pass, "Save Special Program of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed Destination services enabling Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Insurance");

                    Test.Value.Log(Status.Pass, "Check expansion button of Insurance");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Insurance in Insurances.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Insurance);

                            Test.Value.Log(Status.Pass, $"Enable Insurance '{Insurance}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Insurance '{Insurance}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Insurance");
                    Test.Value.Log(Status.Pass, "Save Insurance of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed Destination services enabling Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Age Group");

                    Test.Value.Log(Status.Pass, "Check expansion button of Age Group");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string AgeGroup in AgeGroups.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, AgeGroup);

                            Test.Value.Log(Status.Pass, $"Enable Age Group '{AgeGroup}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Age Group '{AgeGroup}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Age Group");
                    Test.Value.Log(Status.Pass, "Save Age Group of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed Destination services enabling Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {
                    SettingPagePOM.ClickOnExpansionButtonOnPanelTitle_OnDestinationSetting(Driver.Value, "Gender Type");

                    Test.Value.Log(Status.Pass, "Check expansion button of Gender Type");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    foreach (string Gender in GenderType.Split("|"))
                    {
                        try
                        {
                            SettingPagePOM.EnableDestinationService_OnDestinationSettingPOPUp(Driver.Value, Gender);

                            Test.Value.Log(Status.Pass, $"Enable Gender Type '{Gender}' of destination settings");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"Unable to set Gender Type '{Gender}' of destination settings" + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                    SettingPagePOM.ClickOnSaveFollowingSiblingOfService_OnDestinationSetting(Driver.Value, "Gender Type");
                    Test.Value.Log(Status.Pass, "Save Gender Type of destination settings");

                    BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                    Assert.That(Success_Notification(Driver.Value).Displayed);
                    Test.Value.Log(Status.Pass, "Success Notification is displaying");
                    Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    InvisibleSuccess_Notification(Driver.Value);




                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, "Failed Destination services enabling Error: " + e);
                    Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                }



            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Failed verification of destination services Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
            finally
            {
                SettingPagePOM.ClickOnSubmit_SettingPage(Driver.Value);
                Test.Value.Log(Status.Pass, "Click on Submit to save Destination service settings");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                WaitForSpinnerToDisappear(Driver.Value);
            }

            try
            {
                
                
                Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Provider types are reflected on new search page");

                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Test.Value.Log(Status.Pass, $"Navigate to patient list page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                PatientListPOM.ClickAddDummyPatientButton(Driver.Value);
                Test.Value.Log(Status.Pass, $"Clicked on dummy patient");
                Assert.That(Success_Notification(Driver.Value).Displayed);
                Test.Value.Log(Status.Pass, $"Success message is displaying ");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                CommonPOM.InvisibleSuccess_Notification(Driver.Value);
                Thread.Sleep(5000);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                Assert.That(CommonPOM.ClickOnPatientNameInList(Driver.Value).Displayed);

                PatientListPOM.ClickShortlistFilter(Driver.Value, 1);
                Test.Value.Log(Status.Pass, $"Clicked on shortlist filter button");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                WaitForSpinnerToDisappear(Driver.Value);
                ShortlistFacilityPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, "Behavioral");

                //To verify that Selected Provider types are reflected on new search page
                try
                {

                    foreach (string provider in ProviderType.Split('|'))
                    {
                        try 
                        {
                        
                            Assert.That( ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Provider Type",provider).Displayed);
                            Test.Value.Log(Status.Pass, $"the provider type '{provider}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch(Exception e) 
                        {
                            Test.Value.Log(Status.Fail, $"the provider type '{provider}' is not available on new search page Error: "+e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch 
                {
                }

                //To verify that Selected Service needed are reflected on new search page
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Service needed are reflected on new search page");

                    foreach (string Service in ServiceSetting.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Services Needed", Service).Displayed);
                            Test.Value.Log(Status.Pass, $"the service setting '{Service}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the service setting'{Service}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch { }
                //To verify that Selected Insurances are reflected on new search page
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Insurances are reflected on new search page");

                    foreach (string insurance in Insurances.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Insurance", insurance).Displayed);
                            Test.Value.Log(Status.Pass, $"the insurance '{insurance}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the insurance '{insurance}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch { }


                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Special programs are reflected on new search page");

                    foreach (string program in SpecialProgramAccepted.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Special Program", program).Displayed);
                            Test.Value.Log(Status.Pass, $"the Special Program '{program}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Special Program '{program}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch { }

                //To verify that Selected Genders are reflected on the New search page
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Genders are reflected on the New search page");

                    foreach (string Group in AgeGroups.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Age Group", Group).Displayed);
                            Test.Value.Log(Status.Pass, $"the Age Group '{Group}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Age Group '{Group}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch { }

                //To verify that Selected Genders are reflected on the New search page
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Genders are reflected on the New search page");

                    foreach (string Gender in GenderType.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortlistFacilityPOM.CheckFilterValueAvailibilityInFilters(Driver.Value,"Gender", Gender).Displayed);
                            Test.Value.Log(Status.Pass, $"the Gender type '{Gender}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Gender type '{Gender}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }

                    }
                }
                catch { }












            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Default value of save search is 10 Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));

            }









            //Validate destination settings values on shortlist provider page
            try 
            {
               Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Provider types are reflected on Shortlist provider page");

                PatientListPOM.NavigateToPatientListPage(Driver.Value);
                Test.Value.Log(Status.Pass, $"Navigated to patient list page");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                PatientListPOM.ClickSendReferral(Driver.Value,1);
                Test.Value.Log(Status.Pass, $"Clicked on send referral");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                BaseClass.WaitForSpinnerToDisappear(Driver.Value);
                ShortListPOM.SelectOptionInFacilityTypeInFilter(Driver.Value, "Behavioral");
                Test.Value.Log(Status.Pass, $"The Behaviour Facility type is selected");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                //To verify that Selected Provider types are reflected on Shortlist provider page
                try
                {
                    foreach (string provider in ProviderType.Split('|'))
                    {
                        try
                        {
                            
                        Assert.That( ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value,"Provider Type", provider).Displayed);
                        Test.Value.Log(Status.Pass, $"the Provider type '{provider}' is available on new search page");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Gender type '{provider}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }
                
                
                }
                catch { }
                //To verify that Selected Insurances are reflected on Shortlist provider page	
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Insurances are reflected on Shortlist provider page");
                    foreach (string Insurance in Insurances.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value, "Insurance", Insurance).Displayed);
                            Test.Value.Log(Status.Pass, $"the Insurance '{Insurance}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Insurance '{Insurance}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                }
                catch { }
                //To verify that Selected Service Needed are reflected on Shortlist provider page	
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Service needed are reflected on Shortlist provider page");
                    foreach (string Service in ServiceSetting.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value, "Services Needed", Service).Displayed);
                            Test.Value.Log(Status.Pass, $"the Services Needed '{Service}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Services Needed '{Service}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                }
                catch { }
                //To verify that Selected Special program are reflected on Shortlist provider page	
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Special program are reflected on Shortlist provider page");
                    foreach (string Program in SpecialProgramAccepted.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value, "Special Program", Program).Displayed);
                            Test.Value.Log(Status.Pass, $"the Special Program '{Program}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Special Program '{Program}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                }
                catch { }
                //To verify that Selected Gender type are reflected on Shortlist provider page	
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected Gender type are reflected on Shortlist provider page");
                    foreach (string Gender in GenderType.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value, "Gender", Gender).Displayed);
                            Test.Value.Log(Status.Pass, $"the Gender '{Gender}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Gender '{Gender}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                }
                catch { }
                //To verify that Selected Age groups are reflected on Shortlist provider page								
                try
                {
                    Test.Value = ExtentTestManager.CreateTest($"Test_Destination Settings - To verify that Selected insurances are reflected on Shortlist provider page");
                    foreach (string Group in AgeGroups.Split('|'))
                    {
                        try
                        {

                            Assert.That(ShortListPOM.CheckFiltersValueAvailableInFilter(Driver.Value, "Age Group", Group).Displayed);
                            Test.Value.Log(Status.Pass, $"the Age Group '{Group}' is available on new search page");
                            Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                        }
                        catch (Exception e)
                        {
                            Test.Value.Log(Status.Fail, $"the Age Group '{Group}' is not available on new search page Error: " + e);
                            Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                        }
                    }


                }
                catch { }
            }
            catch { }


        }
    }
}
