   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  R NFLS Measurement ToolKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FLS_Measurement_ToolKitFLS_Measurement_ToolKit (   "FLS_Measurement_ToolKit.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:FLS_Measurement_ToolKit     -   (   "MahApps.Metro.Controls.MetroWindow   Name$
  Main�� � Title$ FLS Measurements��$��606.95��$��998.991�� � WindowStartupLocation$ CenterScreen=�.��� .+�� .+�o� $
��Left=�$	��Top=�$	��517��.@�m� $
��File��.@�m� -   $	��New��$
��Left=�$	��140��m� -   $
��Open��$
��Left=�$	��140���� $
��Left=�$	��140��m� -   $��Save Config��$
��Left=�$	��140��m� -   $��Load Config��$
��Left=�$	��140��m� $
��Exit��$
��Left=�$	��140��m� $
��Tool��m� $��About��� .+��� $
��Left=�$	��484��$��	10,35,0,0q�$	��Top=�$	��917��.@��� -    ��Name$ 	TabRadial��$��RADIAL��.��� ���	#FFE5E5E5$��0,0,-62,-56q� � ColumnDefinitions �� $
��128* ��� $	��20* ��� $
��827* �.+��� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$	��Top=�$	��471��$��3��(  "System.Windows.Controls.WebBrowser  -     Name$ webBrowserRadial��$
��Left=�$	��473��$��	10,10,0,0q�$	��Top=�$	��578��$��3��� $��456,10,10,10q�$��2��.+��� -    ��Name$ 
lblPeakVal��$��	PeakValue��$
��Left=�$��	40,60,0,0q�$	��Top=��� -	    ��Name$ tboxRPeakValMeasured�� �� 
IsReadOnly . $��Right=�$��	0,60,37,0q�$	��Top=�$��95���� -
   $ 	lblMinVal��$��MinValue��$
��Left=�$��
40,100,0,0q�$	��Top=��� -   $ tboxRMinValMeasured�� . $��Right=�$��
0,100,37,0q�$	��Top=�$��95���� -   $ lblPeakValAt��$��PeakValueAt��$
��Left=�$��
40,140,0,0q�$	��Top=�$y�Hidden=��� -   $ tboxRPeakValAtMeasured�� . $��Right=�$��
0,140,70,0q�$	��Top=�$��62��$y�Hidden=��� -   $ lblMinValAt��$��
MinValueAt��$
��Left=�$��
40,180,0,0q�$	��Top=�$y�Hidden=��� -   $ tboxRMinValAtMeasured�� . $��Right=�$��
0,181,70,0q�$	��Top=�$��62��$y�Hidden=��� -   $ lblTotalRadialRunOut��$��Total Radial Run Out��$
��Left=�$��
40,220,0,0q�$	��Top=��� -   $$ tboxRTotalRadialRunOutMeasured�� . $��Right=�$��
0,220,37,0q�$	��Top=�$��95���� -   $ lblRadialThreshold��$%��Radial Run Out Within Threshold��$
��Left=�$��
40,260,0,0q�$	��Top=��� -   $ tboxRadialThresholdVal�� . $��Right=�$��
0,260,37,0q�$	��Top=�$��95���� -   $ 	lblSensor��$��Sensor��$
��Left=�$��
40,300,0,0q�$	��Top=��� -   $ tboxSensorSelected�� . $��Right=�$��
0,300,37,0q�$	��Top=�$��95���� -   $ 
lblChannel��$��Channel��$
��Left=�$��
40,340,0,0q�$	��Top=��� -   $ tboxChannelSelected�� . $��Right=�$��
0,340,37,0q�$	��Top=�$��95���� -   $ lblMeasurement��$��Measurement Value��$
��Left=�$��
40,380,0,0q�$	��Top=��� -   $ tboxMeasurementValue�� . $��Right=�$��
0,380,37,0q�$	��Top=�$��95���� -   	 ��Name$	 ExportRadialGraphToPDF��$��
EXPORT PDF��$��2��$
��Left=�$��470,445,0,0q�$	��Top=�$��85���� -   $	 ExportRadialGraphToExcel��$��EXPORT EXCEL��$��2��$
��Left=�$��575,445,0,0q�$	��Top=�$��85���� -   $ TabAxial��$��AXIAL��.��� ���	#FFE5E5E5$��0,0,-62,-56q�.+��� $
��Left=�$��10q�$
��Wrap=�$	��Top=�$	��471��  -   $ webBrowserAxial��$
��Left=�$	��473��$��	10,10,0,0q�$	��Top=�$	��578��$��2��� $��593,20,10,10q�.+��� -   $ lblaPeakVal��$��	PeakValue��$
��Left=�$��	40,60,0,0q�$	��Top=��� -   $ tboxAPeakValMeasured�� . $��Right=�$��	0,60,37,0q�$	��Top=�$��95���� -    $ 
lblaMinVal��$��MinValue��$
��Left=�$��
40,100,0,0q�$	��Top=��� -!   $ tboxAMinValMeasured�� . $��Right=�$��
0,100,37,0q�$	��Top=�$��95���� -"   $ lblaPeakValAt��$��PeakValueAt��$
��Left=�$��
40,140,0,0q�$	��Top=�$y�Hidden=��� -#   $ tboxAPeakValAtMeasured�� . $��Right=�$��
0,140,70,0q�$	��Top=�$��62��$y�Hidden=��� -$   $ lblaMinValAt��$��
MinValueAt��$
��Left=�$��
40,180,0,0q�$	��Top=�$y�Hidden=��� -%   $ tboxAMinValAtMeasured�� . $��Right=�$��
0,180,70,0q�$	��Top=�$��62��$y�Hidden=��� -&   $ lblaTotalRadialRunOut��$��Total Axial Run Out��$
��Left=�$��
40,220,0,0q�$	��Top=��� -'   $$ tboxATotalRadialRunOutMeasured�� . $��Right=�$��
0,220,37,0q�$	��Top=�$��95���� -(   $ lblaRadialThreshold��$��Run Out Within Threshold��$
��Left=�$��
40,260,0,0q�$	��Top=��� -)   $ tboxAxialThresholdVal�� . $��Right=�$��
0,260,37,0q�$	��Top=�$��95���� -*   $ 
lblASensor��$��Sensor��$
��Left=�$��
40,300,0,0q�$	��Top=��� -+   $ tboxASensorSelected�� . $��Right=�$��
0,300,37,0q�$	��Top=�$��95���� -,   $ lblAChannel��$��Channel��$
��Left=�$��
40,340,0,0q�$	��Top=��� --   $ tboxAChannelSelected�� . $��Right=�$��
0,340,37,0q�$	��Top=�$��95���� -.   $ lblAMeasurement��$��Measurement Value��$
��Left=�$��
40,380,0,0q�$	��Top=��� -/   $ tboxAMeasurementValue�� . $��Right=�$��
0,380,37,0q�$	��Top=�$��95���� -0   $	 ExportAxialGraphToPDF��$��
EXPORT PDF��$
��Left=�$��618,445,0,0q�$	��Top=�$��85���� -1   $	 ExportAxialGraphToExcel��$��EXPORT EXCEL��$
��Left=�$��723,445,0,0q�$	��Top=�$��85��