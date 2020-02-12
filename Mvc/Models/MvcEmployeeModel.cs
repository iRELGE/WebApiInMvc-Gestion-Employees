using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MvcEmployeeModel
    {
        
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Requiered Field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Requiered Field")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Requiered Field")]
        public Nullable<int> Age { get; set; }
        [Required(ErrorMessage = "Requiered Field")]
        public Nullable<int> Salary { get; set; }
    }
}