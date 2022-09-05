using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyMicroservice
{
    public class PropertyContext:DbContext
    {
       
        public PropertyContext(DbContextOptions<PropertyContext> options) : base(options)
        { 
        }
        public DbSet<Property> Properties { get; set; }

    }
}
