   M S B A M L   `   `   `  ����I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  5           tristarweather.Pages.Page2   5      U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:tristarweather     5        N� Title$  Page2��5	       � 	Resources 5
         myHeaderTemplate  myHeaderStyle �� 
TargetType �� Property �� Value��%�   &	        &	 i     �� 5   
   .R�5      ]� .+�5      �� $��10(�6   
����  ���6@   �� 5      5      �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$ Century Gothic)�6+   5      5      .��5      �   pageBackground#���  6   .+�5   
   �� -   5         ��Name$ 
listOfDays��5       �� SelectedIndex$ 0��6'   $
��Left=�6:   $��
296,47,0,0q�6U   $	��Top=�6i   $	��156��6�   $��Century Gothic)�6�   $��14(�6�   �� 5   
     themeDarkFontColor#���  6   $%��Ile dni ma obejmywać prognoza:��6B   $
��Left=�6k   $��	10,42,0,0q�6�   $	��Top=�6�   $	��271��6�   $��Century Gothic)�6�   $��15(�6�    J� RenderTransformOrigin$ 0.542,1.857&�6�   �� 5   
   -   5         ��Name$ weatherDataGrid��5      $��Center=�6,   $	��175��6I   $��10,197,36,0q�6V   $	��Top=�6k   $	��598��6�   $��Disabled=�6�   #���  6�   #���  6�   	 �� View	 5      �� 5      .P�5      �� $
��Data��6%   
 �� Width$	
 110��63    �� HeaderContainerStyle# [ 6m    �� HeaderTemplate# [  6�    �� DisplayMemberBinding 6?   �� *DateAndTime+6�   �� 5      $��	Temp. [C]��6%   $
 60��68   # [ 6y   # [  6�    6C   �� *TemperatureInCelsius+6�   �� 5      $��Zachmurzenie��6%   $
 72��6;   # [ 6r   # [  6�    6F   �� *
Cloudiness+6�   �� 5       $��Wilgotność��6%   $
 60��69   # [ 6n   # [  6�    6D   �� *
Humidity+6�   �� 5!      $��	Temp. max��6%   $
 62��68   # [ 6l   # [  6�    6C   �� *	TempMax+6�   �� 5"      $��	Temp. min��6%   $
 62��68   # [ 6l   # [  6�    6C   �� *	TempMin+6�   �� 5#      $��
Ciśnienie��6%   $
 54��68   # [ 6x   # [  6�    6C   �� *PressureGroundLevel+6�   �� 5$      $��
Pr. wiatru��6%   $
 54��69   # [ 6o   # [  6�    6D   �� *	WindSpeed+6�   �� 5%      $��Kier. wiatru��6%   $
 58��6;   # [ 6o   # [  6�    6F   �� *	WindDir+6�   5&      5)      F� 5*   
   -   5         F�Name$ 
plotbutton��5*   7    ^� ShowOnDisabled . {�.   �� Stretch$
 Fill=�6]   �������O uр�O�р���р�� uр�O u� H� u� H���O��S��O��S u� H� u�@�q u�@�q@�q�@��@�q�@�� u�@�q u��2
 u��2
@����D�@����D� u��2
 u�@f��!� -1��!� -1��7��D���7��D�@�e�@f@�e�@f��!$%��470.728,130.465,144.772,266.535q�6D  6m  �� 5+   
   #���  6   $��Stwórz wykres:��6B   $
��Left=�6[   $��346,128,0,0q�6v   $	��Top=�6�   $	��119��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   �� 5,   
   $��Italic$�6   $��Source: OpenWeatherMap��6#   $
��Left=�6D   $��463,377,0,0q�6_   $	��Top=�6t   �� 5-   
   -   5        $ parametersToPlot��5-      $ 0��6-   $
��Left=�6@   $��
296,82,0,0q�6[   $	��Top=�6o   $	��156��6�   $��Century Gothic)�6�   $��14(�6�   �� 5.   
   #���  6   $)��#Parametr przedstawiony na wykresie:��6B   $
��Left=�6p   $��	10,77,0,0q�6�   $	��Top=�6�   $	��281��6�   $��Century Gothic)�6�   $��15(�6�   $ 0.542,1.857&�6�   �� 5/   
   #���  6   $(��"Prognoza pogody dla miasta Gdańsk��6B   $
��Left=�6n   $��
176,10,0,0q�6�   $	��Top=�6�   $	��305��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   F� 50   
   -   5        $ GetDataButton��50       � ToolTip$ Pobierz dane��6&   $
 Fill=�6=   �������Oduр�Odc��0Y�dc��0GO Q%��~� Q%�Й�dl���~� ���0GO ���0Y�duр�Odu���7�5nр�7�G���Q��G���c8 Zb�0,� Zb�0� �>��0,� $� ��c8 $� ��Q��5nр�7�5n$ ��253.398,130,361.603,267.14q�6P  6t  �� 51   
   #���  6   $��Pobierz dane:��6B   $
��Left=�6Z   $��129,128,0,0q�6u   $	��Top=�6�   $	��118��6�   $��Century Gothic)�6�   $��16(�6�   $ 0.542,1.857&�6�   52      53      