using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS_Measurement_ToolKit.Entities
{
   public class GearInfoEntity
    {
        public string TypeOfGear { get; set; }
        public string GearOuterDiameter { get; set; }
        public string NoOfTeeth { get; set; }
        public string GearFaceWidth { get; set; }
        public string HelixAngle { get; set; }
        public string DirectionOfRotation { get; set; }
        public string NoOfDrive { get; set; }
        public string TypeOfSpringPlate { get; set; }
        public string KlinShellThicknessUnderGear { get; set; }        
    }
}
