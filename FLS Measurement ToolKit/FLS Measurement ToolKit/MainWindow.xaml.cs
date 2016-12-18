using log4net;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FLS_Measurement_ToolKit
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static readonly ILog logger =
          LogManager.GetLogger(typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            //          XmlConfiguration.Configure();
        }
        /// <summary>
        /// On page load the following method is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //webBrowserRadial.NavigateToString(Resource.RadialTemplate);
            //webBrowserAxial.NavigateToString(Resource.AxialTemplate);
        }
        /// <summary>
        /// On clicking the Browsbtn in radial screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>        
        public void DisplayRadialGraphByValue(string NoOfSensorValueToCommaSeperated, string SensorValueToCommaSeperated, string SensorAvgValueToCommaSeperatedRadial)
        {
            try
            {
                string GraphDiplayValue = string.Empty;
                GraphDiplayValue = Resource.RadialTemplate.Replace("{NO_OF_VALUE_IN_GRAPH}", NoOfSensorValueToCommaSeperated);
                GraphDiplayValue = GraphDiplayValue.Replace("{MEASURED_VALUE_IN_GRAPH}", SensorValueToCommaSeperated);
                GraphDiplayValue = GraphDiplayValue.Replace("{AVG_VALUE_IN_GRAPH}", SensorAvgValueToCommaSeperatedRadial);
                webBrowserRadial.NavigateToString(GraphDiplayValue);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public void DisplayAxialGraphByValue(string NoOfSensorValueToCommaSeperated, string SensorValueToCommaSeperated)
        {
            try
            {
                string GraphDiplayValue = string.Empty;
                GraphDiplayValue = Resource.AxialTemplate.Replace("{NoOfSensorValueToCommaSeperated}", NoOfSensorValueToCommaSeperated);
                GraphDiplayValue = GraphDiplayValue.Replace("{SENSOR_VALUES_LABEL_COUNTS}", SensorValueToCommaSeperated);
                webBrowserAxial.NavigateToString(GraphDiplayValue);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog btnBrowsRadialDialog = new Microsoft.Win32.OpenFileDialog();



                // Set filter for file extension and default file extension 
                btnBrowsRadialDialog.DefaultExt = ".xls";
                btnBrowsRadialDialog.Filter = "Excel Files (*.xls)|*.xlx|CSV Files (*.csv)|*.csv";


                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = btnBrowsRadialDialog.ShowDialog();
                ChannelSensorSelect ChannelSensorSelectObj = new ChannelSensorSelect();
                ChannelSensorSelectObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                MeasurementSelect MeasurementSelectObj = new MeasurementSelect();
                MeasurementSelectObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    // Open document 
                    string filename = btnBrowsRadialDialog.FileName;
                    //Tobetested
                    //ImportCsvFileAndDisplayGraph(filename);
                    if (GlobalClass.MeasurementType == "RADIAL")
                    {
                        TabRadial.IsEnabled = true;
                        TabAxial.IsEnabled = false;
                        if (!string.IsNullOrEmpty(filename))
                        {
                            OnlineImportCsvFileAndDisplayRadialGraph(filename);
                        }
                    }
                    else if (GlobalClass.MeasurementType == "AXIAL")
                    {
                        TabRadial.IsEnabled = false;
                        TabAxial.IsEnabled = true;
                        if (!string.IsNullOrEmpty(filename))
                        {
                            OnlineImportCsvFileAndDisplayAxialGraph(filename);
                        }
                    }
                }
                tboxRadialThresholdVal.Background = System.Windows.Media.Brushes.Green;
                tboxAxialThresholdVal.Background = System.Windows.Media.Brushes.Green;
                UpdateTextValue();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                COMPortSelectionWindow COMPortSelectionWindowObj = new COMPortSelectionWindow();
                COMPortSelectionWindowObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                ChannelSensorSelect ChannelSensorSelectObj = new ChannelSensorSelect();
                ChannelSensorSelectObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                MeasurementSelect MeasurementSelectObj = new MeasurementSelect();
                MeasurementSelectObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                AddInfoWindow AddInfoWindowObj = new AddInfoWindow();
                AddInfoWindowObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                GearInfoWindow GearInfoWindowObj = new GearInfoWindow();
                GearInfoWindowObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                ReadWriteSerialPort ReadWriteSerialPortObj = new ReadWriteSerialPort();
                ReadWriteSerialPortObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                if (GlobalClass.MeasurementType == "RADIAL")
                {
                    TabRadial.IsEnabled = true;
                    TabAxial.IsEnabled = false;
                    if (!string.IsNullOrEmpty(GlobalClass.CSVPath))
                    {
                        OnlineImportCsvFileAndDisplayRadialGraph(GlobalClass.CSVPath);
                    }
                }
                else if (GlobalClass.MeasurementType == "AXIAL")
                {
                    TabRadial.IsEnabled = false;
                    TabAxial.IsEnabled = true;
                    if (!string.IsNullOrEmpty(GlobalClass.CSVPath))
                    {
                        OnlineImportCsvFileAndDisplayAxialGraph(GlobalClass.CSVPath);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void UpdateTextValue()
        {
            try
            {
                //tboxRPeakValMeasured.Text = "0.42mm";
                //tboxRMinValMeasured.Text = "-0.42mm";
                //tboxRPeakValAtMeasured.Text = "47";
                //tboxRMinValAtMeasured.Text = "303";
                //tboxRTotalRadialRunOutMeasured.Text = "+/- 0.453";
                //tboxRadialThresholdVal.Text = "Yes";
                //tboxSensorSelected.Text = "30mm";
                //tboxChannelSelected.Text = "Channel 1";
                tboxMeasurementValue.Text = "mm";
                //tboxAPeakValMeasured.Text = "5.00mm";
                //tboxAMinValMeasured.Text = "4.05mm";
                //tboxAPeakValAtMeasured.Text = "52";
                //tboxAMinValAtMeasured.Text = "295";
                //tboxATotalRadialRunOutMeasured.Text = "0.425mm";
                //tboxAxialThresholdVal.Text = "Yes";
                //tboxASensorSelected.Text = "30mm";
                //tboxAChannelSelected.Text = "Channel 2";
                tboxAMeasurementValue.Text = "mm";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void ExportRadialGraphToPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rect bounds = VisualTreeHelper.GetDescendantBounds(webBrowserRadial);
                System.Windows.Point p0 = webBrowserRadial.PointToScreen(bounds.TopLeft);
                System.Drawing.Point p1 = new System.Drawing.Point((int)p0.X, (int)p0.Y);
                Bitmap image = new Bitmap((int)bounds.Width, (int)bounds.Height);
                Graphics imgGraphics = Graphics.FromImage(image);
                imgGraphics.CopyFromScreen(p1.X, p1.Y,
                                           0, 0,
                                           new System.Drawing.Size((int)bounds.Width,
                                                                        (int)bounds.Height));
                image.Save(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\New.bmp", ImageFormat.Bmp);
                GenratePDF GenratePDFObj = new GenratePDF();
                GenratePDFObj.PdfSharpConvert();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public void OnlineImportCsvFileAndDisplayRadialGraph(string filename)
        {
            try
            {
                FileInfo file = new FileInfo(filename);

                using (OleDbConnection con =
                        new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                        file.DirectoryName + "\"; Extended Properties = 'text;HDR=Yes;FMT=Delimited(,)'; "))
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format
                                              ("SELECT * FROM [{0}]", file.Name), con))
                    {
                        con.Open();

                        // Using a DataReader to process the data
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the current reader entry...
                            }
                        }

                        // Using a DataTable to process the data
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            DataTable ScensorValueTable = new DataTable("ScensorValueTable");
                            adp.Fill(ScensorValueTable);
                            string SensorValueToCommaSeperated = string.Empty;
                            string SensorValueToCommaSeperatedRadial = string.Empty;
                            int CountOfSensorValueRadial = 1;

                            string NoOfSensorValueToCommaSeperated = string.Empty;
                            string NoOfSensorValueToCommaSeperatedRadial = string.Empty;
                            string SensorAvgValueToCommaSeperatedRadial = string.Empty;
                            double AvgValueOfSensor = 0.0000;
                            ScensorValueTable = RadialComputingSensorValues(ScensorValueTable);
                            ScensorValueTable = ConvertingToDistanceValue(ScensorValueTable);
                            if (ScensorValueTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Invalid Data Read");
                                GlobalClass.Isclose = true;
                                return;
                            }
                            var AvgValueOfSensorFromTable = string.Format("{0}", ScensorValueTable.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Average(a => double.Parse(a[0].ToString())));
                            if (!string.IsNullOrEmpty(AvgValueOfSensorFromTable))
                                AvgValueOfSensor = double.Parse(AvgValueOfSensorFromTable);
                            ScensorValueTable = ComputeGraphPlotingValue(ScensorValueTable);
                            //foreach (DataRow ScensorValueTableRow in ScensorValueTable.Rows)
                            //{
                            //    if (ScensorValueTableRow[0].ToString().Trim() != string.Empty)
                            //        totalValueOfSensor = Convert.ToDouble(ScensorValueTableRow[0]) + totalValueOfSensor;
                            //}
                            //if (totalValueOfSensor > 0 && ScensorValueTable.Rows.Count > 0)
                            //    AvgValueOfSensor = totalValueOfSensor / ScensorValueTable.Rows.Count;

                            foreach (DataRow ScensorValueTableRow in ScensorValueTable.Rows)
                            {
                                if (ScensorValueTableRow[0].ToString().Trim() != string.Empty)
                                {
                                    SensorValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "value",
                                        ":", ScensorValueTableRow[0].ToString(), "}", ",", SensorValueToCommaSeperatedRadial);
                                    NoOfSensorValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "label",
                                        ":", CountOfSensorValueRadial.ToString(), "}", ",", NoOfSensorValueToCommaSeperatedRadial);

                                    SensorAvgValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "value",
                                        ":", AvgValueOfSensor.ToString(), "}", ",", SensorAvgValueToCommaSeperatedRadial);
                                    CountOfSensorValueRadial = CountOfSensorValueRadial + 1;
                                }
                            }

                            NoOfSensorValueToCommaSeperatedRadial = NoOfSensorValueToCommaSeperatedRadial.Remove(NoOfSensorValueToCommaSeperatedRadial.Length - 1);
                            SensorValueToCommaSeperatedRadial = SensorValueToCommaSeperatedRadial.Remove(SensorValueToCommaSeperatedRadial.Length - 1);
                            SensorAvgValueToCommaSeperatedRadial = SensorAvgValueToCommaSeperatedRadial.Remove(SensorAvgValueToCommaSeperatedRadial.Length - 1);
                            DisplayRadialGraphByValue(NoOfSensorValueToCommaSeperatedRadial, SensorValueToCommaSeperatedRadial, SensorAvgValueToCommaSeperatedRadial);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public void OnlineImportCsvFileAndDisplayAxialGraph(string filename)
        {
            try
            {
                FileInfo file = new FileInfo(filename);

                using (OleDbConnection con =
                        new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                        file.DirectoryName + "\"; Extended Properties = 'text;HDR=Yes;FMT=Delimited(,)'; "))
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format
                                              ("SELECT * FROM [{0}]", file.Name), con))
                    {
                        con.Open();

                        // Using a DataReader to process the data
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the current reader entry...
                            }
                        }

                        // Using a DataTable to process the data
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            DataTable ScensorValueTable = new DataTable("ScensorValueTable");
                            adp.Fill(ScensorValueTable);
                            string SensorValueToCommaSeperated = string.Empty;
                            int CountOfSensorValueAxial = 1;
                            string NoOfSensorValueToCommaSeperated = string.Empty;
                            double AvgValueOfSensor = 0.0000;
                            ScensorValueTable = AxialComputingSensorValues(ScensorValueTable);
                            ScensorValueTable = ConvertingToDistanceValue(ScensorValueTable);

                            var AvgValueOfSensorFromTable = string.Format("{0}", ScensorValueTable.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Average(a => double.Parse(a[0].ToString())));
                            if (!string.IsNullOrEmpty(AvgValueOfSensorFromTable))
                                AvgValueOfSensor = double.Parse(AvgValueOfSensorFromTable);
                            foreach (DataRow ScensorValueTableRow in ScensorValueTable.Rows)
                            {
                                if (ScensorValueTableRow[0].ToString().Trim() != string.Empty)
                                {

                                    SensorValueToCommaSeperated = SensorValueToCommaSeperated + string.Format("{0}\"{1}\"{2} \"{3}\",\"{4}\":\"{5}\"{6}{7}", "{", "label",
                                        ":", CountOfSensorValueAxial.ToString(), "value", ScensorValueTableRow[0].ToString(), "}", ",");
                                    CountOfSensorValueAxial = CountOfSensorValueAxial + 1;
                                }
                            }
                            SensorValueToCommaSeperated = SensorValueToCommaSeperated.Remove(SensorValueToCommaSeperated.Length - 1);
                            DisplayAxialGraphByValue(NoOfSensorValueToCommaSeperated, SensorValueToCommaSeperated);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        public DataTable ComputeGraphPlotingValue(DataTable ScensorValueTable)
        {
            DataTable ComputedValues = new DataTable();
            ComputedValues.Columns.Add("SensorValue");
            ComputedValues.Columns.Add("Proxy");
            ComputedValues.Columns.Add("Rank");
            try
            {
                int avgValue;
                int NoOfRows = ScensorValueTable.Rows.Count;
                if (NoOfRows > 0)
                {
                    avgValue = (int)Math.Floor(Convert.ToDecimal(NoOfRows / 100));
                    int i;
                    int valfrom = 1;
                    int valTo = avgValue;
                    for (i = 0; i < 100; i++)
                    {

                        var ScensorValueAvg = ScensorValueTable.AsEnumerable().Where(
                            x => Convert.ToInt32(x[2]) >= valfrom && Convert.ToInt32(x[2]) <= valTo).Average(
                            x => Convert.ToDouble(x.Field<string>("SensorValue")));
                        //.Where(
                        //a => Convert.ToInt32(a["Rank"]) >= valfrom && Convert.ToInt32(a["Rank"]) <= valTo).Select( ));
                        //var sensorValue = (from val in ScensorValueTableList
                        //                   where val.Field<int>(2) >= valfrom && val.Field<int>(2) <= valTo

                        //                   select val);// val.Field<decimal>("SensorValue"));
                        ComputedValues.Rows.Add(ScensorValueAvg.ToString(), "0", (i + 1).ToString());
                        valfrom = valfrom + avgValue;
                        valTo = valTo + avgValue;
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ComputedValues;

        }
        public DataTable RadialComputingSensorValues(DataTable ScensorValueTable)
        {

            DataTable firstItrationValues = new DataTable();
            firstItrationValues.Columns.Add("SensorValue");
            firstItrationValues.Columns.Add("Proxy");
            DataTable secondItrationValues = new DataTable();
            secondItrationValues.Columns.Add("SensorValue");
            secondItrationValues.Columns.Add("Proxy");
            secondItrationValues.Columns.Add("Rank");
            DataTable thirdItrationValues = new DataTable();
            thirdItrationValues.Columns.Add("SensorValue");
            thirdItrationValues.Columns.Add("Proxy");
            try
            {
                bool rotationStartFlag = false;
                int NoRotation = 0;
                int NoOfRows = 0;
                foreach (DataRow ScensorValueRow in ScensorValueTable.Rows)
                {
                    if (ScensorValueRow[1].ToString() == "1")
                    {
                        if (rotationStartFlag == false)
                        {
                            continue;
                        }
                        else
                        {
                            rotationStartFlag = false;
                            continue;
                        }
                    }
                    else if (ScensorValueRow[1].ToString() == "0")
                    {
                        if (rotationStartFlag == true)
                        {
                            // Do nothing   
                        }
                        else
                        {
                            rotationStartFlag = true;
                            NoRotation++;
                        }
                    }
                    if (NoRotation == 1)
                    {
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            firstItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString());
                    }
                    else if (NoRotation == 2)
                    {
                        NoOfRows++;
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            secondItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), NoOfRows);
                    }
                    else if (NoRotation == 3)
                    {
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            thirdItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString());
                    }
                }
                double maxInFirstItrationValue = 0;
                double minInFirstItrationValue = 0;
                double maxSecondItrationValue = 0;
                double minSecondItrationValue = 0;
                double maxThirdItrationValue = 0;
                double minThirdItrationValue = 0;
                double firstItrationRadialRunOutMeasurement = 0;
                double secondItrationRadialRunOutMeasurement = 0;
                double thirdItrationRadialRunOutMeasurement = 0;

                if (firstItrationValues.Rows.Count > 0)
                {
                    var maxInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxInFirstItrationValue = string.IsNullOrEmpty(maxInFirstItration) ? 0 : double.Parse(maxInFirstItration);
                    var minInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minInFirstItrationValue = string.IsNullOrEmpty(minInFirstItration) ? 0 : double.Parse(minInFirstItration);
                }
                if (secondItrationValues.Rows.Count > 0)
                {
                    var maxSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxSecondItrationValue = string.IsNullOrEmpty(maxSecondItration) ? 0 : double.Parse(maxSecondItration);
                    var minSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minSecondItrationValue = string.IsNullOrEmpty(minSecondItration) ? 0 : double.Parse(minSecondItration);
                }
                if (thirdItrationValues.Rows.Count > 0)
                {
                    var maxThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxThirdItrationValue = string.IsNullOrEmpty(maxThirdItration) ? 0 : double.Parse(maxThirdItration);
                    var minThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minThirdItrationValue = string.IsNullOrEmpty(minThirdItration) ? 0 : double.Parse(minThirdItration);
                }
                firstItrationRadialRunOutMeasurement = (ScensorDistanceCalculation(maxInFirstItrationValue) - ScensorDistanceCalculation(minInFirstItrationValue)) / 2;
                secondItrationRadialRunOutMeasurement = (ScensorDistanceCalculation(maxSecondItrationValue) - ScensorDistanceCalculation(minSecondItrationValue)) / 2;
                thirdItrationRadialRunOutMeasurement = (ScensorDistanceCalculation(maxThirdItrationValue) - ScensorDistanceCalculation(minThirdItrationValue)) / 2;
                double avgItrationRadialRunOutMeasurement = (firstItrationRadialRunOutMeasurement + secondItrationRadialRunOutMeasurement + thirdItrationRadialRunOutMeasurement) / 3;
                System.IO.File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\Detail.txt",
                    string.Format("firstItrationRadialRunOutMeasurement:{0} \n secondItrationRadialRunOutMeasurement:{1} \n thirdItrationRadialRunOutMeasurement:{2}",
                    firstItrationRadialRunOutMeasurement, secondItrationRadialRunOutMeasurement, thirdItrationRadialRunOutMeasurement));
                tboxRPeakValMeasured.Text = string.Format("{0}", maxSecondItrationValue);
                tboxRMinValMeasured.Text = string.Format("{0}", minSecondItrationValue);
                tboxSensorSelected.Text = string.Format("{0}", GlobalClass.SensorSelected);
                tboxChannelSelected.Text = string.Format("{0}", GlobalClass.ChannelSelected);
                tboxRTotalRadialRunOutMeasured.Text = string.Format("{0}", avgItrationRadialRunOutMeasurement);
                //ConvertingToDistanceValue(secondItrationValues);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return secondItrationValues;
        }
        public DataTable AxialComputingSensorValues(DataTable ScensorValueTable)
        {
            DataTable firstItrationValues = new DataTable();
            firstItrationValues.Columns.Add("SensorValue");
            firstItrationValues.Columns.Add("Proxy");
            DataTable secondItrationValues = new DataTable();
            secondItrationValues.Columns.Add("SensorValue");
            secondItrationValues.Columns.Add("Proxy");
            DataTable thirdItrationValues = new DataTable();
            thirdItrationValues.Columns.Add("SensorValue");
            thirdItrationValues.Columns.Add("Proxy");
            try
            {
                bool rotationStartFlag = false;
                int NoRotation = 0;
                foreach (DataRow ScensorValueRow in ScensorValueTable.Rows)
                {
                    if (ScensorValueRow[1].ToString() == "1")
                    {
                        if (rotationStartFlag == false)
                        {
                            continue;
                        }
                        else
                        {
                            rotationStartFlag = false;
                            continue;
                        }
                    }
                    else if (ScensorValueRow[1].ToString() == "0")
                    {
                        if (rotationStartFlag == true)
                        {
                            // Do nothing
                        }
                        else
                        {
                            rotationStartFlag = true;
                            NoRotation++;
                        }
                    }
                    if (NoRotation == 1)
                    {
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            firstItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString());
                    }
                    else if (NoRotation == 2)
                    {
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            secondItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString());
                    }
                    else if (NoRotation == 3)
                    {
                        if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            thirdItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString());
                    }
                }
                double maxInFirstItrationValue = 0;
                double minInFirstItrationValue = 0;
                double maxSecondItrationValue = 0;
                double minSecondItrationValue = 0;
                double maxThirdItrationValue = 0;
                double minThirdItrationValue = 0;
                double firstItrationAxialRunOutMeasurement = 0;
                double secondItrationAxialRunOutMeasurement = 0;
                double thirdItrationAxialRunOutMeasurement = 0;
                if (firstItrationValues.Rows.Count > 0)
                {
                    CalculateMaxMINAxialRunOut(firstItrationValues, out maxInFirstItrationValue, out minInFirstItrationValue);
                }
                if (secondItrationValues.Rows.Count > 0)
                {
                    CalculateMaxMINAxialRunOut(secondItrationValues, out maxSecondItrationValue, out minSecondItrationValue);
                }
                if (thirdItrationValues.Rows.Count > 0)
                {
                    CalculateMaxMINAxialRunOut(thirdItrationValues, out maxThirdItrationValue, out minThirdItrationValue);
                }
                firstItrationAxialRunOutMeasurement = (ScensorDistanceCalculation(maxInFirstItrationValue) - ScensorDistanceCalculation(minInFirstItrationValue)) / 2;
                secondItrationAxialRunOutMeasurement = (ScensorDistanceCalculation(maxSecondItrationValue) - ScensorDistanceCalculation(minSecondItrationValue)) / 2;
                thirdItrationAxialRunOutMeasurement = (ScensorDistanceCalculation(maxThirdItrationValue) - ScensorDistanceCalculation(minThirdItrationValue)) / 2;
                double avgItrationAxialRunOutMeasurement = (firstItrationAxialRunOutMeasurement + secondItrationAxialRunOutMeasurement + thirdItrationAxialRunOutMeasurement) / 3;
                System.IO.File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\AxialDetail.txt",
                    string.Format("firstItrationRadialRunOutMeasurement:{0} \n secondItrationRadialRunOutMeasurement:{1} \n thirdItrationRadialRunOutMeasurement:{2}",
                    firstItrationAxialRunOutMeasurement, secondItrationAxialRunOutMeasurement, thirdItrationAxialRunOutMeasurement));
                tboxAPeakValMeasured.Text = string.Format("{0}", maxSecondItrationValue);
                tboxAMinValMeasured.Text = string.Format("{0}", minSecondItrationValue);
                tboxASensorSelected.Text = string.Format("{0}", GlobalClass.SensorSelected);
                tboxAChannelSelected.Text = string.Format("{0}", GlobalClass.ChannelSelected);
                tboxATotalRadialRunOutMeasured.Text = string.Format("{0}", avgItrationAxialRunOutMeasurement);
                //ConvertingToDistanceValue(secondItrationValues);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return secondItrationValues;
        }
        public double ScensorDistanceCalculation(double value)
        {
            if (GlobalClass.SensorSelected == "m12_sensor")
                return (0.36 * value) + .40;
            else if (GlobalClass.SensorSelected == "m18_sensor")
                return (0.72 * value) + 0.80;
            else if (GlobalClass.SensorSelected == "m30_sensor")
                return (1.40 * value) + 1;
            else if (GlobalClass.SensorSelected == "rectangular_sensor")
                return (2.40 * value) + 1;
            else
                return (0.36 * value) + .40;
        }
        public DataTable ConvertingToDistanceValue(DataTable ScensorValueTable)
        {

            DataTable ScensorCalculatedValueTable = new DataTable();
            ScensorCalculatedValueTable.Columns.Add("SensorValue");
            ScensorCalculatedValueTable.Columns.Add("Proxy");
            ScensorCalculatedValueTable.Columns.Add("Rank");
            try
            {
                foreach (DataRow SensorValueRow in ScensorValueTable.Rows)
                {
                    ScensorCalculatedValueTable.Rows.Add(string.Format("{0}", ScensorDistanceCalculation(double.Parse(SensorValueRow[0].ToString()))), SensorValueRow[0].ToString(), SensorValueRow[2].ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            //var ValueOfItration= ScensorValueTable.AsEnumerable().Select(b => b[0] =string.Format("{0}", ScensorDistanceCalculation(double.Parse(b[0].ToString()))));
            //return ValueOfItration;
            return ScensorCalculatedValueTable;
        }
        public void CalculateMaxMINAxialRunOut(DataTable ItrationAxialRunOutMeasurement, out double maxInItrationValue, out double minInItrationValue)
        {
            DataTable ItrationValues1 = new DataTable();
            ItrationValues1.Columns.Add("SensorValue");
            ItrationValues1.Columns.Add("Proxy");
            ItrationValues1.Columns.Add("RowValue");
            DataTable ItrationValues2 = new DataTable();
            ItrationValues2.Columns.Add("SensorValue");
            ItrationValues2.Columns.Add("Proxy");
            ItrationValues2.Columns.Add("RowValue");
            DataTable finalItrationValues = new DataTable();
            finalItrationValues.Columns.Add("SensorValue");

            int splitvalue = 0;
            int splitCount1 = 1;
            int splitCount2 = 1;
            int itration = 0;
            if (ItrationAxialRunOutMeasurement.Rows.Count % 2 == 0)
                splitvalue = ItrationAxialRunOutMeasurement.Rows.Count / 2;
            else
                splitvalue = (ItrationAxialRunOutMeasurement.Rows.Count - 1) / 2;

            foreach (DataRow ItrationAxialRow in ItrationAxialRunOutMeasurement.Rows)
            {
                itration++;
                if (splitvalue >= itration)
                {
                    ItrationValues1.Rows.Add(ItrationAxialRow[0], ItrationAxialRow[1], splitCount1);
                    splitCount1++;
                }
                else
                {
                    ItrationValues2.Rows.Add(ItrationAxialRow[0], ItrationAxialRow[1], splitCount1);
                    splitCount2++;
                }
            }
            for (int i = 1; i < splitvalue; i++)
            {
                finalItrationValues.Rows.Add(string.Format("{0}", double.Parse(ItrationValues1.Rows[i][0].ToString()) - double.Parse(ItrationValues2.Rows[i][0].ToString())));
                finalItrationValues.Rows.Add(string.Format("{0}", double.Parse(ItrationValues1.Rows[i][0].ToString()) - double.Parse(ItrationValues1.Rows[i][0].ToString())));
            }
            var maxInFirstItration = string.Format("{0}", finalItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
            maxInItrationValue = string.IsNullOrEmpty(maxInFirstItration) ? 0 : double.Parse(maxInFirstItration);
            var minInFirstItration = string.Format("{0}", finalItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
            minInItrationValue = string.IsNullOrEmpty(minInFirstItration) ? 0 : double.Parse(minInFirstItration);

        }
        private void ExportAxialGraphToPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rect bounds = VisualTreeHelper.GetDescendantBounds(webBrowserAxial);
                System.Windows.Point p0 = webBrowserAxial.PointToScreen(bounds.TopLeft);
                System.Drawing.Point p1 = new System.Drawing.Point((int)p0.X, (int)p0.Y);
                Bitmap image = new Bitmap((int)bounds.Width, (int)bounds.Height);
                Graphics imgGraphics = Graphics.FromImage(image);
                imgGraphics.CopyFromScreen(p1.X, p1.Y,
                                           0, 0,
                                           new System.Drawing.Size((int)bounds.Width,
                                                                        (int)bounds.Height));
                image.Save(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\New.bmp", ImageFormat.Bmp);
                GenratePDF GenratePDFObj = new GenratePDF();
                GenratePDFObj.PdfSharpConvert();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
