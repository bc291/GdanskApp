   M S B A M L   `   `   `  ���� I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     tristarweather.Page1   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:tristarweather     6sys&clr-namespace:System;assembly=mscorlib       N� Title$  Page1�� � 	Resources    myHeaderStyle �� 
TargetType �� Property �� Value  myHeaderTemplate  TransparentStyle �� 
TargetType �� Triggers P� Property P� Value��%�  &	        '�� G     (�� �     *,*SystemParameters.VerticalScrollBarWidthKey+)&	 �     &	 �     �� " ��.���  � ��
 �������  � ��$ Century Gothic)��� " ��.���  � ��$ Center=���  � ��$ Century Gothic)�X�10Q��� .R�]� .+��� $��16(�
����  ����� �� " ��.���  � �� �� " ��.R��� ���� " �� P�  �@J�IsMouseOver . . ���  � ��
 ��� �._�� 
������ .+��� .���   pageBackground#���  	 � RowDefinitions	 �� $��0* ��� .+��� -   
 ��Name$
 fruitdatagrid2��$��Center=�$	��175��$��81,229,297,0q�$	��Top=�$	��266��$��Disabled=�$��2��  ThemeDarkFontColor#���    listviewBackground#���   �� View �� .P��� $
��Data�� �� Width$	 130�� �� HeaderContainerStyle# [   �� HeaderTemplate# [  �� DisplayMemberBinding �� *Date+�� $��	Wartość��$	 130��# [  # [  �� *meassurement+(  "System.Windows.Controls.DatePicker  -     Name$ 
datePicker��
 �� Now   SelectedDate# Z $
��Left=�$��
258,25,0,0q�$	��Top=� J� RenderTransformOrigin$ 0.836,-0.083&�$��Century Gothic)�$��14(�$��2��$	��156����Z� �� -    ��Name$ listOfStations��$
��Left=�$��
258,71,0,0q�$	��Top=�$	��156��$��Century Gothic)�$��14(�$��2���� -   $ 
typeOfData��$
��Left=�$��258,116,0,0q�$	��Top=�$	��156��$��Century Gothic)�$��14(�$��2��F� -    F�Name$ GetDataButton�� � ToolTip$ Pobierz dane�� �� Stretch$
 Fill=��������Oduр�Odc��0Y�dc��0GO Q%��~� Q%�Й�dl���~� ���0GO ���0Y�duр�Odu���7�5nр�7�G���Q��G���c8 Zb�0,� Zb�0� �>��0,� $� ��c8 $� ��Q��5nр�7�5n$ ��193.848,174,421.153,223.14q�$��2������ " F�.���  � �� �	#FF263241 P�  �@J�IsMouseOver . . ���  � ��
 ��� �z�V� .~���  �� ScaleX$ -1Q��� �� T�  T� X$ -15.173Q�F� -   $ 
plotbutton�� ^� ShowOnDisabled . {�.  $
 Fill=��������O uр�O�р���р�� uр�O u� H� u� H���O��S��O��S u� H� u�@�q u�@�q@�q�@��@�q�@�� u�@�q u��2
 u��2
@����D�@����D� u��2
 u�@f��!� -1��!� -1��7��D���7��D�@�e�@f@�e�@f��!$%��430.178,174.332,185.322,222.668q�$��2������ " F�.���  � �� �	#FF263241 P�  �@J�IsMouseOver . . ���  � ��
 ��� �z�V� .~��� $ -1Q��� �� T� $ -15.173Q��� $��Proszę wybrać datę:��  themeDarkFontColor#���  $
��Left=�$��	18,22,0,0q�$	��Top=�$	��214��$��Century Gothic)�$��16(�$��2���� $��Stację pomiarową:��#���  $
��Left=�$��	18,66,0,0q�$	��Top=�$	��200��$��Century Gothic)�$��16(�$ 0.542,1.857&�$��2���� $��	Parametr:��#���  $
��Left=�$��
18,111,0,0q�$	��Top=�$	��129��$��Century Gothic)�$��16(�$ 0.542,1.857&�$��2���� $��Stwórz wykres:��#���  $
��Left=�$��252,172,0,0q�$	��Top=�$	��119��$��Century Gothic)�$��16(�$ 0.542,1.857&�$��2���� $��Pobierz dane:��#���  $
��Left=�$��
16,172,0,0q�$	��Top=�$	��118��$��Century Gothic)�$��16(�$ 0.542,1.857&�$��2��