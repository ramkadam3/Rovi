using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RovicareTestProject.Utilities;
using RovicareTestProject.PageObjects;
using RovicareTestProject.TestMethods;

namespace RovicareTestProject.Tests.Incoming
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
    public class ExecutionCommonTest : BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value, Origin_Email, Origin_Password);
        }
        // Medical Record
        //***************************************** Test Execution Medical Records  *********************************************************//

        [Test, Order(0)]
        [Author("Samarth S Gaur, Shubhangi maharana"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]

        [TestCaseSource("MedicalRecordsTD_ModuleName1")]
        [TestCaseSource("MedicalRecordsTD_ModuleName2")]
        [TestCaseSource("MedicalRecordsTD_ModuleName3")]
        [TestCaseSource("MedicalRecordsTD_ModuleName4")]


        public static void TestMedicalRecords(
            string ModuleName,
            string PatientName,
            string FileName,
            string FilenameForSearch,
            string CategoryName)
        {
            CommonTestMethods.Test_MedicalRecords(ModuleName, PatientName, FileName, FilenameForSearch, CategoryName);
        }


        //***************************************** Test Data Medical Records *********************************************************//
        /*

        */

        public static IEnumerable<TestCaseData> MedicalRecordsTD_ModuleName1()
        {
            String Path = GetDataParser().TestData_Path("MedicalRecordsTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName1", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path));
        }

        public static IEnumerable<TestCaseData> MedicalRecordsTD_ModuleName2()
        {
            String Path = GetDataParser().TestData_Path("MedicalRecordsTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName2", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path));
        }

        public static IEnumerable<TestCaseData> MedicalRecordsTD_ModuleName3()
        {
            String Path = GetDataParser().TestData_Path("MedicalRecordsTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName3", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path));
        }
        public static IEnumerable<TestCaseData> MedicalRecordsTD_ModuleName4()
        {
            String Path = GetDataParser().TestData_Path("MedicalRecordsTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName4", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path));
        }
        //Notes
        //*****************************************Test Execution for Notes *********************************************************//


        [Test, Order(1)]
        [Author("Shubhangi Maharana"), Category("Functional")]
        [TestCaseSource("NotesTD_ModuleName1")]
        [TestCaseSource("NotesTD_ModuleName2")]
        [TestCaseSource("NotesTD_ModuleName3")]
        [TestCaseSource("NotesTD_ModuleName4")]
        public static void Test_Notes(string ModuleName)
        {
            CommonTestMethods.Test_Notes(ModuleName);
        }

        //***************************************** Test Data Notes *********************************************************//

        public static IEnumerable<TestCaseData> NotesTD_ModuleName1()
        {
            String Path = GetDataParser().TestData_Path("NotesTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName1", Path));
        }

        public static IEnumerable<TestCaseData> NotesTD_ModuleName2()
        {
            String Path = GetDataParser().TestData_Path("NotesTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName2", Path));
        }

        public static IEnumerable<TestCaseData> NotesTD_ModuleName3()
        {
            String Path = GetDataParser().TestData_Path("NotesTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName3", Path));
        }
        public static IEnumerable<TestCaseData> NotesTD_ModuleName4()
        {
            String Path = GetDataParser().TestData_Path("NotesTD");
            yield return new TestCaseData(GetDataParser().TestData("ModuleName4", Path));
        }
        // Chat Function
        //*****************************************Test Execution for Chat *********************************************************//
        [Test, Order(1)]
        [Author("Ram Kadam"), Category("Functional")]
        [TestCaseSource("ChatTD_Module1")]
        [TestCaseSource("ChatTD_Module2")]
        //[TestCaseSource("ChatTD_Module3")]

        public static void Test_Chat(string ModuleName, string DestinationHandleName, string DestinationName,string OriginHandleName)
        {
            CommonTestMethods.Test_Chat(ModuleName, DestinationHandleName, DestinationName, OriginHandleName);
        }

        //***************************************** Test Data Chat *********************************************************//
        public static IEnumerable<TestCaseData> ChatTD_Module1()
        {
            String Path = GetDataParser().TestData_Path("ChatTD");
            yield return new TestCaseData(
                GetDataParser().TestData("ModuleName1", Path),
                GetDataParser().TestData("DestinationHandleName", Path),
                GetDataParser().TestData("DestinationName", Path),
                GetDataParser().TestData("OriginHandleName", Path)
                );
        }
        public static IEnumerable<TestCaseData> ChatTD_Module2()
        {
            String Path = GetDataParser().TestData_Path("ChatTD");
            yield return new TestCaseData(
                GetDataParser().TestData("ModuleName2", Path),
                GetDataParser().TestData("DestinationHandleName", Path),
                GetDataParser().TestData("DestinationName", Path),
                GetDataParser().TestData("OriginHandleName", Path)
                );
        }
        /*
       public static IEnumerable<TestCaseData> ChatTD_Module3()
       {
           String Path = GetDataParser().TestData_Path("ChatTD");
           yield return new TestCaseData(
               GetDataParser().TestData("ModuleName3", Path),
               GetDataParser().TestData("DestinationHandleName", Path),
               GetDataParser().TestData("DestinationName", Path)

               );
       }

       [Test, Order(1)]
       [Author("Ram Kadam"), Category("Functional")]       
       [TestCaseSource("ChatTDModule2")]

       public static void TestChat(string ModuleName, string DestinationHandleName, string DestinationName)
       {
           Chat.TestChat(ModuleName, DestinationHandleName, DestinationName);
       }
       public static IEnumerable<TestCaseData> ChatTDModule2()
       {
           String Path = GetDataParser().TestData_Path("ChatTD");
           yield return new TestCaseData(
               GetDataParser().TestData("ModuleName2", Path),
               GetDataParser().TestData("DestinationHandleName", Path),
               GetDataParser().TestData("DestinationName", Path)

               );
       }
       */
    }

}