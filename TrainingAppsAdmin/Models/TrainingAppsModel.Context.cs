﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingAppsAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrainingappsEntities : DbContext
    {
        public TrainingappsEntities()
            : base("name=TrainingappsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accreditation> Accreditations { get; set; }
        public virtual DbSet<AccreditationsText> AccreditationsTexts { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<Crestron101CoursesContentTypes> Crestron101CoursesContentTypes { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<RegionsSale> RegionsSales { get; set; }
        public virtual DbSet<RegionsText> RegionsTexts { get; set; }
        public virtual DbSet<TimeZone> TimeZones { get; set; }
        public virtual DbSet<tblRegion> tblRegions { get; set; }
    }
}