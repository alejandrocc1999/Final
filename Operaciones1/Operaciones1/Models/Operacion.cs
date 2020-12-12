
namespace Operaciones1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Operacion
    {
        [Key]
        [Range(1,9999999)]
        public double numero { get; set; }
        
    }
}