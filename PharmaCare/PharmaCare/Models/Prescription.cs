using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Prescription
    {
        public int PrescriptionID { get; set; }
        public int DrugID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string PrescribingDate { get; set; }
        public string InformationExtra { get; set; }
        public string StatusPrescription { get; set; }
        public string Doses { get; set; }
        public string FirstTimeUse { get; set; }
        public string LastTimeUse { get; set; }
        public string FrequenseUseInADay { get; set; }
        public string DoseStatus { get; set; }

        //Used for Inserting into the prescription database via name instead of id
        public string DrugName { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        //for checking if a drug is dangerous (cocktail system if no api)
        public int Danger { get; set; }
    }
}