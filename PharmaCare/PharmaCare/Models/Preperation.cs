/*
 *      Date Created = 19th November 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This is the model for preperation objects which are shown in the preperation window
 *      Bugs = No known bugs
 */


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