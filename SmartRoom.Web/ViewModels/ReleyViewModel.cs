using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRoom.Web.ViewModels
{
    public class ReleyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool? Value { get; set; }

        public int? LightSensorId { get; set; }

        public int? TmpSensorId { get; set; }
    }
}