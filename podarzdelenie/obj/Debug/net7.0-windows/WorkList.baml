   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.WorkList   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  WorkList��5   	   $	��450��6   $	��800��6'    � 	Resources 5	      (  "System.Windows.Controls.DatePicker �� 
TargetType �� Property �� Value-   'WpfApp1.ByteArrayToBitmapImageConverter   byteToImageConverter��%�   '        &	  y     �� 5
   
   "  6   .�5      ��  � ��$	 120��6&   64   �� 5       � ��$
 10,0q�6'   66   5        5   
   6I   5      .��5      � .+�5   
   �� .+�5      �� -   5         ��Name$ mainText��5   I   $��20(�6   ���	#FFFFB107$��36��6=    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFD6850F��6'   1/Хранитель ПРО Общий отдел5   ?   �� 5   
   .+�5      �� $��17(�6   	Дата:61   �� 5      $��10q�6    �� Orientation$ 
Horizontal=�6&   .+�5      �� С:6$     5      -   5        	  Name$	 Date1��5   !   62   �� 5      По:6%     5      -   5        $	 Date2��5      6.   �� 5      -   5        .��5   ,   
Найти63   �� 5      -   5        
 ��Name$
 Clear��5   '   $
��10,0q�6   .��6J   Сбросить6T   5      �� 5    
   -   5         ��Name$
 suka��5       ���	#FFFF9325$
��True��6b    �� View 5!      �� 5"      .P�5#      �� $��Id��6%    �� DisplayMemberBinding 61   �� *Id+6W   �� 5$      $��Дата��6%    63   �� *Date+6[   �� 5%      $��Тип��6)    66   �� *Type+6^   �� 5&      $ ��Подразделение��6)    6@   �� *Where+6i   �� 5'      $��Статус��6)    69   �� *Status+6c   �� 5(      $��Фото��6-    �� CellTemplate 5)   "   �� 5*   &   .R�5+   *   �� ��60   �� *Photo+ �� 	Converter# [  6}   5,   '   5.      5/      51      �� 52      -   5        $
 Show_all��52      ${�False��6'   .��6P   Подробнее6[   53      54      55      56      