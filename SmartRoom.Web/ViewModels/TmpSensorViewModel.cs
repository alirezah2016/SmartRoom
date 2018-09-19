using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartRoom.Web.ViewModels
{
    public class TmpSensorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Value { get; set; }

        public int? Min { get; set; }

        public int? Max { get; set; }

    }
}