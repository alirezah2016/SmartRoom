namespace SmartRoom.Entity.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TmpSensor")]
    public partial class TmpSensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Value { get; set; }

        public int ReleyId { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public virtual Reley Reley { get; set; }
    }
}
