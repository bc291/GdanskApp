   M S B A M L   `   `   `  ����I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  5   	   d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF 5   	   %    tristarweather.EventLocationMap   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:tristarweather     5   	   bwpfRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5   	     � Title$  Lokalizacja wydarzenia��5	   	   $	��700��6(   $
��1000��65    � 
ResizeMode$ NoResize=�6B    � 	Resources 5       �� 
TargetType �� Property �� Value   myHeaderTemplate  myHeaderStyle �� 
TargetType��%�  '��       &	  y     &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 0q�60   6<   �� 5       �@��
IsReadOnly . 6:   5      �� 5   
   .R�5      ]� .+�5      �� $��18(�6   
���������5      �� 5      5      5      5      �� 5   
   " ��6&   .�5       ��  � �� 5!      �� 5"      " ��6&   5$      5&      5(      5)      .��5+      � -   5         �Name$ MainGrid��5+      .+�5-   
   '  !Microsoft.Maps.MapControl.WPF.Map  -   5          Name$ EventMapBing��5-      +  %Microsoft.Maps.MapControl.WPF.MapCore	   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F	 @Auo9DRoX4zw6hDifIsqTM4NpcbMMb-nlUphjZifrT_ZnJ6V252cYoQlAy39PtQ9X 6(   
   Children.
 5.      �� -   5         ��Name$ eventInfoTextBox��5.      $
��Left=�60   $��47��6K    �� TextWrapping$
 Wrap=�6W   $��EventAddress��6k   $	��Top=�6   $	��304��6�   $��24(�6�   $��Century Gothic)�6�   ��6�   Z� ��6�   Z�  �� SelectionBrush 6�   Z� 6�   �� 5/      -   5        $ routeHintTextBox��5/      $��Center=�60   $	��104��6M   $
 Wrap=�6Z   $d��^Aby obliczyć drogę kliknij proszę dwa razy w wybrany punkt, lub podaj swój adres domowy ->��6n   $��Center=�6�   $	��328��6�   $��366,131,300,436.5q�6>  $��20(�6Y   �� TextAlignment$ Justify=�6g  ��6�   Z� ��6  Z�  6$  Z� .��6   J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         
BlurRadius$ 20Q�6'   .��52   "   53      �� 54      -   5        $ routeDistanceTextBox��54      $
��Left=�64   $��33��6O   $
 Wrap=�6[   $��RouteDetails��6o   $	��Top=�6�   $	��164��6�   $��861,0,-31,0q�6�   $��24(�6  $��Century Gothic)�6  ��6�   Z� ��6�   Z�  6�   Z� 6  �� 55      -   5        $��Oblicz trasę��55      $
��Left=�6,   $��31��6G   $	��Top=�6S   $	��111��6k   $��826,265,0,0q�6w   $��Century Gothic)�6�   
���   � J� Opacity$	 0.7Q�6�   
�������6�   �� 56      -   5        $ actualAddressTextBox��56   )    �� 
IsReadOnly .  $��20��6G   $	��Top=�6S   $��324,641,260,0q�6k   
���   ����	#FF1751FF �� 
CaretBrush
 �   �
 �   �$��Century Gothic)�6�   $��14(�6�   $
 0.35Q�6  
�������6  �� 57      -   5        $ streetTextBox��57   )    .  $��32��6@   $	��Top=�6L   $��794,178,30,0q�6d   
���   ����	#FF1751FF
 �����
 �   �$��Century Gothic)�6�   $��26(�6�   $
 0.35Q�6�   
�������6  �� 58      $��Ulica��6   $
��Left=�6$   $��41��6?   $	��Top=�6K   $��87��6c   $��700,170,0,0q�6n   $��26(�6�   $��Century Gothic)�6�   �� 59      -	   5        $ cityTextBox��59   )    .  $��33��6>   $	��Top=�6J   $��795,218,29,0q�6b   
���   ����	#FF1751FF
 �����
 �   �$��26(�6�   $��Century Gothic)�6�   $
 0.35Q�6�   
�������6  �� 5:      $��Miasto��6   $
��Left=�6%   $��42��6@   $	��Top=�6L   $	��126��6d   $��682,209,0,0q�6p   $��26(�6�   $��Century Gothic)�6�   �� 5;      -
   5         ��Name$ actualAdresLabel��5;      $��Aktualny adres domowy:��6.   $
��Left=�6O   $��28��6j   $	��Top=�6v   $	��178��6�   $��128,637,0,0q�6�   $��14(�6�   $��Century Gothic)�6�   �� 5<      -   5        $ routeTimeTextBox��5<      $
��Left=�60   $��33��6K   $
 Wrap=�6W   $��	RouteTime��6k   $	��Top=�6|   $	��164��6�   $��862,40,-32,0q�6�   $��24(�6�   $��Century Gothic)�6  ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5=      -   5        $ routeTimeTrafficTextBox��5=      $
��Left=�67   $��33��6R   $
 Wrap=�6^   $��RouteTimeTraffic��6r   $	��Top=�6�   $	��164��6�   $��862,76,-32,0q�6�   $��24(�6  $��Century Gothic)�6  ��6�   Z� ��6�   Z�  6�   Z� 6  �� 5>      -   5        $ distanceLabel��5>      $��Całkowity dystans:��6+   $
��Left=�6H   $��34��6c   $	��Top=�6o   $	��184��6�   $��	672,0,0,0q�6�   $��18(�6�   $��Century Gothic)�6�   �� 5?      -   5        $ totalTimeLabel��5?      $��Czas przejazdu:��6,   $
��Left=�6F   $��34��6a   $	��Top=�6m   $	��184��6�   $��
699,35,0,0q�6�   $��18(�6�   $��Century Gothic)�6�   �� 5@      -   5        $ totalTimeTrafficLabel��5@      $��Czas przejazdu (korki):��63   $
��Left=�6U   $��34��6p   $	��Top=�6|   $	��206��6�   $��
644,73,0,0q�6�   $��18(�6�   $��Century Gothic)�6�   �� 5A      -   5        $ routeInstructionsLabel��5A      $��Wskazówki dojazdu: ��64   $
��Left=�6R   $��42��6m   $	��Top=�6y   $	��232��6�   $��724,352,0,0q�6�   $��18(�6�   $��Century Gothic)�6�   �� 5B      -   5        $" directoryInstructionsTextBox��5B      $
��Left=�6<   $	��180��6W   $
 Wrap=�6d   $	��Top=�6x   $	��297��6�   $��687,388,0,0q�6�   
���   �$
 0.45Q�6�   
���������6�   Z� 6�   5D      5E      5F      