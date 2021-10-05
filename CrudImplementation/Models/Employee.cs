using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CrudImplementation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudImplementation.Models
{
    public class Employee
    {

        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Enter employee Name")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

   
        public int OrganisationId { get; set; }


        [Required(ErrorMessage = "Enter employee Email")]
        [Display(Name = " Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }


        [Required(ErrorMessage = "Phone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string Mobile { get; set; }


        [Required(ErrorMessage = "Please Provide Gender")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "Enter employee Age")]
        [Display(Name = " Age")]
        [Range(20, 60)]
        public int Age { get; set; }
    }
}
