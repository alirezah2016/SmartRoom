namespace SmartRoom.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<LightSensor> LightSensors { get; set; }
        public virtual DbSet<Reley> Releys { get; set; }
        public virtual DbSet<TmpSensor> TmpSensors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LightSensor>()
                .HasMany(e => e.Releys)
                .WithOptional(e => e.LightSensor)
                .HasForeignKey(e => e.LightSensorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reley>()
                .Property(e => e.Name)
                .IsFixedLength();            

            modelBuilder.Entity<TmpSensor>()
                .HasMany(e => e.Releys)
                .WithOptional(e => e.TmpSensor)
                .HasForeignKey(e=>e.TmpSensorId)
                .WillCascadeOnDelete(false);
        }
    }
}
