   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   R NFLS Measurement ToolKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FLS_Measurement_ToolKitFLS_Measurement_ToolKit 5   	   +   %FLS_Measurement_ToolKit.AddInfoWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:FLS_Measurement_ToolKit     5   	     � Title$  Add Customer Information��5	   	   $��421.975��5
   	   $��700.991��5   	   $��0q�5   	   (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5      �� -   5         ��Name$ lblCustomerName��5      $��Customer Name *��61   $
��Left=�6K   $��	60,40,0,0q�6f   $	��Top=�6y   �� 5      -   5        $��tboxCustomerName��5      $��23��62    �� TextWrapping$
 Wrap=�6>   $��Right=�6R   $��	0,40,75,0q�6n   $	��Top=�6�   $	��262��6�   �� 5      -   5        $ lblOEM��5      $��OEM *��6(   $
��Left=�68   $��	60,80,0,0q�6S   $	��Top=�6f   �� 5      -   5        $��tboxOEM��5      $��23��6)   $
 Wrap=�65   $��Right=�6I   $��	0,80,75,0q�6e   $	��Top=�6x   $	��262��6�   �� 5      -   5        $ lblLocation��5      $��Location��6-   $
��Left=�6@   $��
60,120,0,0q�6[   $	��Top=�6o   �� 5      -   5        $��tboxLocation��5      $��23��6.   $
 Wrap=�6:   $��Right=�6N   $��
0,120,75,0q�6j   $	��Top=�6~   $	��262��6�   �� 5      -   5        $ lblEquipment��5      $��Equipment tag no��6.   $
��Left=�6I   $��
60,160,0,0q�6d   $	��Top=�6x   �� 5      -   5        $��tboxEquipment��5      $��23��6/   $
 Wrap=�6;   $��Right=�6O   $��
0,160,75,0q�6k   $	��Top=�6   $	��262��6�   �� 5      -	   5        $ lblKilnSize��5      $��	Kiln Size��6-   $
��Left=�6A   $��
60,200,0,0q�6\   $	��Top=�6p   �� 5      -
   5        $��tboxKlin��5      $��23��6*   $
 Wrap=�66   $��Right=�6J   $��
0,200,75,0q�6f   $	��Top=�6z   $	��262��6�   �� 5      -   5        $ 
lblNobases��5      $��No bases��6,   $
��Left=�6?   $��
60,240,0,0q�6Z   $	��Top=�6n   �� 5      -   5        $��tboxNoBases��5      $��23��6-   $
 Wrap=�69   $��Right=�6M   $��
0,240,75,0q�6i   $	��Top=�6}   $	��262��6�   �� 5       -   5        $ 
lblProject��5       $��Project/ Contract No *��6,   $
��Left=�6M   $��
60,280,0,0q�6h   $	��Top=�6|   �� 5!      -   5        $��tboxProject��5!      $��23��6-   $
 Wrap=�69   $��Right=�6M   $��
0,280,75,0q�6i   $	��Top=�6}   $	��262��6�   �� 5"      -   5        $��buttonOk��5"      $��30��6)   $��Right=�65   $��
0,320,75,0q�6Q   $	��Top=�6e   $��OK��6}   $��70��6�   6�   �� 5#   
   -   5         ��Name$ 	btnCancel��5#      $��Cancel��6$   $
��Left=�65   $��440,322,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5$      5%      