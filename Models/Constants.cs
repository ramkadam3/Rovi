


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Models
{
    /************************************** Enum starts*****************************/
    enum SendReferralPopupPatientAttributes
    {
        PatientInformation = 1,
        Insurance,
        CareCoordination,
        Allergy,
        Diagnosis,
        EmergencySecondaryContact,
        Immunization,
        MedicalRecord,
        Medication,
        ProgressNote
    }
    enum AddPatientFormAddMoreButtons
    {
        Insurance = 1,
        EmergencySecondaryContact, 
        Providers,
        AllergyIntolerance,
        Diagnosis,
        Immunization,
        Medication,
        ProgressNote
    }
    /************************************** Enum ends *****************************/

    public class PatientAttributeCardIds
    {
        public const string Insurance = "INSInfo";
        public const string Allergy = "AIInfo";
        public const string Diagnosis = "DIGInfo";
        public const string EmergencyContacts = "EMGInfo";
        public const string Immunization = "IMNInfo";
        public const string MedicalRecord = "MDInfo";
        public const string Medication = "MedInfo";
        public const string ProgressNote = "PNInfo";
        public static List<string> GetPatientAttributeCardIds()
        {
            return new()
            {
                Insurance,
                Allergy,
                Diagnosis,
                EmergencyContacts,
                Immunization,
                MedicalRecord,
                Medication,
                ProgressNote
            };
        }
    }

    public class NavigationCardIds
    {
        public const string Personal = "Personal";
        public const string AddressInformation = "Address Information";
        public const string InsuranceDetails = "Insurance Details";
        public const string AllergyIntolerance = "Allergy Intolerance";
        public const string Diagnosis = "Diagnosis";
        public const string EmergencyContacts = "Emergency Contacts";
        public const string Immunization = "Immunization";
        public const string MedicalRecord = "Medical Record";
        public const string Medication = "Medication";
        public const string ProgressNote = "Progress Note";
        public const string Providers = "Providers";
        public const string ExportFacesheet = "Export Facesheet";
        public static List<string> GetNavigationCardIds()
        {
            return new()
            {
                Personal,
                AddressInformation,
                InsuranceDetails,
                AllergyIntolerance,
                Diagnosis,
                EmergencyContacts,
                Immunization,
                MedicalRecord,
                Medication,
                ProgressNote,
                Providers,
                ExportFacesheet
            };
        }
        public static String GetNavigationListText(String Token)
        {
            switch (Token.ToLower())
            {
                case "insurance":
                    return InsuranceDetails;

                case "allergy":
                    return AllergyIntolerance;

                case "diagnosis":
                    return Diagnosis;

                case "emergencysecondarycontact":
                    return EmergencyContacts;

                case "immunization":
                    return Immunization;

                case "medical record":
                    return MedicalRecord;

                case "medication":
                    return Medication;

                case "progress note":
                    return ProgressNote;

                default: return null;
            }
        }

    }

    // just for reference, this enum tells the order in which Patient Attribute Cards appear in View Patient Popup
    enum CardOrders
    {
        INSInfo,
        AIInfo,
        DIGInfo,
        EMGInfo,
        IMNInfo,
        MDInfo,
        MedInfo,
        PNInfo
    }
} 