using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TimesheetData.Models
{
   public class TSModel:DbContext
    {
        public TSModel():base("TSModelContext")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 90000;
        }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<App_logs> App_logs { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<LookupItems> LookupItems { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ProjectAndUserMapping> ProjectAndUserMapping { get; set; }
		public virtual DbSet<TimeTracker> TimeTracker { get; set; }
		public virtual DbSet<TimeTrackerDetail> TimeTrackerDetail { get; set; }



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>()
            .Configure(s => s.HasMaxLength(255).HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

    }
}
