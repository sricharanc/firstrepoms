   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   R NFLS Measurement ToolKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FLS_Measurement_ToolKitFLS_Measurement_ToolKit 5   	   1   +FLS_Measurement_ToolKit.ReadWriteSerialPort   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:FLS_Measurement_ToolKit     5   	     � Title$  ReadWriteSerialPort��5	   	   $	��300��6%   $	��300��62    � WindowStartupLocation$ CenterScreen=�6>   .��5
      � .+�5   
   � -   5         �Name$ ReadWriteGrid��5      .+�5      -   'MahApps.Metro.Controls.MetroProgressBar  -   5          Name$ OnProgressBar��5   (   {�. 6?   �� 5      -   5         ��Name$ readingAcquirel��5      $5��/Click on START to acquire readings from sensor.��6-   $
��Left=�6g   $	��Top=�6�   $��	19,29,0,0q�6�   �� 5      -   5        $ NoItrationRequired��5      $ ��No. of iteration Required:��60   $
��Left=�6U   $	��Top=�6p   $��	31,80,0,0q�6�    J� RenderTransformOrigin$ 	2.2,2.192&�6�   $	��160��6�   $��25��6�   �� 5      -   5         ��Name$ btnStart��5      $��Start��6'   $
��Left=�67   $��
42,137,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $ btnEnd��5      $	��End��5      $
��Left=�6   $��159,137,0,0q�6+   $	��Top=�6@   $��75��6X   6c   5      � 5   
   -   5        $
 Ring��5      .+�5      )   #MahApps.Metro.Controls.ProgressRing  -   5          Name$ OnProgressRing��5   $      IsActive .  6<   �� 5      -	   5        	 ��Name$	 noItrRequirdTxtBox��5      $
��Left=�62   $��1��6M   $��
191,80,0,0q�6X   
 �� TextWrapping$

 Wrap=�6l   $	��Top=�6�   $��62��6�   5      5      5      