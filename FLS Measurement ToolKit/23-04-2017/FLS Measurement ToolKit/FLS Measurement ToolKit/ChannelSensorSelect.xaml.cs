using log4net.Config;
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
    /// Interaction logic for ChannelSensorSelect.xaml
    /// </summary>
    public partial class ChannelSensorSelect : MetroWindow
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ChannelSensorSelect()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbChannelNo.Text) && !string.IsNullOrEmpty(cmbSensor.Text))
            {
                if (MessageBox.Show("Please confirm the Channel No. :" + cmbChannelNo.SelectedValue.ToString() + " and Sensor Type :" + cmbSensor.Text.ToString(), "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    
                    GlobalClass.ChannelSelected = cmbChannelNo.SelectedValue.ToString();
                    GlobalClass.SensorSelected = cmbSensor.SelectedValue.ToString();
                    this.Close();
                    logger.InfoFormat("ChannelSensorSelect Values {0},{1}", GlobalClass.ChannelSelected, GlobalClass.SensorSelected);                    
                }
                else
                {
                    //do yes stuff
                }


            }
            else
            {
                MessageBox.Show("Please enter the mandatory fields");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //list of Type of gear
            List<ComboData> ListChannelNumber = new List<ComboData>();
            ListChannelNumber.Add(new ComboData { Id = "1", Value = "1" });
            ListChannelNumber.Add(new ComboData { Id = "2", Value = "2" });
            ListChannelNumber.Add(new ComboData { Id = "3", Value = "3" });
            ListChannelNumber.Add(new ComboData { Id = "4", Value = "4" });
            cmbChannelNo.ItemsSource = ListChannelNumber;
            cmbChannelNo.DisplayMemberPath = "Value";
            cmbChannelNo.SelectedValuePath = "Id";
            //list of rotaion defaulted
            List<ComboData> ListSensor = new List<ComboData>();
            ListSensor.Add(new ComboData { Id = "m12_sensor", Value = "M12 sensor with 0.4...4mm range" });
            ListSensor.Add(new ComboData { Id = "m18_sensor", Value = "M18 sensor with 0.8...8mm range" });
            ListSensor.Add(new ComboData { Id = "m30_sensor", Value = "M30 sensor with 1...15mm range" });
            ListSensor.Add(new ComboData { Id = "rectangular_sensor", Value = "Rectangular sensor with 1...26mm range" });
            cmbSensor.ItemsSource = ListSensor;
            cmbSensor.DisplayMemberPath = "Value";
            cmbSensor.SelectedValuePath = "Id";
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
