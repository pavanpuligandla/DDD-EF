using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;
using System.Collections.Generic;

namespace ProjectAllocation.Tests.Context
{
    public class TestContext : DbContext
    {
        
        public TestContext()
            : base("Name=DefaultConnection")
        {

        }
        public TestContext(bool enableLazyLoading, bool enableProxyCreation)
            : base("Name=DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }
        public TestContext(DbConnection connection)
            : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<ProjectURL> ProjectURL { get; set; }
        public DbSet<ProjectURLType> ProjectURLType { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check          
            Database.SetInitializer<TestContext>(new CreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(TestContext Context)
        {
            //Seed Models with sample data
            var proj = new List<ProjectType>() {
             new ProjectType() { ProjectTypeName="Biochemistry", ProjectTypeDescription="bio chemistry related project", CreatedDate=DateTime.Now }
            };
            Context.ProjectType.AddRange(proj);
            Context.SaveChanges();
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<TestContext>
        {
            [TestMethod]
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TestContext>
        {
            protected override void Seed(TestContext context)
            {
                context.Seed(context);
                base.Seed(context);
            }
        }


    }
}
