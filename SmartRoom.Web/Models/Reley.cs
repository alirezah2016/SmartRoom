namespace SmartRoom.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reley")]
    public partial class Reley
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public bool Value { get; set; }

        public int? LightSensorId { get; set; }

        
        public int? TmpSensorId { get; set; }

        public virtual LightSensor LightSensor { get; set; }

        public virtual TmpSensor TmpSensor { get; set; }
    }
}
