using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CrudImplementation;
namespace CrudImplementation.Models
{
    public class Organisation
    {
        [Key]
        public int OrganisationId { get; set; }

        [Required(ErrorMessage = "Enter OrganisationName ")]
        [Display(Name = "Organisation Name")]
        public string OrganisationName { get; set; }

        [Required(ErrorMessage = "Enter OrganisationAddress")]
        [Display(Name = "OrganisationAddress")]
        public string OrganisationAddress { get; set; }
    }
}
