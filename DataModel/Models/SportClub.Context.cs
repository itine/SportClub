﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SportsClubEntities1 : DbContext
    {
        public SportsClubEntities1()
            : base("name=SportsClubEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
    }
}
