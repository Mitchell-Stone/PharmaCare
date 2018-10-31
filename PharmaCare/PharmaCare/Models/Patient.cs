using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoomNumber { get; set; }
        public string WingNumber { get; set; }
        public string FloorNumber { get; set; }
    }
}