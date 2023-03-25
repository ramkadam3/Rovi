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
    public class TestSuite_Incoming_ActionItems :BaseClass
    {
        [SetUp]
        public void SetUp()
        {
            BaseClass Base = new BaseClass();
            Driver.Value = Base.Browser(Driver.Value,Origin_Email,Origin_Password);
        }

        //***************************************** Test Execution  *********************************************************//

        [Test, Order(1)]
        [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
        [TestCaseSource("Incoming_AI_OriginMedicalRecords_TD")]
        public static void Test_Incoming_AI_OriginMedicalRecords(
            string ModuleName,
            string PatientName,
            string FileName,
            string FilenameForSearch,
            string CategoryName)
        {
           CommonTestMethods.Test_MedicalRecords(ModuleName, PatientName, FileName, FilenameForSearch, CategoryName);
        }

        //***************************************** Test Data *********************************************************//

        public static IEnumerable<TestCaseData> Incoming_AI_OriginMedicalRecords_TD()
        {
            String Path = GetDataParser().TestData_Path("Incoming_AI_OriginMedicalRecords_TD");
            yield return new TestCaseData(
                GetDataParser().TestData("ModuleName", Path),
                GetDataParser().TestData("PatientName", Path),
                GetDataParser().TestData("FileName", Path),
                GetDataParser().TestData("FilenameForSearch", Path),
                GetDataParser().TestData("CategoryName", Path)

               );
        }
    
    [Test, Order(2)]
    [Author("Samarth S Gaur"), NUnit.Framework.Category("Smoke Test"), NUnit.Framework.Category("Functional")]
    [TestCaseSource("Notes_TD")]
    public static void Test_Incoming_Note(
           string ModuleName)
    {
        CommonTestMethods.Test_Notes(ModuleName);
    }

    //***************************************** Test Data *********************************************************//

    public static IEnumerable<TestCaseData> Notes_TD()
    {
        String Path = GetDataParser().TestData_Path("Notes_TD");
        yield return new TestCaseData(GetDataParser().TestData("ModuleName", Path));
    }
}
}