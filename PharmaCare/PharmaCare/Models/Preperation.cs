using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Preperation
    {
        public int PrescriptionId { get; set; }
        public string PrescriptionDate { get; set; }
        public string DrugName { get; set; }
        public string DrugForm { get; set; }
        public int DrugDose { get; set; }
        public int TimesPerDay { get; set; }
        public string PrescriptionStatus { get; set; }
    }
}