using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject1.Models
{
    public class car
    {
        [ScaffoldColumn(false)]
        [Key]
        public int ID { get; set; }
        public String CarType { get; set; }
        public String CarColor { get; set; }
        public int NumOfChair { get; set; }
        public String CarModel { get; set; }
        public String RentAmountOfCar { get; set; }
        public DataType From { get; set; }
        public DataType To { get; set; }
        public bool Availability { get; set; }
        public String CarImage { get; set; }
    }
}