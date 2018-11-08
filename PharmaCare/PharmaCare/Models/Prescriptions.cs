using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Prescriptions
    {
        public int PrescriptionID { get; set; }
        public string DrugID { get; set; }
        public string PatientNames { get; set; }
        public string PrescribingDate { get; set; }
        public string PrescribingDotor { get; set; }
        public string InformationExtra { get; set; }
        public string StatusPrescription { get; set; }
        public string Doses { get; set; }
        public string FirstTimeUse { get; set; }
        public string LastTimeUse { get; set; }
        public string FrequenseUseInADay { get; set; }
        public string DoseStatus { get; set; }
    }
}