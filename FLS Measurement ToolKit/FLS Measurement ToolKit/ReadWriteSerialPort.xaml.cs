using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for ReadWriteSerialPort.xaml
    /// </summary>
    public partial class ReadWriteSerialPort : MetroWindow
    {
        SerialPort serialPortObj = new SerialPort();
        public ReadWriteSerialPort()
        {

            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
        }

        //private void btnOk_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void btnCancel_Click(object sender, RoutedEventArgs e)
        //{

        //}
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadWriteGrid.IsEnabled = false;
                OnProgressRing.IsActive = true;
                //   OnProgressBar.IsIndeterminate = true;                
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please give a valid port number or check your connection" + ex);
                GlobalClass.Isclose = true;
                this.Close();
            }
        }
        private async void GetData()
        {
            try
            {

                await Dispatcher.BeginInvoke(new ThreadStart(() =>
                {
                    Task.Delay(30000);
                    List<string> ListOfvalues = new List<string>();
                    //List<string[]> ListOfvalues = new List<string[]>();
                    String portName = GlobalClass.ComNumber;
                    serialPortObj.PortName = portName;
                    serialPortObj.BaudRate = 250000;//115200;//9600;
                    //serialPortObj.ReadTimeout = 9600;
                    serialPortObj.Open();
                    txtMessage.Text = "Connected";
                    Thread.Sleep(1000);
                    //status.Text = "Connected";
                    bool finishedReading = false;
                    string value = string.Empty;

                    serialPortObj.Write("get_readings");
                    string key = serialPortObj.ReadLine();
                    if (key.Contains("get_readings"))
                    {

                        while (!finishedReading)
                        {
                            string temp = string.Empty;
                            //string[] tempArray = new string[] { };                        
                            temp = serialPortObj.ReadLine();
                            if (temp.Trim() == string.Empty)
                            {

                            }
                            else if (temp.Contains("end_csv"))
                            {
                                finishedReading = true;
                                serialPortObj.Close();
                            }
                            else
                            {
                                value = value + temp;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to Connect");
                        serialPortObj.Close();
                    }
                    File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\NewData1.CSV", value);
                    GlobalClass.CSVPath = @"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\NewData1.CSV";
                    this.Close();
                }));

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please give a valid port number or check your connection" + ex);
                GlobalClass.Isclose = true;
                this.Close();
            }
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPortObj.Close();
                txtMessage.Text = "Disconnected";
                //status.Text = "Disconnected";
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("First Connect and then disconnect");
                GlobalClass.Isclose = true;
                this.Close();
            }

        }
        private void storeListValueToExcel(List<string> ListOfvalues)
        {
            var csv = new StringBuilder();
            string delimiter = "";
            csv.Append(ListOfvalues.Aggregate((i, j) => i + delimiter + j));

            File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\NewData1.CSV", csv.ToString());

        }
    }
}
