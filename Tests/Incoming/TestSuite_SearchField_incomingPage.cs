using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using RovicareTestProject.PageObjects;
using RovicareTestProject;
using RovicareTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using OpenQA.Selenium;
using MongoDB.Driver;
using OpenQA.Selenium.Interactions;

namespace RovicareTestProject.Tests.Incoming
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    internal class TestSuite_SearchField_incomingPage : BaseClass
    {

        [SetUp]
        public void BrowLaunch()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);

        }
        //*******************************Test Execution E2E_incomingPage SearchField****************************************

        [Test, Order(1)]
        [TestCaseSource("SearchField_TD")]
        public void Search_field(
            string Tags_Incoming,
            string TrackedBy,
            string PlaceHolderWhenAllSelectedTag,
            string PlaceHolderWhenAllSelectedStatus,
            string Status_Incoming

            )
        {
            
            IncomingPOM.NavigateToIncomingPage(Driver.Value);
            CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            try {
                FiltersPOM.ClearFilter_IncomingPage(Driver.Value);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }
            catch { }
           string PatientName = CommonPOM.GetPatientNameFromList(Driver.Value);


            //Test SearchField_incomingPage TC_001 To verify that the Status search field working properly

                Actions Act = new Actions(Driver.Value);
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_incomingPage_001 - To verify that Status Search field working properly");
            try
            {
                
                try
                {

                    FiltersPOM.SelectStatusinFilter(Driver.Value, "All");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001- The All Status selected from drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    // Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();

                    Assert.That(FiltersPOM.CheckAllStatusesSelected(Driver.Value));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - Once click on The All-Status all remaining Statuses have been selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_001 -The All Status not working properly Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {

                    Assert.That(FiltersPOM.CheckPlaceholder_Status_IncomingPage(Driver.Value, PlaceHolderWhenAllSelectedStatus));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - Once click on All-Status  placeholder reflects text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectStatusinFilter(Driver.Value, "All");
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_001 -Status placeholder do not reflects correct text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {

                    // Actions Act = new Actions(Driver.Value);
                    Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    FiltersPOM.SelectStatusinFilter(Driver.Value, Status_Incoming);
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - All Statuses are selected except 'All' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(FiltersPOM.CheckAllStatusesSelected(Driver.Value));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - The All-Status is selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(FiltersPOM.CheckPlaceholder_Status_IncomingPage(Driver.Value, PlaceHolderWhenAllSelectedStatus));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - The placeholder of Status filter reflects correct text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectStatusinFilter(Driver.Value, "All");

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_001 - The All-Status feature not working properly Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                try
                {//select multiple tags
                    string[] StatusArray = Status_Incoming.Split("|").ToArray();

                    string MultiStatus = (StatusArray[0]+"|"+ StatusArray[1]).ToString();

                    foreach (string Statu in MultiStatus.Split("|"))
                    {

                        FiltersPOM.SelectStatusinFilter(Driver.Value, Statu);
                        Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - '{Statu}' selected among drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    //Actions Act = new Actions(Driver.Value);
                    Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    Assert.That(FiltersPOM.CheckStatusOfAllRows_IncomingPage(Driver.Value, MultiStatus));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_001 - Search action has been done for multiple Status successfully Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_001 - Unable to do search action for selected status Screenshot: " + e, CaptureScreenShot(Driver.Value, Filename));
                    

                }
                finally
                {
                    FiltersPOM.SelectStatusinFilter(Driver.Value, "All");
                    if (FiltersPOM.CheckAllStatusesSelected(Driver.Value,"All"))
                        FiltersPOM.SelectStatusinFilter(Driver.Value, "All");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                }

            }
            catch { }

            //Test SearchField_incomingPage_002 - To verify that Tags Search field working properly
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_incomingPage_002 - To verify that Tags Search field working properly");
            try
            {
                try
                {

                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002- All tag selected from drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    // Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();

                    Assert.That(FiltersPOM.CheckAllTagsSelected(Driver.Value));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - Once click on All-Tag  all remaining tags have been selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_002 - All tag not working properly Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {

                    Assert.That(FiltersPOM.CheckPlaceholder_Tags(Driver.Value, PlaceHolderWhenAllSelectedTag));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - Once click on All-Tag  placeholder reflects text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_002 -Tag placeholder do not reflects correct text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }

                try
                {

                    // Actions Act = new Actions(Driver.Value);
                    Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    FiltersPOM.SelectTaginFilter(Driver.Value, Tags_Incoming);
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - All tags are selected except 'All' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(FiltersPOM.CheckAllTagsSelected(Driver.Value));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - All-tag is selected by default Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    Assert.That(FiltersPOM.CheckPlaceholder_Tags(Driver.Value, PlaceHolderWhenAllSelectedTag));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - The placeholder of Tags filter reflects correct text Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_002 - All-Tag feature not working properly Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                }
                try
                {//select multiple tags
                    string[] tag = Tags_Incoming.Split("|").ToArray();

                    string tag2 = (tag[1]).ToString();

                    foreach (string Tag in tag2.Split("|"))
                    {

                        FiltersPOM.SelectTaginFilter(Driver.Value, Tag);
                        Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - '{Tag}' selected among drop-down Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    //Actions Act = new Actions(Driver.Value);
                    Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                    Assert.That(FiltersPOM.CheckTagOfAllRows(Driver.Value, Tags_Incoming));
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_002 - Search action has been done for multiple tags successfully Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    

                }
                catch (Exception e)
                {
                    Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_002 - Unable to do search action for selected tags Screenshot: "+e, CaptureScreenShot(Driver.Value, Filename));
                    

                }
                finally 
                {
                    FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                    if (FiltersPOM.CheckAllTagsSelected(Driver.Value, "All"))
                    {
                        FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                    FiltersPOM.SelectTaginFilter(Driver.Value, "All");

                    }
                    else
                    {
                        FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                        Thread.Sleep(500);
                        FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                        CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                        //FiltersPOM.ClickOnInputTypeFilter(Driver.Value, "Tags").Click();
                        //Act.MoveToElement(Driver.Value.FindElement(By.XPath("//descendant::tr[1]//div[4]"))).Click().Build().Perform();
                        Thread.Sleep(500);
                        FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                    }
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);

                }
            }
            catch
            {
                Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_002 - Tag filter not working properly for selected tags Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                FiltersPOM.SelectTaginFilter(Driver.Value, "All");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            }



           







            //Test_SearchField_003 - To verify that Tracked By Search field working properly
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_incomingPage_003 - To verify that Tracked By Search field working properly");
            try
            {
                foreach (String by in TrackedBy.Split("|"))
                {
                    FiltersPOM.SelectTrackedByFilter(Driver.Value, by);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                    //PatientListPOM.WaitForResultToLoadUp(Driver.Value);
                    Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_003- Tracked By filter set to '{by}' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));



                    int tempp = Driver.Value.FindElements(By.XPath("//div[@class='row_container']")).Count();
                    try
                    {
                        for (int i = 1; i <= tempp; i++)
                        {
                            IncomingPOM.ExpandMoreActions(Driver.Value, i);
                            Assert.That(IncomingPOM.MoreAction_DropDown(Driver.Value, i, "Track").Displayed);
                            Driver.Value.FindElement(By.XPath($"//descendant::tr[{i + 1}]/descendant::app-date-time[1]")).Click();

                        }
                        Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_003- Tracked By filter searching out succesfully for '{by}' Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                    }
                    catch
                    {
                        Assert.That(IncomingPOM.CheckNoRecordsFound(Driver.Value));
                        Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_003- No Records Found for '{by}'", CaptureScreenShot(Driver.Value, Filename));

                    }
                }

                FiltersPOM.SelectTrackedByFilter(Driver.Value, "All");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, $"Test SearchField_incomingPage_003- Unable to do search tracked by filter  Error: {e}, Screenshot: ", CaptureScreenShot(Driver.Value, Filename));
                FiltersPOM.SelectTrackedByFilter(Driver.Value, "All");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            }

           
           
           


            
                   
            //Test SearchField_incomingPage TC_004 To verify that Mode filter do search action for each option
                Test.Value = ExtentTestManager.CreateTest("Test SearchField_incomingPage_004- To verify that Mode filter do search action for each option");
            try
            {
             SelectElement SelectMode = new SelectElement(FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1);
                for (int i = 1; i < SelectMode.Options.Count; i++)
                {
                    FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.Click();
                    CommonPOM.MouseActionForDropDownHandle(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item2);
                    CommonPOM.WaitForTableToGetLoaded(Driver.Value);


                    try
                    {
                        if (IncomingPOM.CheckModeOfAllRows(Driver.Value, FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.Text))
                        {
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, "Test SearchField_incomingPage_004- Mode of All Rows are same");
                        }
                        else if (IncomingPOM.CheckNoRecordsFound(Driver.Value))
                        {
                            Assert.That(true);
                            Test.Value.Log(Status.Pass, "Test SearchField_incomingPage_004- No Records Found of selected Mode");
                        }
                        Thread.Sleep(1000);
                        Test.Value.Log(Status.Pass, "Test SearchField_incomingPage_004- Search action done successfully for " + SelectMode.SelectedOption.Text);
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                    }
                    catch (Exception e)
                    {
                        Test.Value.Log(Status.Pass, $"Test SearchField_incomingPage_004- Unable to do Search action for option {SelectMode.SelectedOption.Text} Error");
                        Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));
                    }


                }

                Test.Value.Log(Status.Pass, "Test SearchField_incomingPage_004- Search action for each option of Mode section done successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));

                         FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.SendKeys("All");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_incomingPage_004- Unable to search for each option in Mode section Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
                FiltersPOM.ClickOnFilter(Driver.Value, "Mode").Item1.SendKeys("All");
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);

            }

            //Test SearchField_incomingPage TC_005- To verify that 'Search By Name' section provide data by patient name 

                Test.Value = ExtentTestManager.CreateTest("Test SearchField_incomingPage_005- To verify that the by-patient-name filter can do searching properly");
            try
            {
                
                FiltersPOM.EnterPatientNameInSearchField(Driver.Value, PatientName);
                CommonPOM.WaitForTableToGetLoaded(Driver.Value);
                Assert.That(PatientName.Contains(CommonPOM.GetPatientNameFromList(Driver.Value)));


                Test.Value.Log(Status.Pass, "Test SearchField_incomingPage_005- Search action done by patient name successfully");
                Test.Value.Log(Status.Pass, CaptureScreenShot(Driver.Value, Filename));


            }
            catch (Exception e)
            {
                Test.Value.Log(Status.Fail, "Test SearchField_incomingPage_005- Unable to search by patient name Error: " + e);
                Test.Value.Log(Status.Fail, CaptureScreenShot(Driver.Value, Filename));
            }
















        }



        public static IEnumerable<TestCaseData> SearchField_TD()
        {
            String Path = GetDataParser().TestData_Path("SearchField_TD");
            yield return new TestCaseData(

                //GetDataParser().TestData("PatientName", Path),
                //GetDataParser().TestData("InsurnanceName", Path),
                // GetDataParser().TestData("ModeName", Path),
                GetDataParser().TestData("Tags_Incoming", Path),
                GetDataParser().TestData("TrackedBy", Path),
                GetDataParser().TestData("PlaceHolderWhenAllSelectedTag_incoming", Path),
                GetDataParser().TestData("PlaceHolderWhenAllSelectedStatus_incoming", Path),
                GetDataParser().TestData("Status_Incoming", Path)

                );
        }






    }
}
