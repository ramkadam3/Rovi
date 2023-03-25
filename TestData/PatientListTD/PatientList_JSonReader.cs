using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Utilities
{
    public class PatientList_JSonReader
    {

        public PatientList_JSonReader()
        {

        }
        public string SendReferral_TD_Flow1 (string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\SendReferralTD\SendReferral_TD_Flow1.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string SendReferral_TD_Flow2(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\SendReferralTD\SendReferral_TD_Flow2.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string Chat_TD(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\Chat_TD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string ScheduleTransport_TD(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\ScheduleTransport_TD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string ImportPatient_TD(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\ImportPatient_TD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }


        public string MedicalRecords_TD(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\MedicalRecords_TD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string SearchField_TD(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\SearchFieldTD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            String temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public string ReferralCreation_Valid(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory  + @"\TestData\IncomingTD\ReferralCreation_Valid.json");
            var JsonObject = JToken.Parse(MyJsonString);
            string temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }

        public String PatientCreation(string TokenName)
        {
            try
            {
                String WorkingDirectory = Environment.CurrentDirectory;
                String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
                String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\PatientCreation.json");
                var JsonObject = JToken.Parse(MyJsonString);
                string temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
                return temp.Trim('\"');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public string ReferralCreation_Invalid(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + "\\TestData\\ReferralCreation_Invalid.json");
            var JsonObject = JToken.Parse(MyJsonString);
            string temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }


        public string ShortListFacility(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\ShortListFacilityTD.json");
            var JsonObject = JToken.Parse(MyJsonString);
            string temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }
        public string ScheduleTransportThroughPatientListPage(string TokenName)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + @"\TestData\PatientListTD\ScheduleTransportThroughPatientListPage.json");
            var JsonObject = JToken.Parse(MyJsonString);
            string temp = JsonConvert.SerializeObject(JsonObject.SelectToken(TokenName));
            return temp.Trim('\"');
        }  

        public JObject GetJSonObjectFromFile(String JsonFileUrl)
        {
            String WorkingDirectory = Environment.CurrentDirectory;
            String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            String MyJsonString = File.ReadAllText(ProjectDirectory + JsonFileUrl);
            return (JObject)JsonConvert.DeserializeObject(MyJsonString);
        }
    }
}
