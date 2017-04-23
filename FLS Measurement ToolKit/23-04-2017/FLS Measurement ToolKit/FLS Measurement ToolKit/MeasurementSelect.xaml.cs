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
    /// Interaction logic for MeasurementSelect.xaml
    /// </summary>
    public partial class MeasurementSelect : MetroWindow
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MeasurementSelect()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbMeasurement.Text))
                {

                    GlobalClass.MeasurementType = cmbMeasurement.SelectedValue.ToString();
                    if (txtNoValuesToPlot.Text != string.Empty)
                    {
                        if (Convert.ToInt32(txtNoValuesToPlot.Text) > 11 && Convert.ToInt32(txtNoValuesToPlot.Text) < 241 && Convert.ToInt32(txtNoValuesToPlot.Text) % 12 == 0)
                        {
                            GlobalClass.NoValueToPlot = Convert.ToInt32(txtNoValuesToPlot.Text);
                        }
                        else
                        {
                            MessageBox.Show("Incorrect selection");
                            return;
                        }
                    }
                    else
                        GlobalClass.NoValueToPlot = 240;

                    this.Close();
                    logger.InfoFormat("MeasurementSelect Values MeasurementType: {0}, NoValueToPlot: {1} ", GlobalClass.MeasurementType, GlobalClass.NoValueToPlot);
                }
                else
                {
                    MessageBox.Show("Please enter the mandatory fields");
                }
            }
            catch (Exception Ex)
            {
                logger.Info(Ex);
                MessageBox.Show("Incorrect selection");
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
