   M S B A M L   `   `   `  ����E  AStar Gazer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Star_Gazer
Star_Gazer  5   	       Star_Gazer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Star_Gazer     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	   -   5          �Name$  sGazer��5   5    � Title$ 
Star Gazer��5	   	   $	��450��6   $	��800��6)    � WindowState$ 	Maximized=�65    � 
ResizeMode$ NoResize=�6M    � Topmost .  � WindowStyle$
 None=�6r   ���	#00000000 � AllowsTransparency .  � Icon$# source_code_96px_UHU_icon.ico��6�    � ShowInTaskbar .  	 � 	Resources	 5
      
 �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  '��       �� 5   
   "
 ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5       5      P� 5       � {� .  . �5   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6@    � �� �	#FF8989896T   5      P� 5       �@J�	IsFocused . . �5   "   �� $ border��6@    � �� �	#FF5B5B5B6T   5      5      5      5       5!      .��5"      � -   5         �Name$ grid1��5"      ���	#7F747474.+�5#   
   �� -   5         ��Name$ textBox��5#      $��10,125,10,265q�6#    �� SelectionOpacity$	 0.5Q�6:   $��2q�6Q   
����������	#E5282828 �� SelectionBrush �	#FF686868���	#E51D1D1D �� TextAlignment$ Center=�6�   $
��Thin"�6�   $��SemiCondensed&�6�   &   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6  $��25(�6.  $��Center=�6<  $��Center=�6^  $��Center=�6�  $	��780��6�  $��Center=�6�  $��60��6�  .��6,   J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         ShadowDepth$ 5Q�6#      
BlurRadius$ 10Q�63      Opacity$
 0.60Q�6C      	Direction$	 270Q�6R       Color$  	#FF1F1F1F��6b   .��5&      5(      �� 5)   
   -   5        ! ��Name$! label��5)      $��Search��6   $��Center=�60   $��10,125,10,265q�6M   $��Center=�6d   $	��780��6   $��60��6�   ���	#00000000���	#E5727272$��28(�6�   $��Center=�6�   $��Center=�6�   6  �� 5*   
   -   5        " ��Name$" listBox��5*      $	��246��6#   $��10,193,10,11q�60   $	��780��6F   ���	#E5282828
����������	#FF2B2B2B$y�	Collapsed=�6�   $��Center=�6�   $	��Top=�6�    5+        5,      $ 5Q�6#   $ 10Q�63   $
 0.60Q�6C   $	 270Q�6R   $  	#FF1F1F1F��6b   5.      3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  50   
   -   5        #  Name$# tIcon��50      $
��Left=�6(   $��0��6C   $	��Top=�6N   $��0��6f   $   ToolTipText$$ 
Star Gazer��6p   %   TrayToolTip% 51      �� 52      
���iii�
�������$��1q�55      & �� CornerRadius$& 2��56      ' J� Opacity$' 1Q�57      $	��100��58      $��25��59      ._�5:      �� $��
Star Gazer��5;      $��Center=�5<      $��Center=�5=      
�������5>      5@      ( � ContextMenu( 5B      �� 5C      ���	#E5282828
�������.@�5E      m� -   5        $	��mn1��5E      $��Show Star Gazer��6*   ) m� Icon$)  ��6C   6K   m� 5F      -   5        $	��mn3��5F      $��Reload��6*   6:   m� 5G      -	   5        $	��mn2��5G      $
��Exit��6*   $)  ��68   6@   5H      5J      5L      5M      