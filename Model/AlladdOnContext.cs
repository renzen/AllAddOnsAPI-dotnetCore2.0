using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AllAddOnsAPI.Models;


namespace AllAddOnsAPI.Models
{

    public class addOnContext : DbContext
    {
        
         public addOnContext(DbContextOptions<addOnContext> options)
         : base(options)
         {
         }

         public DbSet<AddOns> AllAddOns {get; set;}
         public DbSet<Promos> Promos { get; set;}
    }
}
