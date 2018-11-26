/*
 *      Date Created = 27th October 2018
 *      Created By = Kaitlyn: 450950837
 *      Purpose = This is the model for Patient object creation
 *      Bugs = No known bugs
 */

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