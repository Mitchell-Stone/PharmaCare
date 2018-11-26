/*
 *      Date Created = 27th October 2018
 *      Created By = Mitchell Stone: 451381461
 *      Purpose = This is the model for Group Preperation object creation
 *      Bugs = No known bugs
 */
 
 using System.Collections.Generic;

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