using log4net.Config;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _CurrentPathLocation;
        private readonly string _OnlineReadingRecordedFileName;
        private readonly string _OnlineReadingRecordedfile;
        SerialPort serialPortObj = new SerialPort();
        System.IO.TextWriter _textWriter;
        public ReadWriteSerialPort()
        {

            this.ShowMinButton = false;
            this.ShowMaxRestoreButton = false;
            this.ShowCloseButton = false;
            InitializeComponent();
            XmlConfigurator.Configure();
            _CurrentPathLocation = AppDomain.CurrentDomain.BaseDirectory;
            _OnlineReadingRecordedFileName = "RecordedFile.CSV";
            _OnlineReadingRecordedfile = System.IO.Path.Combine(_CurrentPathLocation, _OnlineReadingRecordedFileName);
            _textWriter = new StreamWriter(_OnlineReadingRecordedfile);

            // readingAcquiretxt.Text = "Click on START to acquire readings from sensor.";
        }
        public bool IsNumeric(object Expression)
        {
            double retNum;
            try
            {
                bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
                return isNum;
            }
            catch
            {
                return false;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (noItrRequirdTxtBox.Text == string.Empty)
                {
                    MessageBox.Show("Enter Mandatory Field");
                    return;
                }
                else if (!IsNumeric(noItrRequirdTxtBox.Text))
                {
                    MessageBox.Show("Enter Numeric Value from 1-3");
                    return;
                }
                else if (!(Convert.ToInt32(noItrRequirdTxtBox.Text) > 0 && Convert.ToInt32(noItrRequirdTxtBox.Text) < 4))
                {
                    MessageBox.Show("Enter Numeric Value from 1-3");
                    return;
                }
                else
                {
                    GlobalClass.ItrationRequired = Convert.ToInt32(noItrRequirdTxtBox.Text);
                }
                //   OnProgressBar.IsIndeterminate = true;                
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    try
                    {
                        // Call your device
                        // If ou need to interact with the main thread
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                                        {
                                            try
                                            {
                                                Task.Delay(30000);
                                                List<string> ListOfvalues = new List<string>();
                                                //List<string[]> ListOfvalues = new List<string[]>();
                                                String portName = GlobalClass.ComNumber;
                                                serialPortObj.PortName = portName;
                                                serialPortObj.BaudRate = 250000;//115200;//9600;
                                                serialPortObj.ReadTimeout = 9600;
                                                serialPortObj.Open();
                                                Thread.Sleep(1000);
                                                serialPortObj.Write("noofrotation" + noItrRequirdTxtBox.Text.Trim());
                                                string key1 = serialPortObj.ReadLine();
                                                if (!key1.Contains("rotationsacquired"))
                                                {
                                                    MessageBox.Show("Unable to connect");
                                                    return;
                                                }
                                                //status.Text = "Connected";
                                                bool finishedReading = false;
                                                string value = string.Empty;
                                                Thread.Sleep(1000);
                                                serialPortObj.Write("get_readings");
                                                Thread.Sleep(1000);
                                                string key = serialPortObj.ReadLine();
                                                if (key.Contains("get_readings"))
                                                {
                                                    bool endFirstVal = false;
                                                    int NumOfRotaion = 0;
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
                                                            _textWriter.Close();
                                                        }
                                                        else if (temp.Contains(",1"))
                                                        {
                                                            if (endFirstVal)
                                                            {
                                                                endFirstVal = false;
                                                                _textWriter.WriteLine(temp);
                                                                NumOfRotaion++;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            endFirstVal = true;
                                                            _textWriter.WriteLine(temp);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    logger.Info("Unable to Connect");
                                                    MessageBox.Show("Unable to Connect");
                                                    serialPortObj.Close();
                                                }
                                                GlobalClass.CSVPath = _OnlineReadingRecordedfile;
                                                this.Close();
                                            }
                                            catch (Exception EX)
                                            {
                                                logger.Error(EX);
                                                _textWriter.Close();
                                                MessageBox.Show("Please give a valid port number or check your connection");
                                                GlobalClass.Isclose = true;
                                                this.Close();
                                            }
                                        }));
                    }
                    catch (Exception EX)
                    {
                        logger.Error(EX);
                        MessageBox.Show("Please give a valid port number or check your connection");
                        GlobalClass.Isclose = true;
                        this.Close();
                    }
                };
                //This event is raise on DoWork complete
                worker.RunWorkerCompleted += (o, ea) =>
                {
                    //Work to do after the long process
                    //disableGui = false;

                };
                // GetData();
                //disableGui = true;
                //Launch you worker                
                ReadWriteGrid.IsEnabled = false;
                //Ring.IsEnabled = true;
                //OnProgressRing.IsActive = true;
                worker.RunWorkerAsync();


            }
            catch (Exception EX)
            {
                serialPortObj.Close();
                logger.Error(EX);
                MessageBox.Show("Please check your connection");
                GlobalClass.Isclose = true;
                this.Close();
            }
        }
        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                serialPortObj.Close();                
                _textWriter.Close();
                //status.Text = "Disconnected";
                this.Close();
            }
            catch (Exception EX)
            {
                serialPortObj.Close();
                logger.Error(EX);
                MessageBox.Show("First Connect and then disconnect");
                GlobalClass.Isclose = true;
                this.Close();
            }

        }
    }
}
