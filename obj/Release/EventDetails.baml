   M S B A M L   `   `   `  ���� I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  !    tristarweather.EventDetails   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:tristarweather       � Title$  EventDetails��$	��450��$��648.5�� � WindowStartupLocation$ Manual=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � 	Resources  �� 
TargetType �� Property �� Value��%�   '��       '�� A     �� " ��.���  � ��$ 0q���  �@��
IsReadOnly . �� " ��.���  � ��$ 0q���  �@��
IsReadOnly . ����  �� Opacity$	 0.9Q�	 �� Color$	 White��.��� -   
 �Name$
 MainGrid�� � ColumnDefinitions �� $	��10* ��� $	��10* ��� $	��10* ��� $	��10* � � RowDefinitions �� $	��30* ��� $	��10* ��� $	��20* �    AddImageToMapButton �� ImageSource j� Stretch��%>   &	        �� $ /Images/map_icon.png��$ UniformToFill=�.+�F� -    F�Name$ path1�� �� Stretch$
 Fill=��������O��7р�O��Oр�7��Oр�7��7р�O��7�������р�����р�����р�����р������H���р�C�t��a�4�����I��h6s��C�0��Hb��Hb�0��р�Ch6sѸH�0�����Hb�јt��C����H�ѸH���$��3��$��117.5,111.5,14.5,8.5q�$��2�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~���  �� ScaleY$ -1Q��� �� T� ���� " F�.���  � �� �	#FF263241 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �	#FF0068FF�� -    ��Name$ CategoryRectangle��$��0��
��� ���(  "System.Windows.Controls.WebBrowser  -     Name$ Browser��$
��Left=�$	��177��$	��Top=�$	��486��$��3��$��1��$��1�� J� OpacityMask �	#FFD9BE8C$��2���� -    ��Name$ WhatTextBox��$	��168��$��	10,57,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��152��$��18(�$��Century Gothic)�$
��Left=�$	��Top=���Z� ��Z� �� -   $ TimeTextBox��$
��Left=�$��38��$��0,57,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��162��$��1��$��24(�$��Century Gothic)���Z� ��Z� �� -   $ HourTextBox��$
��Left=�$��42��$��0,95,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��162��$��1��$��24(�$��Century Gothic)���Z� ��Z� �� -    ��Name$ facebookTextBox��$y�	Collapsed=�$
��Left=�$��22��$��	0,128,0,0q�$��2��$	��Top=�$	��324�����	#FFE6E6E6$��2��$��1����Z�  �� SelectionBrush Z� . �/� .T�J� .*�
Facebook�� -	    ��Name$ image��$��2��$
��Left=�$	��225��$	��Top=�$	��324��$��2���� -
   $ CategoryTextBox��$
��Left=�$��23��$��	10,10,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120��$��Century Gothic)�$��18(���Z� ��Z�  Z� � $
��Left=�$��39��$	��Top=�$	��162���� -   $ eventSiteTextBox��$y�	Collapsed=�$
��Left=�$��22��$��	0,128,0,0q�$��2��$	��Top=�$	��324�����	#FFE6E6E6$��2����Z�  Z� . �/� .T�J� .*�	EventSite�� -   $ 	PlaceName��$
��Left=�$	��203��$
 Wrap=�$��TextBox��$	��Top=�$	��152��$��Century Gothic)�$��14(�$��1��$��2��$��10,0,0,0q���Z� ��Z� �� -   $��58,111,66.5,7q�$��3��$��2������ " ��.���  � ��$ Images/map_icon.png�� P�  �@J�IsMouseOver . . ���  � ��$ Images/map_icon_blue.png��