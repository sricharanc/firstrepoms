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
    /// Interaction logic for AddInfoWindow.xaml
    /// </summary>
    public partial class AddInfoWindow : MetroWindow
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AddInfoWindow()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();

            tboxCustomerName.Text = GlobalClass.CustomerName;
            tboxOEM.Text = GlobalClass.OEM;
            tboxLocation.Text = GlobalClass.Location;
            tboxEquipment.Text = GlobalClass.EquipmentTagNo;
            tboxKlin.Text = GlobalClass.Kilnsize;
            tboxNoBases.Text = GlobalClass.NoOfbases;
            tboxProject.Text = GlobalClass.ProjectContractNo;
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tboxCustomerName.Text) && !string.IsNullOrEmpty(tboxOEM.Text) && !string.IsNullOrEmpty(tboxProject.Text))
            {
                GlobalClass.CustomerName = tboxCustomerName.Text;
                GlobalClass.OEM = tboxOEM.Text;
                GlobalClass.Location = tboxLocation.Text;
                GlobalClass.EquipmentTagNo = tboxEquipment.Text;
                GlobalClass.Kilnsize = tboxKlin.Text;
                GlobalClass.NoOfbases = tboxNoBases.Text;
                GlobalClass.ProjectContractNo = tboxProject.Text;
                this.Close();
                logger.InfoFormat("MeasurementSelect Values CustomerName: {0}, OEM: {1}, Location: {2}, EquipmentTagNo: {3}, Kilnsize: {4}, NoOfbases: {5} ,ProjectContractNo: {6} ",
                GlobalClass.CustomerName,
                GlobalClass.OEM,
                GlobalClass.Location,
                GlobalClass.EquipmentTagNo,
                GlobalClass.Kilnsize,
                GlobalClass.NoOfbases,
                GlobalClass.ProjectContractNo);
            }
            else
            {
                MessageBox.Show("Please enter the mandatory fields");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            GlobalClass.Isclose = true;
            this.Close();
        }
    }
}
