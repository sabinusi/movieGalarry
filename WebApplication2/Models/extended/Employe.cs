using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    [MetadataType(typeof(EmployeMetadata))]
    public partial class Employe
    {
    }
    public class EmployeMetadata
    {
        [Required (AllowEmptyStrings =false,ErrorMessage ="please write name")]
        public string Name { get; set; }
        
    }
}
