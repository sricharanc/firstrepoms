﻿using log4net.Config;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FLS_Measurement_ToolKit
{
    /// <summary>
    /// Interaction logic for GearInfoWindow.xaml
    /// </summary>
    public partial class GearInfoWindow : MetroWindow
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public GearInfoWindow()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();

            cmbTypeOfGear.SelectedValue = GlobalClass.Typeofgear;
            tboxGearOuterDiameter.Text = GlobalClass.GearOuterDiameter;
            tboxNoOfTeeth.Text = GlobalClass.NoOfteeth;
            tboxGearFaceWidth.Text = GlobalClass.Gearfacewidth;
            tboxHelixAngleInDegree.Text = GlobalClass.HelixAngle;
            tboxDirectionOfRotation.Text = GlobalClass.Directionofrotation;
            tboxNoOfDrive.Text = GlobalClass.Noofdrive;
            tboxTypeOfSpringPlate.Text = GlobalClass.Typeofspringplate;
            tboxKlinShellThicknessUnderGear.Text = GlobalClass.Klinshellthicknessundergear;
            cmbRotaion.SelectedValue = GlobalClass.RotaionType;

        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRotaion.Text) && !string.IsNullOrEmpty(cmbTypeOfGear.Text) && !string.IsNullOrEmpty(tboxDirectionOfRotation.Text))
            {
                GlobalClass.Typeofgear = cmbTypeOfGear.SelectedValue.ToString();
                GlobalClass.GearOuterDiameter = tboxGearOuterDiameter.Text;
                GlobalClass.NoOfteeth = tboxNoOfTeeth.Text;
                GlobalClass.Gearfacewidth = tboxGearFaceWidth.Text;
                GlobalClass.HelixAngle = tboxHelixAngleInDegree.Text;
                GlobalClass.Directionofrotation = tboxDirectionOfRotation.Text;
                GlobalClass.Noofdrive = tboxNoOfDrive.Text;
                GlobalClass.Typeofspringplate = tboxTypeOfSpringPlate.Text;
                GlobalClass.Klinshellthicknessundergear = tboxKlinShellThicknessUnderGear.Text;
                GlobalClass.RotaionType = cmbRotaion.SelectedValue.ToString();
                this.Close();
                logger.InfoFormat("MeasurementSelect Values Typeofgear: {0}, GearOuterDiameter: {1}, NoOfteeth: {2}, HelixAngle: {3}, Directionofrotation: {4}, Noofdrive: {5} ,Typeofspringplate: {6}, Klinshellthicknessundergear: {7}, RotaionType: {8}",
                GlobalClass.Typeofgear,
                GlobalClass.GearOuterDiameter,
                GlobalClass.NoOfteeth,
                GlobalClass.HelixAngle,
                GlobalClass.Directionofrotation,
                GlobalClass.Noofdrive,
                GlobalClass.Typeofspringplate,
                GlobalClass.Klinshellthicknessundergear,
                GlobalClass.RotaionType);
            }
            else
            {
                MessageBox.Show("Please enter the mandatory fields");
            }
        }
        public class ComboData
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //list of Type of gear
            List<ComboData> ListGearType = new List<ComboData>();
            ListGearType.Add(new ComboData { Id = "GEAR", Value = "Gear" });
            ListGearType.Add(new ComboData { Id = "RIM", Value = "Rim" });
            cmbTypeOfGear.ItemsSource = ListGearType;
            cmbTypeOfGear.DisplayMemberPath = "Value";
            cmbTypeOfGear.SelectedValuePath = "Id";
            //list of rotaion defaulted
            List<ComboData> ListRotaion = new List<ComboData>();
            ListRotaion.Add(new ComboData { Id = "CLOCKWISE", Value = "Clockwise" });
            ListRotaion.Add(new ComboData { Id = "ANTICLOCKWISE", Value = "Anti Clockwise" });
            cmbRotaion.ItemsSource = ListRotaion;
            cmbRotaion.DisplayMemberPath = "Value";
            cmbRotaion.SelectedValuePath = "Id";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.Isclose = true;
            this.Close();
        }
    }
}
