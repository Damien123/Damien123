﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gymDatabaseEntities : DbContext
    {
        public gymDatabaseEntities()
            : base("name=gymDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<ExerciseClass> ExerciseClasses { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    }
}
