using System;
using System.ComponentModel.DataAnnotations;

namespace AssigmentsManager.Models
{
    public class Assigment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
    }
}
