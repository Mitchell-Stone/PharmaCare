/*
 *      Date Created = 27th October 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This is the model for Doctor object creation
 *      Bugs = No known bugs
 */
 namespace PharmaCare.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Speciality { get; set; }
    }
}