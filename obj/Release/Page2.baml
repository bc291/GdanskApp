   M S B A M L   `   `   `  ���� I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather      tristarweather.Page2   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:tristarweather       N� Title$  Page2�� � 	Resources    myHeaderTemplate  myHeaderStyle �� 
TargetType �� Property �� Value��%�   &	        &	 2     �� .R�]� .+��� $��10(�
����  ����� �� " ��.���  � ��
 �������  � ��$ Century Gothic)�.���   pageBackground#���  .+��� -    ��Name$ 
listOfDays�� �� SelectedIndex$ 0��$
��Left=�$��
296,47,0,0q�$	��Top=�$	��156��$��Century Gothic)�$��14(���   themeDarkFontColor#���  $%��Ile dni ma obejmywać prognoza:��$
��Left=�$��	10,42,0,0q�$	��Top=�$	��271��$��Century Gothic)�$��15(� J� RenderTransformOrigin$ 0.542,1.857&��� -    ��Name$ fruitdatagrid2��$��Center=�$	��175��$��10,197,36,0q�$	��Top=�$	��598��$��Disabled=�  ThemeDarkFontColor#���    PageBackground#���  	 �� View	 �� .P��� $
��Data��
 �� Width$	
 110�� �� HeaderContainerStyle# [  �� HeaderTemplate# [   �� DisplayMemberBinding �� *DateAndTime+�� $��	Temp. [C]��$
 60��# [ # [   �� *TemperatureInCelsius+�� $��Zachmurzenie��$
 72��# [ # [   �� *
Cloudiness+�� $��Wilgotność��$
 60��# [ # [   �� *
Humidity+�� $��	Temp. max��$
 62��# [ # [   �� *	TempMax+�� $��	Temp. min��$
 62��# [ # [   �� *	TempMin+�� $��
Ciśnienie��$
 54��# [ # [   �� *PressureGroundLevel+�� $��
Pr. wiatru��$
 54��# [ # [   �� *	WindSpeed+�� $��Kier. wiatru��$
 58��# [ # [   �� *	WindDir+F� -    F�Name$ 
plotbutton�� ^� ShowOnDisabled . {�.   �� Stretch$
 Fill=��������O uр�O�р���р�� uр�O u� H� u� H���O��S��O��S u� H� u�@�q u�@�q@�q�@��@�q�@�� u�@�q u��2
 u��2
@����D�@����D� u��2
 u�@f��!� -1��!� -1��7��D���7��D�@�e�@f@�e�@f��!$$��524.178,130.465,91.322,266.535q����� " F�.���  � �� �	#FF263241 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �	#FF0068FFz�V� .~���  �� ScaleX$ -1Q��� �� T�  T� X$ -15.173Q��� #���  $��Stwórz wykres:��$
��Left=�$��346,128,0,0q�$	��Top=�$	��119��$��Century Gothic)�$��16(�$ 0.542,1.857&��� $��Italic$�$��Source: OpenWeatherMap��$
��Left=�$��463,377,0,0q�$	��Top=��� -   $ parametersToPlot��$ 0��$
��Left=�$��
296,82,0,0q�$	��Top=�$	��156��$��Century Gothic)�$��14(��� #���  $)��#Parametr przedstawiony na wykresie:��$
��Left=�$��	10,77,0,0q�$	��Top=�$	��281��$��Century Gothic)�$��15(�$ 0.542,1.857&��� #���  $(��"Prognoza pogody dla miasta Gdańsk��$
��Left=�$��
176,10,0,0q�$	��Top=�$	��305��$��Century Gothic)�$��16(�$ 0.542,1.857&�F� -   $ GetDataButton�� � ToolTip$ Pobierz dane��$
 Fill=��������Oduр�Odc��0Y�dc��0GO Q%��~� Q%�Й�dl���~� ���0GO ���0Y�duр�Odu���7�5nр�7�G���Q��G���c8 Zb�0,� Zb�0� �>��0,� $� ��c8 $� ��Q��5nр�7�5n$ ��306.848,130,308.153,267.14q����� " F�.���  � �� �	#FF263241 P�  �@J�IsMouseOver . . ���  � �� �	#FF0068FFz�V� .~��� $ -1Q��� �� T� $ -15.173Q��� #���  $��Pobierz dane:��$
��Left=�$��129,128,0,0q�$	��Top=�$	��118��$��Century Gothic)�$��16(�$ 0.542,1.857&�