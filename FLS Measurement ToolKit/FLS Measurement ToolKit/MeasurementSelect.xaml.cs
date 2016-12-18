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
    /// Interaction logic for MeasurementSelect.xaml
    /// </summary>
    public partial class MeasurementSelect : MetroWindow
    {
        public MeasurementSelect()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbMeasurement.Text))
            {
                GlobalClass.MeasurementType = cmbMeasurement.SelectedValue.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the mandatory fields");
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //list of Type of gear
            List<ComboData> ListMeasurement = new List<ComboData>();
            ListMeasurement.Add(new ComboData { Id = "RADIAL", Value = "Radial" });
            ListMeasurement.Add(new ComboData { Id = "AXIAL", Value = "Axial" });
            cmbMeasurement.ItemsSource = ListMeasurement;
            cmbMeasurement.DisplayMemberPath = "Value";
            cmbMeasurement.SelectedValuePath = "Id";
        }
        public class ComboData
        {
            public string Id { get; set; }
            public string Value { get; set; }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.Isclose = true;
            this.Close();
        }
    }
}
