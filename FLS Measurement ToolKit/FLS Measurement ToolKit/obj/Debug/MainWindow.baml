   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   R NFLS Measurement ToolKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FLS_Measurement_ToolKitFLS_Measurement_ToolKit 5   	   (   "FLS_Measurement_ToolKit.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:FLS_Measurement_ToolKit     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow   Name$
  Main��5       � Title$ FLS Measurements��5	   	   $��606.95��6"   $��998.991��62    � WindowStartupLocation$ CenterScreen=�6^   .��5
      � .+�5   
   � .+�5      o� $
��Left=�6   $	��Top=�6.   $	��517��6F   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      $
��Left=�6,   $	��140��6G   6S   m� 5      -   5        $
��Open��5      $
��Left=�6-   $	��140��6H   6T   �� 5      $
��Left=�6    $	��140��6;   m� 5      -   5        $��Save Config��5      $
��Left=�64   $	��140��6O   6[   m� 5      -   5        $��Load Config��5      $
��Left=�64   $	��140��6O   6[   m� 5      $
��Exit��6   $
��Left=�6-   $	��140��6H   5      m� 5      $
��Tool��6   5      m� 5      $��About��6   5      5      )   #MahApps.Metro.Controls.ProgressRing  5      -   5          Name$ OnProgressRing��5   $      IsActive .  6<   5      � 5   
   .+�5      �� $
��Left=�6   $	��484��5      $��	10,35,0,0q�5      $	��Top=�5       $	��917��5!      .@�5"      �� -   5         ��Name$ 	TabRadial��5"      $��RADIAL��6-   .��5#      � ���	#FFE5E5E5$��0,0,-62,-56q�62    � ColumnDefinitions 5$      �� 5%      $
��128* �6/   �� 5&      $	��20* �6/   �� 5'      $
��827* �6/   .+�5)      �� $
��Left=�6$   $��	10,10,0,0q�5*      $
��Wrap=�5+      $	��Top=�5,      $	��471��5-      $��3��6   (  "System.Windows.Controls.WebBrowser  5.      -   5          Name$ webBrowserRadial��5.   %   $
��Left=�6?   $	��473��6Z   $��	10,10,0,0q�6g   $	��Top=�6z   $	��578��6�   $��3��6�   � 5/      $��456,10,10,10q�6   $��2��65   .+�50      �� -	   5         ��Name$ 
lblPeakVal��50   $   $��	PeakValue��68   $
��Left=�6L   $��	40,60,0,0q�6g   $	��Top=�6z   �� 51      -
   5        	 ��Name$	 tboxRPeakValMeasured��51   &   
 �� 
IsReadOnly
 . $��Right=�6W   $��	0,60,37,0q�6s   $	��Top=�6�   $��95��6�   �� 52      -   5        $ 	lblMinVal��52   $   $��MinValue��67   $
��Left=�6J   $��
40,100,0,0q�6e   $	��Top=�6y   �� 53      -   5        $	 tboxRMinValMeasured��53   &   
 . $��Right=�6V   $��
0,100,37,0q�6r   $	��Top=�6�   $��95��6�   �� 54      -   5        $ lblPeakValAt��54   $   $��PeakValueAt��6:   $
��Left=�6P   $��
40,140,0,0q�6k   $	��Top=�6   $y�Hidden=�6�   �� 55      -   5        $	 tboxRPeakValAtMeasured��55   &   
 . $��Right=�6X   $��
0,140,70,0q�6t   $	��Top=�6�   $��62��6�   $y�Hidden=�6�   �� 56      -   5        $ lblMinValAt��56   $   $��
MinValueAt��69   $
��Left=�6N   $��
40,180,0,0q�6i   $	��Top=�6}   $y�Hidden=�6�   �� 57      -   5        $	 tboxRMinValAtMeasured��57   &   
 . $��Right=�6W   $��
0,181,70,0q�6s   $	��Top=�6�   $��62��6�   $y�Hidden=�6�   �� 58      -   5        $ lblTotalRadialRunOut��58   $   $��Total Radial Run Out��6B   $
��Left=�6a   $��
40,220,0,0q�6|   $	��Top=�6�   �� 59      -   5        $$	 tboxRTotalRadialRunOutMeasured��59   &   
 . $��Right=�6`   $��
0,220,37,0q�6|   $	��Top=�6�   $��95��6�   �� 5:      -   5        $ lblRadialThreshold��5:   $   $%��Radial Run Out Within Threshold��6@   $
��Left=�6j   $��
40,260,0,0q�6�   $	��Top=�6�   �� 5;      -   5        $	 tboxRadialThresholdVal��5;   &   
 . $��Right=�6Y   $��
0,260,37,0q�6u   $	��Top=�6�   $��95��6�   �� 5<      -   5        $ 	lblSensor��5<   $   $��Sensor��67   $
��Left=�6H   $��
40,300,0,0q�6c   $	��Top=�6w   �� 5=      -   5        $	 tboxSensorSelected��5=   &   
 . $��Right=�6T   $��
0,300,37,0q�6p   $	��Top=�6�   $��95��6�   �� 5>      -   5        $ 
lblChannel��5>   $   $��Channel��68   $
��Left=�6J   $��
40,340,0,0q�6e   $	��Top=�6y   �� 5?      -   5        $	 tboxChannelSelected��5?   &   
 . $��Right=�6U   $��
0,340,37,0q�6q   $	��Top=�6�   $��95��6�   �� 5@      -   5        $ lblMeasurement��5@   $   $��Measurement Value��6<   $
��Left=�6X   $��
40,380,0,0q�6s   $	��Top=�6�   �� 5A      -   5        $	 tboxMeasurementValue��5A   &   
 . $��Right=�6V   $��
0,380,37,0q�6r   $	��Top=�6�   $��95��6�   5C      �� 5D      -   5         ��Name$ ExportRadialGraphToPDF��5D   !   $��
EXPORT PDF��6A   $��2��6V   $
��Left=�6f   $��470,445,0,0q�6�   $	��Top=�6�   $��85��6�   6�   �� 5E      -   5        $ ExportRadialGraphToExcel��5E   !   $��EXPORT EXCEL��6C   $��2��6Z   $
��Left=�6j   $��575,445,0,0q�6�   $	��Top=�6�   $��85��6�   6�   5F      5G      �� 5H      -   5        $ TabAxial��5H      $��AXIAL��6,   .��5I      � ���	#FFE5E5E5$��0,0,-62,-56q�62   .+�5J      �� $
��Left=�6$   $��10q�5K      $
��Wrap=�5L      $	��Top=�5M      $	��471��5N        5O      -   5        $ webBrowserAxial��5O   %   $
��Left=�6>   $	��473��6Y   $��	10,10,0,0q�6f   $	��Top=�6y   $	��578��6�   $��2��6�   � 5P      $��593,20,10,10q�6   .+�5Q      �� -   5        $ lblaPeakVal��5Q   $   $��	PeakValue��69   $
��Left=�6M   $��	40,60,0,0q�6h   $	��Top=�6{   �� 5R      -    5        $	 tboxAPeakValMeasured��5R   &   
 . $��Right=�6V   $��	0,60,37,0q�6r   $	��Top=�6�   $��95��6�   �� 5S      -!   5        $ 
lblaMinVal��5S   $   $��MinValue��68   $
��Left=�6K   $��
40,100,0,0q�6f   $	��Top=�6z   �� 5T      -"   5        $	 tboxAMinValMeasured��5T   &   
 . $��Right=�6V   $��
0,100,37,0q�6r   $	��Top=�6�   $��95��6�   �� 5U      -#   5        $ lblaPeakValAt��5U   $   $��PeakValueAt��6;   $
��Left=�6Q   $��
40,140,0,0q�6l   $	��Top=�6�   $y�Hidden=�6�   �� 5V      -$   5        $	 tboxAPeakValAtMeasured��5V   &   
 . $��Right=�6Y   $��
0,140,70,0q�6u   $	��Top=�6�   $��62��6�   $y�Hidden=�6�   �� 5W      -%   5        $ lblaMinValAt��5W   $   $��
MinValueAt��6:   $
��Left=�6O   $��
40,180,0,0q�6j   $	��Top=�6~   $y�Hidden=�6�   �� 5X      -&   5        $	 tboxAMinValAtMeasured��5X   &   
 . $��Right=�6X   $��
0,180,70,0q�6t   $	��Top=�6�   $��62��6�   $y�Hidden=�6�   �� 5Y      -'   5        $ lblaTotalRadialRunOut��5Y   $   $��Total Axial Run Out��6C   $
��Left=�6a   $��
40,220,0,0q�6|   $	��Top=�6�   �� 5Z      -(   5        $$	 tboxATotalRadialRunOutMeasured��5Z   &   
 . $��Right=�6a   $��
0,220,37,0q�6}   $	��Top=�6�   $��95��6�   �� 5[      -)   5        $ lblaRadialThreshold��5[   $   $��Run Out Within Threshold��6A   $
��Left=�6d   $��
40,260,0,0q�6   $	��Top=�6�   �� 5\      -*   5        $	 tboxAxialThresholdVal��5\   &   
 . $��Right=�6X   $��
0,260,37,0q�6t   $	��Top=�6�   $��95��6�   �� 5]      -+   5        $ 
lblASensor��5]   $   $��Sensor��68   $
��Left=�6I   $��
40,300,0,0q�6d   $	��Top=�6x   �� 5^      -,   5        $	 tboxASensorSelected��5^   &   
 . $��Right=�6V   $��
0,300,37,0q�6r   $	��Top=�6�   $��95��6�   �� 5_      --   5        $ lblAChannel��5_   $   $��Channel��69   $
��Left=�6K   $��
40,340,0,0q�6f   $	��Top=�6z   �� 5`      -.   5        $	 tboxAChannelSelected��5`   &   
 . $��Right=�6W   $��
0,340,37,0q�6s   $	��Top=�6�   $��95��6�   �� 5a      -/   5        $ lblAMeasurement��5a   $   $��Measurement Value��6=   $
��Left=�6Y   $��
40,380,0,0q�6t   $	��Top=�6�   �� 5b      -0   5        $	 tboxAMeasurementValue��5b   &   
 . $��Right=�6X   $��
0,380,37,0q�6t   $	��Top=�6�   $��95��6�   5d      �� 5e      -1   5        $ ExportAxialGraphToPDF��5e   !   $��
EXPORT PDF��6@   $
��Left=�6U   $��618,445,0,0q�6p   $	��Top=�6�   $��85��6�   6�   �� 5f      -2   5        $ ExportAxialGraphToExcel��5f   !   $��EXPORT EXCEL��6B   $
��Left=�6Y   $��723,445,0,0q�6t   $	��Top=�6�   $��85��6�   6�   5h      5i      5j      5k      5l      5m      