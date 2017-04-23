﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS_Measurement_ToolKit.Entities
{
   public class ConfigDetail
    {
        public CustomerInfo CustomerInfo { get; set; }
        public MeasurementTool MeasurementTool { get; set; }
        public GraphValue GraphValue { get; set; }
        public GearInfo GearInfo { get; set; }
        
    }
}
