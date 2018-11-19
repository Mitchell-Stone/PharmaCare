using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCare.Models
{
    public class Prescription
    {
        //Prescription
        public int PrescriptionID { get; set; }
        public int DrugID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string PrescribingDate { get; set; }
        public string InformationExtra { get; set; }
        public string StatusPrescription { get; set; }
        
        //Used for Inserting into the prescription database via name instead of id
        public string DrugName { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }

        //Prescription Details
        public string Doses { get; set; }
        public string FirstTimeUse { get; set; }
        public string LastTimeUse { get; set; }
        public string FrequenseUseInADay { get; set; }
        public string DoseStatus { get; set; }
    }

    public class Details : Prescription
    {
        public int LinkId { get; set; }
        public string DrugDose { get; set; }
        public string FirstTime { get; set; }
        public string LastTime { get; set; }
        public string TimesPerDay { get; set; }
        public string StatusOfDose { get; set; }
    }

    public class Indoor : Prescription
    {
        public int IndoorId { get; set; }
        public int RoomNumber { get; set; }
        public int WingNumber { get; set; }
        public int FloorNumber { get; set; }
        public string NursingStationId { get; set; }
    }

    public class Outdoor : Prescription
    {
        public int OutdoorId { get; set; }
        public string FilledDispatched { get; set; }
        public string DateDispatched { get; set; }
        public string TimeDispatched { get; set; }
        public string IndoorEmergency { get; set; }
        public string ToFill { get; set; }
    }
}