using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Type { get; set; }
        public int doctorID { get; set; }
        public int wardID { get; set; }
        public int roomID { get; set; }
    }
}