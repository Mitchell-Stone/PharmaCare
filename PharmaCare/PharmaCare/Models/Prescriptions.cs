using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Prescriptions
    {
        public int PrescriptionID { get; set; }
        public string PatientFname { get; set; }
        public string PatientLname { get; set; }
        public string Drugs { get; set; }
        public string Doses { get; set; }
        public string SugestionTakenDes { get; set; }
        public string DoctorFname { get; set; }
        public string DoctorLname { get; set; }
    }
}