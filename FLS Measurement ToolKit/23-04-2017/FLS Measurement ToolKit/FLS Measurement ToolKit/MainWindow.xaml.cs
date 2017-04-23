using log4net;
using log4net.Config;
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
using FLS_Measurement_ToolKit.Entities;
using System.Xml.Serialization;
using System.Xml;
using SpreadsheetLight;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing;

namespace FLS_Measurement_ToolKit
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly string _CurrentPathLocation;
        //private readonly string _OnlineReadingRecordedFileName;
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MainWindow()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            _CurrentPathLocation = AppDomain.CurrentDomain.BaseDirectory;
            //_OnlineReadingRecordedFileName = "RecordedFile.csv";
            //logger.Info("Aplication started");
            //XmlConfiguration.Configure();
        }
        #region Event
        /// <summary>
        /// On page load the following method is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            logger.Info("Aplication started...");
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                logger.Info("Opening CSV Path...");
                Microsoft.Win32.OpenFileDialog btnBrowsRadialDialog = new Microsoft.Win32.OpenFileDialog();
                // Set filter for file extension and default file extension 
                btnBrowsRadialDialog.DefaultExt = ".csv";
                btnBrowsRadialDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xls)|*.xlx";
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
                GearInfoWindow GearInfoWindowObj = new GearInfoWindow();
                GearInfoWindowObj.ShowDialog();
                if (GlobalClass.Isclose)
                {
                    GlobalClass.Isclose = false;
                    return;
                }
                OnProgressRing.BringIntoView();
                OnProgressRing.IsActive = true;
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
                OnProgressRing.IsActive = false;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
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
                OnProgressRing.BringIntoView();
                OnProgressRing.IsActive = true;
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
                    OnProgressRing.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
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
                image.Save(_CurrentPathLocation + "tempScreenshot.bmp", ImageFormat.Bmp);
                GenratePDF GenratePDFObj = new GenratePDF();
                GenratePDFObj.PdfSharpConvert(Resource.PDFAxialTemplate);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Document"; // Default file name
                dlg.DefaultExt = ".text"; // Default file extension
                dlg.Filter = "All documents (.xml)|*.xml"; // Filter files by extension
                string filename = string.Empty;
                // Show save file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    filename = dlg.FileName;
                    ConfigDetail ConfigDetailObj = new ConfigDetail();
                    CustomerInfo CustomerInfoObj = new CustomerInfo();

                    // Customer Info
                    CustomerInfoObj.CustomerName = GlobalClass.CustomerName;
                    CustomerInfoObj.OEM = GlobalClass.OEM;
                    CustomerInfoObj.Location = GlobalClass.Location;
                    CustomerInfoObj.EquipmentTagNo = GlobalClass.EquipmentTagNo;
                    CustomerInfoObj.KilnSize = GlobalClass.Kilnsize;
                    CustomerInfoObj.NoOfbases = GlobalClass.NoOfbases;
                    CustomerInfoObj.ProjectContractNo = GlobalClass.ProjectContractNo;

                    CustomerInfoObj.Typeofgear = GlobalClass.Typeofgear;
                    CustomerInfoObj.GearOuterDiameter = GlobalClass.GearOuterDiameter;
                    CustomerInfoObj.NoOfteeth = GlobalClass.NoOfteeth;
                    CustomerInfoObj.Gearfacewidth = GlobalClass.Gearfacewidth;
                    CustomerInfoObj.HelixAngle = GlobalClass.HelixAngle;
                    CustomerInfoObj.Directionofrotation = GlobalClass.Directionofrotation;
                    CustomerInfoObj.Noofdrive = GlobalClass.Noofdrive;
                    CustomerInfoObj.Typeofspringplate = GlobalClass.Typeofspringplate;
                    CustomerInfoObj.Klinshellthicknessundergear = GlobalClass.Klinshellthicknessundergear;
                    CustomerInfoObj.RotaionType = GlobalClass.RotaionType;

                    ConfigDetailObj.CustomerInfo = CustomerInfoObj;
                    XmlSerializer xsSubmit = new XmlSerializer(typeof(ConfigDetail));
                    var xml = "";
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = true;
                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww, settings))
                        {
                            xsSubmit.Serialize(writer, ConfigDetailObj);
                            xml = sww.ToString(); // Your XML
                        }
                    }
                    File.WriteAllText(filename, xml);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog btnBrowsRadialDialog = new Microsoft.Win32.OpenFileDialog();
                // Set filter for file extension and default file extension 
                btnBrowsRadialDialog.DefaultExt = ".csv";
                btnBrowsRadialDialog.Filter = "XML Files (*.xml)|*.xml";
                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = btnBrowsRadialDialog.ShowDialog();
                if (result != null && result == true)
                {
                    string filename = btnBrowsRadialDialog.FileName;
                    XmlSerializer serializer = new XmlSerializer(typeof(ConfigDetail));
                    ConfigDetail ConfigDetailObj = new ConfigDetail();
                    using (FileStream fileStream = new FileStream(filename, FileMode.Open))
                    {
                        UTF8Encoding utf8 = new UTF8Encoding();
                        ConfigDetailObj = (ConfigDetail)serializer.Deserialize(fileStream);
                    }

                    GlobalClass.CustomerName = ConfigDetailObj.CustomerInfo.CustomerName;
                    GlobalClass.OEM = ConfigDetailObj.CustomerInfo.OEM;
                    GlobalClass.Location = ConfigDetailObj.CustomerInfo.Location;
                    GlobalClass.EquipmentTagNo = ConfigDetailObj.CustomerInfo.EquipmentTagNo;
                    GlobalClass.Kilnsize = ConfigDetailObj.CustomerInfo.KilnSize;
                    GlobalClass.NoOfbases = ConfigDetailObj.CustomerInfo.NoOfbases;
                    GlobalClass.ProjectContractNo = ConfigDetailObj.CustomerInfo.ProjectContractNo;

                    GlobalClass.Typeofgear = ConfigDetailObj.CustomerInfo.Typeofgear;
                    GlobalClass.GearOuterDiameter = ConfigDetailObj.CustomerInfo.GearOuterDiameter;
                    GlobalClass.NoOfteeth = ConfigDetailObj.CustomerInfo.NoOfteeth;
                    GlobalClass.Gearfacewidth = ConfigDetailObj.CustomerInfo.Gearfacewidth;
                    GlobalClass.HelixAngle = ConfigDetailObj.CustomerInfo.HelixAngle;
                    GlobalClass.Directionofrotation = ConfigDetailObj.CustomerInfo.Directionofrotation;
                    GlobalClass.Noofdrive = ConfigDetailObj.CustomerInfo.Noofdrive;
                    GlobalClass.Typeofspringplate = ConfigDetailObj.CustomerInfo.Typeofspringplate;
                    GlobalClass.Klinshellthicknessundergear = ConfigDetailObj.CustomerInfo.Klinshellthicknessundergear;
                    GlobalClass.RotaionType = ConfigDetailObj.CustomerInfo.RotaionType;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }
        private void ExportRadialGraphToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog btnBrowsRadialDialog = new Microsoft.Win32.SaveFileDialog();
                // Set filter for file extension and default file extension 
                btnBrowsRadialDialog.DefaultExt = ".xlsx";
                btnBrowsRadialDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = btnBrowsRadialDialog.ShowDialog();
                if (result == true)
                {
                    // Open document 
                    string filename = btnBrowsRadialDialog.FileName;
                    string sourcefileName = "Format Radial.xlsx";
                    string sourcePath = _CurrentPathLocation;
                    string targetPath = filename;
                    string sourceFile = System.IO.Path.Combine(sourcePath, sourcefileName);
                    string destFile = filename;
                    System.IO.File.Copy(sourceFile, destFile, true);

                    // assign global value
                    SetExcelTemplateValues(destFile, "Radial");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }
        private void ExportAxialGraphToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog btnBrowsRadialDialog = new Microsoft.Win32.SaveFileDialog();
                // Set filter for file extension and default file extension 
                btnBrowsRadialDialog.DefaultExt = ".xls";
                btnBrowsRadialDialog.Filter = "Excel Files (*.xls)|*.xls";
                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = btnBrowsRadialDialog.ShowDialog();
                if (result == true)
                {
                    // Open document 
                    string filename = btnBrowsRadialDialog.FileName;
                    string sourcefileName = "Format Axial.xls";
                    string sourcePath = _CurrentPathLocation;
                    string targetPath = filename;
                    string sourceFile = System.IO.Path.Combine(sourcePath, sourcefileName);
                    string destFile = filename;
                    System.IO.File.Copy(sourceFile, destFile, true);
                    // assign global value
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }

        private void SetExcelTemplateValues(string filePath, string SheetName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                using (ExcelPackage p = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet ws = p.Workbook.Worksheets.First();
                    ws.Cells["B3"].Value = GlobalClass.Client;
                    ws.Cells["B4"].Value = GlobalClass.EquipmentTagNo;
                    ws.Cells["I3"].Value = "Todays date";

                    //Gear Details
                    ws.Cells["B7"].Value = GlobalClass.OEM;
                    ws.Cells["E7"].Value = GlobalClass.Typeofgear;
                    ws.Cells["H7"].Value = GlobalClass.Gearfacewidth;
                    ws.Cells["B8"].Value = GlobalClass.MeasurementType;
                    ws.Cells["E8"].Value = GlobalClass.NoOfteeth;
                    ws.Cells["H8"].Value = GlobalClass.HelixAngle;
                    ws.Cells["B9"].Value = GlobalClass.Typeofspringplate;
                    ws.Cells["E9"].Value = GlobalClass.Noofdrive;
                    ws.Cells["H9"].Value = GlobalClass.Directionofrotation;

                    ws.Cells["C43"].Value = GlobalClass.MeasuredAxialRunout;
                    ws.Cells["C44"].Value = GlobalClass.AllowableAxialRunout;
                    p.Save();
                }
            }
            catch (Exception) { throw; }
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
                image.Save(_CurrentPathLocation + "tempScreenshot.bmp", ImageFormat.Bmp);
                GenratePDF GenratePDFObj = new GenratePDF();
                GenratePDFObj.PdfSharpConvert(Resource.PDFRadialTemplate);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Unexpected data exception occured please retry");
            }
        }
        #endregion

        #region PrivateMethods 
        public void DisplayRadialGraphByValue(string NoOfSensorValueToCommaSeperated, string SensorValueToCommaSeperated, string SensorAvgValueToCommaSeperatedRadial,
                                              string TwelpointRep)
        {
            try
            {
                string GraphDiplayValue = string.Empty;
                GraphDiplayValue = Resource.RadialTemplate.Replace("{NO_OF_VALUE_IN_GRAPH}", NoOfSensorValueToCommaSeperated);
                GraphDiplayValue = GraphDiplayValue.Replace("{MEASURED_VALUE_IN_GRAPH}", SensorValueToCommaSeperated);
                GraphDiplayValue = GraphDiplayValue.Replace("{AVG_VALUE_IN_GRAPH}", SensorAvgValueToCommaSeperatedRadial);
                GraphDiplayValue = GraphDiplayValue.Replace("{TwelpointRep}", TwelpointRep);
                webBrowserRadial.NavigateToString(GraphDiplayValue);
            }
            catch (Exception ex)
            {
                throw;
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
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }
        public void OnlineImportCsvFileAndDisplayRadialGraph(string filename)
        {
            try
            {
                FileInfo file = new FileInfo(filename);
                DataTable ScensorValueTable = new DataTable();
                ScensorValueTable.Columns.Add("SensorValue");
                ScensorValueTable.Columns.Add("Proxy");
                //ScensorValueTable.Columns.Add("Rank");
                string[] allLines = File.ReadAllLines(filename);
                foreach (string Line in allLines)
                {
                    if (Line != string.Empty)
                    {
                        string[] value = Line.Split(',');
                        ScensorValueTable.Rows.Add(value[0], value[1]);
                    }
                }
                string SensorValueToCommaSeperated = string.Empty;
                string SensorValueToCommaSeperatedRadial = string.Empty;
                int CountOfSensorValueRadial = 1;

                string NoOfSensorValueToCommaSeperated = string.Empty;
                string NoOfSensorValueToCommaSeperatedRadial = string.Empty;
                string SensorAvgValueToCommaSeperatedRadial = string.Empty;
                string TwelpointRep = string.Empty;
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
                string maxScensorValue, minScensorValue;
                ScensorValueTable = ComputeGraphPlotingValue(ScensorValueTable, out maxScensorValue, out minScensorValue);

                foreach (DataRow ScensorValueTableRow in ScensorValueTable.Rows)
                {
                    if (ScensorValueTableRow[0].ToString().Trim() != string.Empty)
                    {
                        if (ScensorValueTableRow[0].ToString().Trim() == maxScensorValue || ScensorValueTableRow[0].ToString().Trim() == minScensorValue)
                        {
                            SensorValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "value",
                            ":", ScensorValueTableRow[0].ToString(), ",anchorRadius:6}", ",", SensorValueToCommaSeperatedRadial);
                        }
                        else
                        {
                            SensorValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "value",
                            ":", ScensorValueTableRow[0].ToString(), "}", ",", SensorValueToCommaSeperatedRadial);
                        }
                        NoOfSensorValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "label",
                         ":", CountOfSensorValueRadial.ToString(), "}", ",", NoOfSensorValueToCommaSeperatedRadial);

                        SensorAvgValueToCommaSeperatedRadial = string.Format("{0}\"{1}\"{2} \"{3}\"{4}{5}{6}", "{", "value",
                            ":", AvgValueOfSensor.ToString(), "}", ",", SensorAvgValueToCommaSeperatedRadial);
                        CountOfSensorValueRadial = CountOfSensorValueRadial + 1;
                    }
                }
                int NoOfBrac = 1;
                string Brac = string.Empty;
                if (ScensorValueTable.Rows.Count > 0)
                {
                    NoOfBrac = (ScensorValueTable.Rows.Count / 12) - 1;
                }
                for (int i = 0; i < NoOfBrac; i++)
                {
                    Brac = ",{}" + Brac;
                }
                for (int i = 1; i < 13; i++)
                {
                    TwelpointRep = string.Format("{0}\"{1}\"{2} \"{3}\"{4}\"{5}\"{6}\"{7}\"{8}{9}{10}{11}", "{", "value",
                            ":", (Convert.ToDouble(maxScensorValue) + 1).ToString(), ",", "toolText", ":", i, "}", Brac, ",", TwelpointRep);//"}", ",", TwelpointRep);
                }
                NoOfSensorValueToCommaSeperatedRadial = NoOfSensorValueToCommaSeperatedRadial.Remove(NoOfSensorValueToCommaSeperatedRadial.Length - 1);
                SensorValueToCommaSeperatedRadial = SensorValueToCommaSeperatedRadial.Remove(SensorValueToCommaSeperatedRadial.Length - 1);
                SensorAvgValueToCommaSeperatedRadial = SensorAvgValueToCommaSeperatedRadial.Remove(SensorAvgValueToCommaSeperatedRadial.Length - 1);
                DisplayRadialGraphByValue(NoOfSensorValueToCommaSeperatedRadial, SensorValueToCommaSeperatedRadial, SensorAvgValueToCommaSeperatedRadial, TwelpointRep);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable GetGearTeethvalue(DataTable ScensorValueTable)
        {
            try
            {
                DataTable ScensorTeethValueTable = new DataTable();
                ScensorTeethValueTable.Columns.Add("SensorValue");
                ScensorTeethValueTable.Columns.Add("Proxy");
                ScensorTeethValueTable.Columns.Add("Rank");
                List<double> SensorValueArray = new List<double>();
                //SensorValueArray = ScensorValueTable.AsEnumerable().Select(r => r.Field<double>("SensorValue")).ToList();
                foreach (DataRow r in ScensorValueTable.Rows)
                {
                    try
                    {
                        SensorValueArray.Add(Convert.ToDouble(r["SensorValue"]));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                double max = -1;
                //List<double> teeth = new List<double>();
                List<List<double>> teeth_val = new List<List<double>>();

                int previous_max_index = -1;
                int index = -1;
                List<double> temp = new List<double>();
                bool next_teeth = false;
                foreach (double val in SensorValueArray)
                {
                    index = index + 1;

                    if (val >= max)
                    {
                        max = val;

                        if (max != 10.0000)
                        { max = Math.Floor(val); }
                        previous_max_index = index;
                        if (next_teeth)
                        {
                            teeth_val.Add(temp);
                            temp = new List<double>();
                        }
                        next_teeth = false;
                    }
                    if ((index - previous_max_index) > 0)
                    {
                        next_teeth = true;
                        if (next_teeth)
                            temp.Add(val);
                    }
                }

                // List<double> final_teeth = new List<double>();
                // final_teeth = []
                int rank = 1;
                foreach (List<double> teeth in teeth_val)
                {

                    int i = IndexOfMin(teeth);
                    var k = teeth.Select(x => x);//[i - 5:i + 5]
                    for (int j = i - 5; j <= i + 5; j++)
                    {
                        //final_teeth.Add(teeth[j]);
                        ScensorTeethValueTable.Rows.Add(teeth[j], 0, rank);
                        rank++;
                    }
                    //for val in k:
                    //    final_teeth.append(val)
                    // final_teeth
                }
                return ScensorTeethValueTable;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int IndexOfMin(List<double> self)
        {
            try
            {
                double min = self[0];
                int minIndex = 0;

                for (int i = 1; i < self.Count; ++i)
                {
                    if (self[i] < min)
                    {
                        min = self[i];
                        minIndex = i;
                    }
                }

                return minIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void OnlineImportCsvFileAndDisplayAxialGraph(string filename)
        {
            try
            {
                FileInfo file = new FileInfo(filename);
                DataTable ScensorValueTable = new DataTable();
                ScensorValueTable.Columns.Add("SensorValue");
                ScensorValueTable.Columns.Add("Proxy");
                //ScensorValueTable.Columns.Add("Rank");
                string[] allLines = File.ReadAllLines(filename);
                foreach (string Line in allLines)
                {
                    if (Line != string.Empty)
                    {
                        string[] value = Line.Split(',');
                        ScensorValueTable.Rows.Add(value[0], value[1]);
                    }
                }
                string SensorValueToCommaSeperated = string.Empty;
                int CountOfSensorValueAxial = 1;
                string NoOfSensorValueToCommaSeperated = string.Empty;
                double AvgValueOfSensor = 0.0000;
                ScensorValueTable = AxialComputingSensorValues(ScensorValueTable);
                ScensorValueTable = ConvertingToDistanceValue(ScensorValueTable);

                var AvgValueOfSensorFromTable = string.Format("{0}", ScensorValueTable.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Average(a => double.Parse(a[0].ToString())));
                if (!string.IsNullOrEmpty(AvgValueOfSensorFromTable))
                    AvgValueOfSensor = double.Parse(AvgValueOfSensorFromTable);
                string maxScensorValue, minScensorValue;
                ScensorValueTable = ComputeGraphPlotingValue(ScensorValueTable, out maxScensorValue, out minScensorValue);
                foreach (DataRow ScensorValueTableRow in ScensorValueTable.Rows)
                {
                    //,"anchorRadius":6,
                    if (ScensorValueTableRow[0].ToString().Trim() != string.Empty)
                    {
                        if (ScensorValueTableRow[0].ToString() == maxScensorValue || ScensorValueTableRow[0].ToString() == minScensorValue)
                        {
                            SensorValueToCommaSeperated = SensorValueToCommaSeperated + string.Format("{0}\"{1}\"{2} \"{3}\",\"{4}\":\"{5}\"{6}{7}", "{", "label",
                                ":", CountOfSensorValueAxial.ToString(), "value", ScensorValueTableRow[0].ToString(), ",anchorRadius:6}", ",");
                        }
                        else
                        {
                            SensorValueToCommaSeperated = SensorValueToCommaSeperated + string.Format("{0}\"{1}\"{2} \"{3}\",\"{4}\":\"{5}\"{6}{7}", "{", "label",
                              ":", CountOfSensorValueAxial.ToString(), "value", ScensorValueTableRow[0].ToString(), "}", ",");
                        }
                        CountOfSensorValueAxial = CountOfSensorValueAxial + 1;

                    }
                }
                SensorValueToCommaSeperated = SensorValueToCommaSeperated.Remove(SensorValueToCommaSeperated.Length - 1);
                DisplayAxialGraphByValue(NoOfSensorValueToCommaSeperated, SensorValueToCommaSeperated);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void GetNearestByNoOfRercods(int RowCount)
        {
            for (int j = RowCount; j > 0; j--)
            {
                if (j % 12 == 0)
                {
                    GlobalClass.NoValueToPlot = j;
                    return;
                }
            }
            //return 96;
        }
        public DataTable ComputeGraphPlotingValue(DataTable ScensorValueTable, out string maxScensorValue, out string minScensorValue)
        {
            DataTable ComputedValues = new DataTable();
            ComputedValues.Columns.Add("SensorValue");
            ComputedValues.Columns.Add("Proxy");
            ComputedValues.Columns.Add("Rank");
            maxScensorValue = string.Empty;
            minScensorValue = string.Empty;
            try
            {
                if (GlobalClass.NoValueToPlot != 0)
                {
                    int avgValue;
                    int NoOfRows = ScensorValueTable.Rows.Count;
                    if (NoOfRows > 0)
                    {
                        if (NoOfRows > GlobalClass.NoValueToPlot)
                            avgValue = (int)Math.Floor(Convert.ToDecimal(NoOfRows / GlobalClass.NoValueToPlot));
                        else
                            GetNearestByNoOfRercods(NoOfRows);

                        avgValue = (int)Math.Floor(Convert.ToDecimal(NoOfRows / GlobalClass.NoValueToPlot));


                        int i;
                        int valfrom = 1;
                        int valTo = avgValue;
                        var maxScensorV = string.Format("{0}", ScensorValueTable.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                        var minScensorV = string.Format("{0}", ScensorValueTable.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                        maxScensorValue = maxScensorV;
                        minScensorValue = minScensorV;
                        for (i = 0; i < GlobalClass.NoValueToPlot; i++)
                        {
                            //var ScensorValueAvg = ScensorValueTable.AsEnumerable().Where(
                            //    x => Convert.ToInt32( Convert.ToInt32(x[2]) == valTo).Average(
                            //    x => Convert.ToDouble(x.Field<string>("SensorValue")));
                            // Working May be used later                            
                            if (!string.IsNullOrEmpty(maxScensorV) && !string.IsNullOrEmpty(minScensorV))
                            {
                                if (ScensorValueTable.AsEnumerable().Where(x => Convert.ToInt32(x[2]) >= valfrom && Convert.ToInt32(x[2]) <= valTo && Convert.ToDouble(x[0]) == Convert.ToDouble(maxScensorV)).Count() > 0)
                                {
                                    ComputedValues.Rows.Add(maxScensorV, "0", (i + 1).ToString());
                                }
                                else if (ScensorValueTable.AsEnumerable().Where(x => Convert.ToInt32(x[2]) >= valfrom && Convert.ToInt32(x[2]) <= valTo && Convert.ToDouble(x[0]) == Convert.ToDouble(minScensorV)).Count() > 0)
                                {
                                    ComputedValues.Rows.Add(minScensorV, "0", (i + 1).ToString());
                                }
                                else
                                {
                                    ComputedValues.Rows.Add(ScensorValueTable.Rows[valTo][0], "0", (i + 1).ToString());
                                }
                            }
                            else
                            { ComputedValues.Rows.Add(ScensorValueTable.Rows[valTo][0], "0", (i + 1).ToString()); }
                            // Working May be used later
                            //var ScensorValueAvg = ScensorValueTable.AsEnumerable().Where(
                            //    x => Convert.ToInt32(x[2]) >= valfrom && Convert.ToInt32(x[2]) <= valTo).Average(
                            //    x => Convert.ToDouble(x.Field<string>("SensorValue")));
                            //ComputedValues.Rows.Add(ScensorValueTable.Rows[valTo][1], "0", (i + 1).ToString());
                            valfrom = valfrom + avgValue;
                            valTo = valTo + avgValue;
                        }

                    }
                }
                else
                {
                    ComputedValues = ScensorValueTable;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ComputedValues;
        }
        public DataTable RadialComputingSensorValues(DataTable ScensorValueTable)
        {

            DataTable firstItrationValues = new DataTable();
            firstItrationValues.Columns.Add("SensorValue");
            firstItrationValues.Columns.Add("Proxy");
            firstItrationValues.Columns.Add("Rank");
            DataTable secondItrationValues = new DataTable();
            secondItrationValues.Columns.Add("SensorValue");
            secondItrationValues.Columns.Add("Proxy");
            secondItrationValues.Columns.Add("Rank");
            DataTable thirdItrationValues = new DataTable();
            thirdItrationValues.Columns.Add("SensorValue");
            thirdItrationValues.Columns.Add("Proxy");
            thirdItrationValues.Columns.Add("Rank");
            int NoRotation = 0;
            try
            {
                bool rotationStartFlag = false;
                int valuecount = 0;
                int RankOfFirstItration = 0;
                int RankOfSecItration = 0;
                int RankOfThirdItration = 0;
                bool ReadingStarted = false;
                foreach (DataRow ScensorValueRow in ScensorValueTable.Rows)
                {
                    valuecount++;
                    if ((valuecount % 4096) == 0)
                    {
                        ScensorValueRow[0] = "0";
                    }
                    if (ReadingStarted == true)
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
                            {
                                RankOfFirstItration++;
                                firstItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfFirstItration);
                            }
                        }
                        else if (NoRotation == 2)
                        {

                            if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            {
                                RankOfSecItration++;
                                secondItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfSecItration);
                            }
                        }
                        else if (NoRotation == 3)
                        {

                            if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            {
                                RankOfThirdItration++;
                                thirdItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfThirdItration);
                            }
                        }
                    }
                    else
                    {
                        if (ScensorValueRow[1].ToString() == "1")
                        {
                            ReadingStarted = true;
                        }
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
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        firstItrationValues = GetGearTeethvalue(firstItrationValues);
                    }
                    var maxInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxInFirstItrationValue = string.IsNullOrEmpty(maxInFirstItration) ? 0 : double.Parse(maxInFirstItration);
                    var minInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minInFirstItrationValue = string.IsNullOrEmpty(minInFirstItration) ? 0 : double.Parse(minInFirstItration);
                }
                if (secondItrationValues.Rows.Count > 0)
                {
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        secondItrationValues = GetGearTeethvalue(secondItrationValues);
                    }
                    var maxSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxSecondItrationValue = string.IsNullOrEmpty(maxSecondItration) ? 0 : double.Parse(maxSecondItration);
                    var minSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minSecondItrationValue = string.IsNullOrEmpty(minSecondItration) ? 0 : double.Parse(minSecondItration);
                }
                if (thirdItrationValues.Rows.Count > 0)
                {
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        thirdItrationValues = GetGearTeethvalue(thirdItrationValues);
                    }
                    var maxThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxThirdItrationValue = string.IsNullOrEmpty(maxThirdItration) ? 0 : double.Parse(maxThirdItration);
                    var minThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minThirdItrationValue = string.IsNullOrEmpty(minThirdItration) ? 0 : double.Parse(minThirdItration);
                }

                firstItrationRadialRunOutMeasurement = ScensorDistanceCalculation((maxInFirstItrationValue - minInFirstItrationValue) / 2);
                if (secondItrationValues.Rows.Count > 0)
                    secondItrationRadialRunOutMeasurement = ScensorDistanceCalculation((maxSecondItrationValue - minSecondItrationValue) / 2);
                if (thirdItrationValues.Rows.Count > 0)
                    thirdItrationRadialRunOutMeasurement = ScensorDistanceCalculation((maxThirdItrationValue - minThirdItrationValue) / 2);
                double avgItrationRadialRunOutMeasurement = 0;

                if (thirdItrationValues.Rows.Count > 0)
                    avgItrationRadialRunOutMeasurement = (firstItrationRadialRunOutMeasurement + secondItrationRadialRunOutMeasurement + thirdItrationRadialRunOutMeasurement) / 3;
                else if (secondItrationValues.Rows.Count > 0)
                    avgItrationRadialRunOutMeasurement = (firstItrationRadialRunOutMeasurement + secondItrationRadialRunOutMeasurement) / 2;
                else
                    avgItrationRadialRunOutMeasurement = firstItrationRadialRunOutMeasurement;


                //System.IO.File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\Detail.txt",
                //string.Format("firstItrationRadialRunOutMeasurement:{0} \n secondItrationRadialRunOutMeasurement:{1} \n thirdItrationRadialRunOutMeasurement:{2}",
                //firstItrationRadialRunOutMeasurement, secondItrationRadialRunOutMeasurement, thirdItrationRadialRunOutMeasurement));
                if (NoRotation == 1)
                {
                    tboxRPeakValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(maxInFirstItrationValue));
                    tboxRMinValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(minInFirstItrationValue));
                }
                else if (NoRotation > 1)
                {
                    tboxRPeakValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(maxSecondItrationValue));
                    tboxRMinValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(minSecondItrationValue));
                }

                tboxSensorSelected.Text = string.Format("{0}", GlobalClass.SensorSelected);
                tboxChannelSelected.Text = string.Format("{0}", GlobalClass.ChannelSelected);
                tboxRTotalRadialRunOutMeasured.Text = "+/- " + string.Format("{0}", avgItrationRadialRunOutMeasurement);
            }
            catch (Exception)
            {
                throw;
            }
            if (NoRotation == 1)
                return firstItrationValues;
            else
                return secondItrationValues;
        }
        public DataTable AxialComputingSensorValues(DataTable ScensorValueTable)
        {
            DataTable firstItrationValues = new DataTable();
            firstItrationValues.Columns.Add("SensorValue");
            firstItrationValues.Columns.Add("Proxy");
            firstItrationValues.Columns.Add("Rank");
            DataTable secondItrationValues = new DataTable();
            secondItrationValues.Columns.Add("SensorValue");
            secondItrationValues.Columns.Add("Proxy");
            secondItrationValues.Columns.Add("Rank");
            DataTable thirdItrationValues = new DataTable();
            thirdItrationValues.Columns.Add("SensorValue");
            thirdItrationValues.Columns.Add("Proxy");
            thirdItrationValues.Columns.Add("Rank");
            int NoRotation = 0;
            try
            {
                bool rotationStartFlag = false;
                bool startReadValue = false;

                int valuecount = 0;
                int RankOfFirstItration = 0;
                int RankOfSecItration = 0;
                int RankOfThirdItration = 0;
                foreach (DataRow ScensorValueRow in ScensorValueTable.Rows)
                {
                    valuecount++;
                    if ((valuecount % 4096) == 0)
                    {
                        ScensorValueRow[0] = "0";
                    }
                    if (startReadValue == true)
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
                            {
                                RankOfFirstItration++;
                                firstItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfFirstItration);
                            }
                        }
                        if (NoRotation == 2)
                        {
                            if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            {
                                RankOfSecItration++;
                                secondItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfSecItration);
                            }
                        }
                        if (NoRotation == 3)
                        {
                            if (ScensorValueRow[0].ToString() != "10" && ScensorValueRow[0].ToString() != "0")
                            {
                                RankOfThirdItration++;
                                thirdItrationValues.Rows.Add(ScensorValueRow[0].ToString(), ScensorValueRow[1].ToString(), RankOfThirdItration);
                            }
                        }
                    }
                    else
                    {
                        if (ScensorValueRow[1].ToString() == "1")
                        {
                            startReadValue = true;
                        }
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
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        firstItrationValues = GetGearTeethvalue(firstItrationValues);
                    }
                    var maxInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxInFirstItrationValue = string.IsNullOrEmpty(maxInFirstItration) ? 0 : double.Parse(maxInFirstItration);
                    var minInFirstItration = string.Format("{0}", firstItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minInFirstItrationValue = string.IsNullOrEmpty(minInFirstItration) ? 0 : double.Parse(minInFirstItration);
                }
                if (secondItrationValues.Rows.Count > 0)
                {
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        secondItrationValues = GetGearTeethvalue(secondItrationValues);
                    }
                    var maxSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxSecondItrationValue = string.IsNullOrEmpty(maxSecondItration) ? 0 : double.Parse(maxSecondItration);
                    var minSecondItration = string.Format("{0}", secondItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minSecondItrationValue = string.IsNullOrEmpty(minSecondItration) ? 0 : double.Parse(minSecondItration);
                }
                if (thirdItrationValues.Rows.Count > 0)
                {
                    if (GlobalClass.Typeofgear == "GEAR")
                    {
                        thirdItrationValues = GetGearTeethvalue(thirdItrationValues);
                    }
                    var maxThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                    maxThirdItrationValue = string.IsNullOrEmpty(maxThirdItration) ? 0 : double.Parse(maxThirdItration);
                    var minThirdItration = string.Format("{0}", thirdItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                    minThirdItrationValue = string.IsNullOrEmpty(minThirdItration) ? 0 : double.Parse(minThirdItration);
                }
                firstItrationAxialRunOutMeasurement = ScensorDistanceCalculation((maxInFirstItrationValue - minInFirstItrationValue) / 2);
                if (secondItrationValues.Rows.Count > 0)
                    secondItrationAxialRunOutMeasurement = ScensorDistanceCalculation((maxSecondItrationValue - minSecondItrationValue) / 2);
                if (thirdItrationValues.Rows.Count > 0)
                    thirdItrationAxialRunOutMeasurement = ScensorDistanceCalculation((maxThirdItrationValue - minThirdItrationValue) / 2);
                double avgItrationAxialRunOutMeasurement = 0;
                if (thirdItrationValues.Rows.Count > 0)
                    avgItrationAxialRunOutMeasurement = (firstItrationAxialRunOutMeasurement + secondItrationAxialRunOutMeasurement + thirdItrationAxialRunOutMeasurement) / 3;
                else if (secondItrationValues.Rows.Count > 0)
                    avgItrationAxialRunOutMeasurement = (firstItrationAxialRunOutMeasurement + secondItrationAxialRunOutMeasurement) / 2;
                else
                    avgItrationAxialRunOutMeasurement = firstItrationAxialRunOutMeasurement;


                //System.IO.File.WriteAllText(@"D:\FLS\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\FLS Measurement ToolKit\Resource\AxialDetail.txt",
                // string.Format("firstItrationRadialRunOutMeasurement:{0} \n secondItrationRadialRunOutMeasurement:{1} \n thirdItrationRadialRunOutMeasurement:{2}",
                //, secondItrationAxialRunOutMeasurement, thirdItrationAxialRunOutMeasurement));
                if (NoRotation == 1)
                {
                    tboxAPeakValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(maxInFirstItrationValue));
                    tboxAMinValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(minInFirstItrationValue));
                }
                else
                {
                    tboxAPeakValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(maxSecondItrationValue));
                    tboxAMinValMeasured.Text = string.Format("{0}", ScensorDistanceCalculation(minSecondItrationValue));
                }
                tboxASensorSelected.Text = string.Format("{0}", GlobalClass.SensorSelected);
                tboxAChannelSelected.Text = string.Format("{0}", GlobalClass.ChannelSelected);
                tboxATotalRadialRunOutMeasured.Text = "+/- " + string.Format("{0}", avgItrationAxialRunOutMeasurement);
            }
            catch (Exception)
            {
                throw;
            }
            if (NoRotation == 1)
                return firstItrationValues;
            else
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
                throw;
            }
            return ScensorCalculatedValueTable;
        }
        public void CalculateMaxMINAxialRunOut(DataTable ItrationAxialRunOutMeasurement, out double maxInItrationValue, out double minInItrationValue)
        {
            try
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
                    finalItrationValues.Rows.Add(string.Format("{0}", double.Parse(ItrationValues2.Rows[i][0].ToString()) - double.Parse(ItrationValues1.Rows[i][0].ToString())));
                }
                var maxInFirstItration = string.Format("{0}", finalItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Max(a => a[0]));
                maxInItrationValue = string.IsNullOrEmpty(maxInFirstItration) ? 0 : double.Parse(maxInFirstItration);
                var minInFirstItration = string.Format("{0}", finalItrationValues.AsEnumerable().Where(a => a[0].ToString() != string.Empty && a[0].ToString().Trim() != "0" && a[0].ToString().Trim() != "10").Min(a => a[0]));
                minInItrationValue = string.IsNullOrEmpty(minInFirstItration) ? 0 : double.Parse(minInFirstItration);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
