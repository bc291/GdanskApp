   M S B A M L   `   `   `  ����I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  5          tristarweather.Page3   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:tristarweather     5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N� Title$  Page3��5
       � 	Resources 5         myHeaderTemplate  ShowMenu �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  HideMenu g� AccelerationRatio��%�  &	        &	 i     &	 �     �� 5   
   .R�5      ]� .+�5      �� $��16(�6   
����  ���6@   �� 5      5      �� 5   
   .��5      t� $ Margin�6!   $ 111,0,133,-101X�6D   $ 111,0,133,-30X�6Z   $	 0.9Q�6m   $ 0:0:1D�6�   5      �� 5   
   .��5      t� $ Margin�6!   $ 111,0,133,-30X�6D   $ 111,0,133,-101X�6Y   $	 0.9Q�6m   $ 0:0:1D�6�   5      5      .��5   
   � -   5         �Name$ MainGrid��5   V     pageBackground#���  6   $	��426��6=   $	��644��6J   	 � RowDefinitions	 5       �� 5!      $	��11* �6    �� 5"      $	��30* �6    �� 5#      $��1* �6    �� 5$      $	��30* �6    �� 5%      $��1* �6    
 � ColumnDefinitions
 5(      �� 5)      $	��30* �6#   �� 5*      $	��30* �6#   �� 5+      $	��30* �6#   .+�50      �� -   5         ��Name$ synchronizeButton��50      
���   �$��Wyszukaj��6C   $
��Left=�6V   $��108.5,29,0,0q�6q   $	��Top=�6�   $��74��6�   $��1��6�   
�������$��25��6�   $��Century Gothic)�6�   � 51      -   5         �Name$ progressBar5��51      $y�	Collapsed=�60   $
��Left=�6G   $��24��6b   $��195.5,30,0,0q�6n   $	��Top=�6�   $	��126��6�   $��1��6�   $��2��6�   �� 55      -   5         ��Name$ citiesComboBox��55       �� 
IsEditable .  $
��Left=�6B   $��
176,30,0,0q�6]   $	��Top=�6q   $	��126��6�   $��2��6�   $��24��6�   $��Century Gothic)�6�   (  "System.Windows.Controls.DatePicker  57      -   5          Name$ datePicker2��57      $
��Left=�6/   $��	20,30,0,0q�6J   $	��Top=�6]   $��24��6u   $	��128��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ���	#FFACACAC$��Century Gothic)�6�   z�58      V� 59      .~�5:      �� �� 5;      �� 5<       �� Angle$ 0.112Q�6*   T� 5=      5>      5@      "  FontAwesome.WPF.ImageAwesome  5A      -   5          Name$ LoadingCircle��5A   5   $y�	Collapsed=�6     contrastColor   
Foreground# �  6L      Icon$ Spinner=�6y      Spin .    SpinDuration$ 5Q�6�   $��2��6�   $��90.5,23,0,5.5q�6�   �� 5B      -   5        $��pnlBottomMenu��5B   *    K� ZIndex$ 2��6    �� Orientation$ Vertical=�6?   $	��400��6V   $��Center=�6b   $��Bottom=�6   $��111,0,133,-101q�6�   $��3��6�   $��3��6�   $��2��6�   .+�5C      � .+�5D      �� -	   5        $��btnBottomMenuHide��5D      $��48��66   $��48��6A   $
��Hide��6N   $y�Hidden=�6]   5E      �� 5F      
���   �$��1q�6-   $	��100��6A   
�������._�5G      � .+�5H      �� -
   5         ��Name$ loadingTextBox��5H   "   $
��Left=�6:   $��15��6U   $��	10,47,0,0q�6a    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��148��6�   ���	#FFB8A2A2$��8(�6�   �� 5I      -   5        $ loadingTextBox2��5I   "   $
��Left=�6;   $��15��6V   $��10,7,0,0q�6b   $
 Wrap=�6t   $	��Top=�6�   $	��148��6�   ���	#FFB8A2A2$��8(�6�   �� 5J      -   5        $ loadingTextBox3��5J   "   $
��Left=�6;   $��15��6V   $��	10,27,0,0q�6b   $
 Wrap=�6u   $	��Top=�6�   $	��148��6�   ���	#FFB8A2A2$��8(�6�   �� 5K      -   5        $ loadingTextBox4��5K   "   $
��Left=�6;   $��15��6V   $��
211,30,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��148��6�   ���	#FFB8A2A2$��8(�6�   �� 5L      -   5        $ loadingTextBox5��5L   "   $
��Left=�6;   $��15��6V   $��
211,10,0,0q�6b   $
 Wrap=�6v   $	��Top=�6�   $	��148��6�   ���	#FFB8A2A2$��8(�6�   5M      5N      5O      �� 5P      $��Data:��6     themeDarkFontColor#���  6$   $
��Left=�6V   $��18,3,0,0q�6q   $	��Top=�6�   $��Century Gothic)�6�   $��14(�6�   �� 5Q      $��Miejscowość:��6   #���  6+   $
��Left=�6]   $��	176,3,0,0q�6x   $	��Top=�6�   $��Century Gothic)�6�   $��14(�6�   $��2��6�   �� 5R      -   5         ��Name$ noDataLabel��5R      #���  6)   $��Komunikat o braku danych��6[   $
��Left=�6~   $y�	Collapsed=�6�   $��80,140.5,0,0q�6�   $��1��6�   $	��Top=�6�   $��3��6�   $	��529��6�   $��69��6  $��Century Gothic)�6  $��20(�63  $��3��6A  �� 5S      -   5         ��Name$ noDataImage��5S      $
��Left=�6)   $y�	Collapsed=�6D   $	��100��6[   $��59.5,28.5,0,0q�6h   $��3��6   $	��Top=�6�   $	��100��6�   $4��./tristarweather;component/Images/sad_emoji.png��6�   $��1��6�   5T      5Z      