   M S B A M L   `   `   `  ����I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5           tristarweather.Pages.Page1   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:tristarweather     5      6sys&clr-namespace:System;assembly=mscorlib     5        N� Title$  Page1��5
       � 	Resources 5         myHeaderStyle �� 
TargetType �� Property �� Value  myHeaderTemplate��%�  &	        '��      (��      5      *,*SystemParameters.VerticalScrollBarWidthKey+)&	     �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$ Century Gothic)�6+   6D   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Century Gothic)�6+   6D   5      X�5   
   10Q�6W   �� 5   
   .R�5      ]� .+�5      �� $��16(�6   
����  ���5      �� 5      5      5       5!      5"      .��5$      �   pageBackground#���  6    � RowDefinitions 5%   
   �� 5&      $��0* �6   �� 5'      .+�5)   
   �� -   5         ��Name$ weatherList��5)      $��Center=�6(   $	��175��6E   $��81,229,297,0q�6R   $	��Top=�6h   $	��266��6�   $��Disabled=�6�   $��2��6�     themeDarkFontColor#���  6�     listviewBackground#���  6   �� View 5*      �� 5+      .P�5,      �� $
��Data��6%    �� Width$	 130��63   	 �� HeaderContainerStyle#	 [  6f   
 �� HeaderTemplate#
 [ 6�    �� DisplayMemberBinding 6?   �� *Date+6�   �� 5-      $��	Wartość��6%   $	 130��66   #	 [  6p   #
 [ 6�    6B   �� *meassurement+6�   5.      50      (  "System.Windows.Controls.DatePicker  52   
   -   5          Name$ 
datePicker��52   @   
 �� Now   SelectedDate# Z 6   $
��Left=�6T   $��
258,25,0,0q�6o   $	��Top=�6�    J� RenderTransformOrigin$ 0.836,-0.083&�6�   $��Century Gothic)�6�   $��14(�6�   $��2��6�   $	��156��6�   ���	#FFACACAC6  �� 53   
   -   5         ��Name$ listOfStations��53      $
��Left=�6,   $��
258,71,0,0q�6G   $	��Top=�6[   $	��156��6s   $��Century Gothic)�6   $��14(�6�   $��2��6�   �� 54   
   -   5        $ 
typeOfData��54      $
��Left=�6(   $��258,116,0,0q�6C   $	��Top=�6X   $	��156��6p   $��Century Gothic)�6|   $��14(�6�   $��2��6�   F� 55   
   -   5         F�Name$ GetDataButton��55       � ToolTip$ Pobierz dane��6&    �� Stretch$
 Fill=�6=   �������Oduр�Odc��0Y�dc��0GO Q%��~� Q%�Й�dl���~� ���0GO ���0Y�duр�Odu���7�5nр�7�G���Q��G���c8 Zb�0,� Zb�0� �>��0,� $� ��c8 $� ��Q��5nр�7�5n$ ��141.848,174,473.153,223.14q�6P  $��2��6t  6�  F� 56   
   -   5        $ 
plotbutton��56   6    ^� ShowOnDisabled . {�.  $
 Fill=�6\   �������O uр�O�р���р�� uр�O u� H� u� H���O��S��O��S u� H� u�@�q u�@�q@�q�@��@�q�@�� u�@�q u��2
 u��2
@����D�@����D� u��2
 u�@f��!� -1��!� -1��7��D���7��D�@�e�@f@�e�@f��!$%��378.178,174.332,237.322,222.668q�6C  $��2��6l  6}  �� 57   
   $��Proszę wybrać datę:��6   #���  6.   $
��Left=�6`   $��	18,22,0,0q�6{   $	��Top=�6�   $	��214��6�   $��Century Gothic)�6�   $��16(�6�   $��2��6�   �� 58   
   $��Stację pomiarową:��6   #���  6,   $
��Left=�6^   $��	18,66,0,0q�6y   $	��Top=�6�   $	��200��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   $��2��6�   �� 59   
   $��	Parametr:��6   #���  6$   $
��Left=�6V   $��
18,111,0,0q�6q   $	��Top=�6�   $	��129��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   $��2��6�   �� 5:   
   $��Stwórz wykres:��6   #���  6)   $
��Left=�6[   $��252,172,0,0q�6v   $	��Top=�6�   $	��119��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   $��2��6�   �� 5;   
   $��Pobierz dane:��6   #���  6(   $
��Left=�6Z   $��
16,172,0,0q�6u   $	��Top=�6�   $	��118��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   $��2��6�   5<      5=      