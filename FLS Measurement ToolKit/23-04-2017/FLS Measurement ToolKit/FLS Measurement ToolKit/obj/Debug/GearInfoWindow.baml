   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   R NFLS Measurement ToolKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FLS_Measurement_ToolKitFLS_Measurement_ToolKit 5   	   ,   &FLS_Measurement_ToolKit.GearInfoWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:FLS_Measurement_ToolKit     5   	     � Title$  Add Gear Information��5	   	   $	��557��5
   	   $	��734��5   	   $��0q�5   	   (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   � -   5        $��0,-1,0,1q�5      .+�5      �� -   5         ��Name$ lblType��5      $��Type *��6%   $
��Left=�66   $��	60,40,0,0q�6Q   $	��Top=�6d   �� 5      -   5        $��cmbTypeOfGear��5      $��23��6,   $��Right=�68   $��	0,40,75,0q�6T   $	��Top=�6g   $	��262��6   �� 5      -   5        $ lblGearOuterDiameter��5      $��Gear Outer Diameter��62   $
��Left=�6P   $��	60,80,0,0q�6k   $	��Top=�6~   �� 5      -   5        $��tboxGearOuterDiameter��5      $��23��63    �� TextWrapping$
 Wrap=�6?   $��Right=�6S   $��	0,80,75,0q�6o   $	��Top=�6�   $	��262��6�   �� 5      -   5        $ lblNoOfTeeth��5      $��No Of Teeth��6*   $
��Left=�6@   $��
60,120,0,0q�6[   $	��Top=�6o   �� 5      -   5        $��tboxNoOfTeeth��5      $��23��6+   $
 Wrap=�67   $��Right=�6K   $��
0,120,75,0q�6g   $	��Top=�6{   $	��262��6�   �� 5      -   5        $ lblGearFaceWidth��5      $��Gear Face Width (mm)��6.   $
��Left=�6M   $��
60,160,0,0q�6h   $	��Top=�6|   �� 5      -	   5        $��tboxGearFaceWidth��5      $��23��6/   $
 Wrap=�6;   $��Right=�6O   $��
0,160,75,0q�6k   $	��Top=�6   $	��262��6�   �� 5      -
   5        $ lblHelixAngleInDegree��5      $��Helix Angle (In Degree)��63   $
��Left=�6U   $��
60,200,0,0q�6p   $	��Top=�6�   �� 5      -   5        $��tboxHelixAngleInDegree��5      $��23��64   $
 Wrap=�6@   $��Right=�6T   $��
0,200,75,0q�6p   $	��Top=�6�   $	��262��6�   �� 5      -   5        $ lblDirectionOfRotation��5      $��Direction Of Rotation *��64   $
��Left=�6V   $��
60,240,0,0q�6q   $	��Top=�6�   �� 5       -   5        $��tboxDirectionOfRotation��5       $��23��65   $
 Wrap=�6A   $��Right=�6U   $��
0,240,75,0q�6q   $	��Top=�6�   $	��262��6�   �� 5!      -   5        $ lblNoOfDrive��5!      $��No Of Drive��6*   $
��Left=�6@   $��
60,281,0,0q�6[   $	��Top=�6o   �� 5"      -   5         ��Name$ tboxNoOfDrive��5"      $��23��6-   $
 Wrap=�69   $��Right=�6M   $��
0,280,75,0q�6i   $	��Top=�6}   $	��262��6�   �� 5#      -   5        $ lblTypeOfSpringPlate��5#      $��Type Of Spring Plate��62   $
��Left=�6Q   $��
60,320,0,0q�6l   $	��Top=�6�   �� 5$      -   5        $ tboxTypeOfSpringPlate��5$      $��23��65   $
 Wrap=�6A   $��Right=�6U   $��
0,320,75,0q�6q   $	��Top=�6�   $	��262��6�   �� 5%      -   5        $$ lblKlinShellThicknessUnderGear��5%      $*��$Klin Shell Thickness Under Gear (mm)��6<   $
��Left=�6k   $��
60,360,0,0q�6�   $	��Top=�6�   �� 5&      -   5        $% tboxKlinShellThicknessUnderGear��5&      $��23��6?   $
 Wrap=�6K   $��Right=�6_   $��
0,360,75,0q�6{   $	��Top=�6�   $	��262��6�   �� 5'      -   5        $��buttonOk��5'      $��30��6%   $��Right=�61   $��
0,476,70,0q�6M   $	��Top=�6a   $��OK��6y   $��70��6�   6�   �� 5(      -   5        $ lblRotation��5(      $��	Rotaion *��6)   $
��Left=�6=   $��
60,398,0,0q�6X   $	��Top=�6l   $	��207��6�   �� 5)      -   5         ��Name$ 
cmbRotaion��5)      $
��Left=�6+   $��389,395,0,0q�6F   $	��Top=�6[   $	��262��6s   �� 5*      -   5        	 ��Name$	 	btnCancel��5*      $��Cancel��6(   $
��Left=�69   $��480,478,0,0q�6T   $	��Top=�6i   $��75��6�   6�   5+      5,      5-      