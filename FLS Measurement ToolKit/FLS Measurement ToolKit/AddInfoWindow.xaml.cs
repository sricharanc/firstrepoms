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
        public AddInfoWindow()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
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
