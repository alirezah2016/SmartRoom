namespace SmartRoom.Entity.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=DbContext")
        {
        }

        public virtual DbSet<LightSensor> LightSensors { get; set; }
        public virtual DbSet<Reley> Releys { get; set; }
        public virtual DbSet<TmpSensor> TmpSensors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reley>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Reley>()
                .HasMany(e => e.LightSensors)
                .WithRequired(e => e.Reley)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reley>()
                .HasMany(e => e.TmpSensors)
                .WithRequired(e => e.Reley)
                .WillCascadeOnDelete(false);
        }
    }
}
