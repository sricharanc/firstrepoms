using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS_Measurement_ToolKit.Entities
{
   public class MeasurementToolEntity
    {
        public CustomerInfoEntity CustomerInfo { get; set; }
        public GearInfoEntity GearInfo { get; set; }
        public GraphValueEntity GraphValue { get; set; }
    }
}
