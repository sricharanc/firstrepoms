using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS_Measurement_ToolKit
{
    public static class GlobalClass
    {
        //--------------CustomerInfo
        public static string CustomerName;
        public static string OEM;
        public static string Location;
        public static string EquipmentTagNo;
        public static string Kilnsize;
        public static string NoOfbases;
        public static string ProjectContractNo;
        //--------------gearInfo
        public static string Typeofgear;
        public static string GearOuterDiameter;
        public static string NoOfteeth;
        public static string Gearfacewidth;
        public static string HelixAngle;
        public static string Directionofrotation;
        public static string Noofdrive;
        public static string Typeofspringplate;
        public static string Klinshellthicknessundergear;
        public static string RotaionType;
        //-------------------Girth Gear Axial Runout Measurement Graph
        public static string Client;
        public static string KilnNo;
        public static string Date;
        //------------------------------REsult
        public static string MeasuredAxialRunout;
        public static string AllowableAxialRunout;
        //------------------------ComPortNumber
        public static string ComNumber;
        //------------------------Serial Port
        public static string ChannelSelected;
        public static string SensorSelected;
        //------------------------Measurement
        public static string MeasurementType;
        public static int NoValueToPlot = 0;
        public static string CSVPath;
        //-------------------------TabClose
        public static bool Isclose;
        //-------------------------Itration completed
        public static int ItrationRequired = 0;

    }
}
