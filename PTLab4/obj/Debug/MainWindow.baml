   M S B A M L   `   `   `  ����A  =PTLab4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PTLab4PTLab4  5   	       PTLab4.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:PTLab4     5   	     � Title$  
MainWindow��5   	   $	��363��6   $	��525��6)   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
      $
��Left=�6%   $��	10,54,0,0q�6@   $	��Top=�6S   $	��238��6k   $	��497��6x      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5      $ Model��6?    6%   �� *Model+6?     5      $ Engine��6@      SortMemberPath$ Engine��6P      CanUserSort .  6%   �� *Engine+6h     5      $
 Year��6>    6%   �� *Year+6>     5      $ 
EngineType��6D    6%   �� *
EngineType+6D   5      �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��22��6>   $��	76,14,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��120��6�   6�   �� 5   
   -   5        	 ��Name$	 label��5      $��Szukaj:��6   $
��Left=�61   $��	25,10,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $	 label1��5      $��Kolumna:��6    $
��Left=�63   $��
201,10,0,0q�6N   $	��Top=�6b   
 J� RenderTransformOrigin$
 0.053,0.615&�6z   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
265,14,0,0q�6@   $	��Top=�6T   $	��120��6l   .@�5      �� -   5        $��Model��5   '   
 � Tag$ Model��6   $��Model��64   �� 5      -   5        $
��Year��5   &   $
 Year��6   $
��Year��62   5      �� 5   
   -   5         ��Name$ button��5      $��Szukaj��6!   $
��Left=�62   $��
411,14,0,0q�6M   $	��Top=�6a   $��75��6y   �� 5   
   -	   5        $ dodajButton��5      $��Dodaj��6&   $
��Left=�66   $��
10,297,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   5      5      