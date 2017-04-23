using log4net.Config;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for COMPortSelectionWindow.xaml
    /// </summary>
    public partial class COMPortSelectionWindow : MetroWindow
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //SerialPort sp = new SerialPort();
        SerialPort serialPortObj = new SerialPort();
        public COMPortSelectionWindow()
        {
            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtComPortNumber.Text))
            {
                try
                {
                    String portName = "COM" + txtComPortNumber.Text;
                    //string key = "";
                    //sp.PortName = portName;
                    //sp.BaudRate = 250000;//19200;//115200;
                    //sp.ReadTimeout = 10000;
                    //sp.Open();
                    //sp.Write("0011");
                    //key = sp.ReadLine();
                    //MessageBox.Show(key);
                    //sp.Write("0");
                    //key = sp.ReadLine();
                    //// to be uncommented
                    GlobalClass.ComNumber = portName;
                    serialPortObj.PortName = portName;
                    serialPortObj.BaudRate = 250000; //9600;
                    serialPortObj.ReadTimeout = 12000;
                    serialPortObj.Open();
                    Thread.Sleep(1000);
                    string key = "";
                    serialPortObj.Write("0011");
                    key = serialPortObj.ReadLine();
                    if (key.Contains("CQCz4xqX"))
                    {
                        MessageBox.Show("Connected");
                    }
                    else
                    { MessageBox.Show("Not connected" + key + "::"); }
                    serialPortObj.Close();
                    this.Close();
                    logger.InfoFormat("Com Port connected with Values {0}", GlobalClass.ComNumber);
                }
                catch (Exception EX)
                {
                    logger.InfoFormat("Com Port unable connect with Values {0}, Exception:{1}  ", GlobalClass.ComNumber, EX);
                    serialPortObj.Close();
                    MessageBox.Show("Please give a valid port number or check your connection");
                    GlobalClass.Isclose = true;
                }
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
