   M S B A M L   `   `   `  ���� I  Etristarweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:tristarweathertristarweather  d `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF %    tristarweather.EventLocationMap   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:tristarweather     bwpfRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF       � Title$  Lokalizacja wydarzenia��$	��700��$
��1000�� � 
ResizeMode$ NoResize=� � 	Resources  �� 
TargetType �� Property �� Value   myHeaderTemplate  myHeaderStyle �� 
TargetType��%�   '��       &	  A     &	 s     �� " ��.���  � ��$ 0q���  �@��
IsReadOnly . �� .R�]� .+��� $��18(�
����������� �� " ��.���  � �� �� " ��.��� -    �Name$ MainGrid��.+�'  !Microsoft.Maps.MapControl.WPF.Map  -     Name$ EventMapBing��+  %Microsoft.Maps.MapControl.WPF.MapCore	   CredentialsProviderT  NMicrosoft.Maps.MapControl.WPF.Design.ApplicationIdCredentialsProviderConverter$F	 @Auo9DRoX4zw6hDifIsqTM4NpcbMMb-nlUphjZifrT_ZnJ6V252cYoQlAy39PtQ9X 
   Children.
 �� -    ��Name$ eventInfoTextBox��$
��Left=�$��47�� �� TextWrapping$
 Wrap=�$��EventAddress��$	��Top=�$	��304��$��24(�$��Century Gothic)���Z� ��Z�  �� SelectionBrush Z� �� -   $ routeHintTextBox��$��Center=�$	��104��$
 Wrap=�$d��^Aby obliczyć drogę kliknij proszę dwa razy w wybrany punkt, lub podaj swój adres domowy ->��$��Center=�$	��328��$��366,131,300,436.5q�$��20(� �� TextAlignment$ Justify=���Z� ��Z�  Z� .�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�.���� -   $ routeDistanceTextBox��$
��Left=�$��33��$
 Wrap=�$��RouteDetails��$	��Top=�$	��164��$��861,0,-31,0q�$��24(�$��Century Gothic)���Z� ��Z�  Z� �� -   $��Oblicz trasę��$
��Left=�$��31��$	��Top=�$	��111��$��826,265,0,0q�$��Century Gothic)�
���   � J� Opacity$	 0.7Q�
��������� -   $ actualAddressTextBox�� �� 
IsReadOnly .  $��20��$	��Top=�$��324,641,260,0q�
���   ����	#FF1751FF �� 
CaretBrush
 �   �
 �   �$��Century Gothic)�$��14(�$
 0.35Q�
��������� -   $ streetTextBox�� .  $��32��$	��Top=�$��794,178,30,0q�
���   ����	#FF1751FF
 �����
 �   �$��Century Gothic)�$��26(�$
 0.35Q�
��������� $��Ulica��$
��Left=�$��41��$	��Top=�$��87��$��700,170,0,0q�$��26(�$��Century Gothic)��� -	   $ cityTextBox�� .  $��33��$	��Top=�$��795,218,29,0q�
���   ����	#FF1751FF
 �����
 �   �$��26(�$��Century Gothic)�$
 0.35Q�
��������� $��Miasto��$
��Left=�$��42��$	��Top=�$	��126��$��682,209,0,0q�$��26(�$��Century Gothic)��� -
    ��Name$ actualAdresLabel��$��Aktualny adres domowy:��$
��Left=�$��28��$	��Top=�$	��178��$��128,637,0,0q�$��14(�$��Century Gothic)��� -   $ routeTimeTextBox��$
��Left=�$��33��$
 Wrap=�$��	RouteTime��$	��Top=�$	��164��$��862,40,-32,0q�$��24(�$��Century Gothic)���Z� ��Z�  Z� �� -   $ routeTimeTrafficTextBox��$
��Left=�$��33��$
 Wrap=�$��RouteTimeTraffic��$	��Top=�$	��164��$��862,76,-32,0q�$��24(�$��Century Gothic)���Z� ��Z�  Z� �� -   $ distanceLabel��$��Całkowity dystans:��$
��Left=�$��34��$	��Top=�$	��184��$��	672,0,0,0q�$��18(�$��Century Gothic)��� -   $ totalTimeLabel��$��Czas przejazdu:��$
��Left=�$��34��$	��Top=�$	��184��$��
699,35,0,0q�$��18(�$��Century Gothic)��� -   $ totalTimeTrafficLabel��$��Czas przejazdu (korki):��$
��Left=�$��34��$	��Top=�$	��206��$��
644,73,0,0q�$��18(�$��Century Gothic)��� -   $ routeInstructionsLabel��$��Wskazówki dojazdu: ��$
��Left=�$��42��$	��Top=�$	��232��$��724,352,0,0q�$��18(�$��Century Gothic)��� -   $" directoryInstructionsTextBox��$
��Left=�$	��180��$
 Wrap=�$	��Top=�$	��297��$��687,388,0,0q�
���   �$
 0.45Q�
���������Z� 