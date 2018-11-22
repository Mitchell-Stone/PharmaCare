using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class GroupPreperation
    {
        public int PrescriptionId { get; set; }
        public int PrescriptionCount { get; set; }
        public string PrescriptionDate { get; set; }
        public List<Preperation> PrepList { get; set; }
    }
}