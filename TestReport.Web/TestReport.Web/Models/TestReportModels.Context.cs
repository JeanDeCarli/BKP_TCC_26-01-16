﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestReport.Web.Models
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
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Execution> Executions { get; set; }
        public virtual DbSet<Phase> Phases { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserProject> UserProjects { get; set; }
    }
}
