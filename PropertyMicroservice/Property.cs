using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMicroservice
{
    public class Property
    {
        [Key]
       // public int Id { get; set; }
        public int Propertyid { get; set; }      
        public string Budget { get; set; }
        public string PropertyType { get; set; }
        public string Locality { get; set; }
    }
}
