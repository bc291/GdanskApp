   M S B A M L   `   `   `  ���� I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather      tristarweather.Page3   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:tristarweather     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     N� Title$  Page3�� � 	Resources    myHeaderTemplate  sbShowBottomMenu �� TargetProperty t� From	 t� To g� DecelerationRatio g� Duration  sbHideBottomMenu g� AccelerationRatio��%  &	        &	 2     &	 �     �� .R�]� .+��� $��16(�
����  ����� �� .��t� $ Margin�$ 111,0,133,-101X�$ 111,0,133,-30X�$	 0.9Q�$ 0:0:1D��� .��t� $ Margin�$ 111,0,133,-30X�$ 111,0,133,-101X�$	 0.9Q�$ 0:0:1D�.���� .��� -    �Name$ MainGrid��  pageBackground#���  $	��426��$	��644��	 � RowDefinitions	 �� $	��11* ��� $	��30* ��� $��1* ��� $	��30* ��� $��1* �
 � ColumnDefinitions
 �� $	��30* ��� $	��30* ��� $	��30* �.+��� -    ��Name$ synchronizeButton��
���   �$��Wyszukaj��$
��Left=�$��108.5,29,0,0q�$	��Top=�$��74��$��1��
�������$��25��$��Century Gothic)�� -    �Name$ progressBar5��$y�	Collapsed=�$
��Left=�$��24��$��195.5,30,0,0q�$	��Top=�$	��126��$��1��$��2���� -    ��Name$ 	ComboBox1��$
��Left=�$��
176,30,0,0q�$	��Top=�$	��126��$��2��$��24��$��Century Gothic)�(  "System.Windows.Controls.DatePicker  -     Name$ datePicker2��$
��Left=�$��	20,30,0,0q�$	��Top=�$��28��$	��128�� J� RenderTransformOrigin$ 0.5,0.5&�$��14(�$��Century Gothic)���Z� z�V� .~��� �� ��  �� Angle$ 0.112Q�T� "  FontAwesome.WPF.ImageAwesome  -     Name$ LoadingCircle��$y�	Collapsed=�  contrastColor   
Foreground# �     Icon$ Spinner=�   Spin .    SpinDuration$ 5Q�$��2��$��90.5,23,0,5.5q��� -   $��pnlBottomMenu�� K� ZIndex$ 2�� �� Orientation$ Vertical=�$	��400��$��Center=�$��Bottom=�$��111,0,133,-101q�$��3��$��3��$��2��.+�� .+��� -	   $��btnBottomMenuHide��$��48��$��48��$
��Hide��$y�Hidden=��� 
���   �$��1q�$	��100��
�������._�� .+��� -
    ��Name$ loadingTextBox��$
��Left=�$��15��$��	10,47,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��148�����	#FFB8A2A2$��8(��� -   $ loadingTextBox2��$
��Left=�$��15��$��10,7,0,0q�$
 Wrap=�$	��Top=�$	��148�����	#FFB8A2A2$��8(��� -   $ loadingTextBox3��$
��Left=�$��15��$��	10,27,0,0q�$
 Wrap=�$	��Top=�$	��148�����	#FFB8A2A2$��8(��� -   $ loadingTextBox4��$
��Left=�$��15��$��
211,30,0,0q�$
 Wrap=�$	��Top=�$	��148�����	#FFB8A2A2$��8(��� -   $ loadingTextBox5��$
��Left=�$��15��$��
211,10,0,0q�$
 Wrap=�$	��Top=�$	��148�����	#FFB8A2A2$��8(��� $��Data:��  themeDarkFontColor#���  $
��Left=�$��18,3,0,0q�$	��Top=�$��Century Gothic)�$��14(��� $��Miejscowość:��#���  $
��Left=�$��	176,3,0,0q�$	��Top=�$��Century Gothic)�$��14(�$��2��