using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RovicareTestProject.Utilities
{
    public class PatientCreationAllFields
    {
        public InsuranceNameModel[] InsuranceFieldsData { get; set; }
        public DiagnoisPopupFieldsModel[] DiagnosisPopupData { get; set; }
        public AllergyPopupModel[] AllergyPopupData { get; set; }
        public ImmunizationPopupModel[] ImmunizationPopupData { get; set; }
        public ProgressNotesModel [] ProgressNotesPopupData { get; set; }
        public MedicationPopupModel[] AddMedicationPopupData { get; set; }
    }

    public class InsuranceNameModel
   {
        public string InsuranceName { get; set; }
        public string PlanName { get; set; }
        public string GroupNumber { get; set; }
        public string GroupName { get; set; }
        public string InsuranceMemberID { get; set; }
   }
   public class AllergyPopupModel
   {
        public string Category { get; set; }
        public string AllergyName { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
   }
   public class ImmunizationPopupModel
   {
        public string DateGiven { get; set; }
        public string Immunization { get; set; }
        public string Step { get; set; }
        public string ConsentStatus { get; set; }
        public string LocationGiven { get; set; }
   }
   public class MedicationPopupModel
    {
        public string DrugId { get; set; }
        public string DrugName { get; set; }
        public string Strength { get; set; }
        public string StrengthUnit { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public MedicationScheduleModel[] Schedules { get; set; }
    }

    public class MedicationScheduleModel
    {
        public string Dose { get; set; }
        public string DoseUnit { get; set; }
        public string ScheduleType { get; set; }
        public string Frequency { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }  

    public class ProgressNotesModel
    {
        public string EffectiveDate { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
       
    }

}
