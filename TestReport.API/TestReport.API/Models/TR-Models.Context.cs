﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestReport.API.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TestReportEntities : DbContext
    {
        public TestReportEntities()
            : base("name=TestReportEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Execution> Execution { get; set; }
        public virtual DbSet<Phase> Phase { get; set; }
    }
}
