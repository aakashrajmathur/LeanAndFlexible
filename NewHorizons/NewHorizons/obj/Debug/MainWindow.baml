   M S B A M L   `   `   `  ����F  BNewHorizons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NewHorizonsNewHorizons  5   	   X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	       NewHorizons.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:NewHorizons     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
MainWindow��5	   	   $
��1000��6    � Icon$&  Icons/AlwaysIncludedSelected.png��6)    � WindowStartupLocation$ CenterScreen=�6Q    � WindowState$ 	Maximized=�6v   .��5
      � -   5        ���	#FFE9EAED$
��Auto=�5
   7   $
��Auto=�5       J� SnapsToDevicePixels . .+�5   
   o� -   5         o�Name$
 menu��5      $��18��6   $	��Top=�6)   ���	#FFD2D2D2.@�5      m� -   5         m�Name$ FileMenuItem��5      $
��File��6-   
���   �.@�5      m� -   5        $ NewMenuSubItem��5      $	��New��63   $
��Left=�6@   $	��140��6[   
���   �6g   m� 5      -   5        $ OpenMenuSubItem��5      $
��Open��64   $
��Left=�6B   $	��140��6]   
���   �6i   m� 5      -   5        $ SaveMenuSubItem��5      $
��Save��64   $
��Left=�6B   $	��140��6]   
���   �6i   m� 5      -   5        $ SaveAsMenuSubItem��5      $��Save As��66   $
��Left=�6G   $	��140��6b   
���   �6n   m� 5      -	   5        $ ExitMenuSubItem��5      $
��Exit��64   $
��Left=�6B   $	��140��6]   
���   �6i   5      m� 5      -
   5        $ DataTransferMenuItem��5      $��Data Transfer��65   
���   �.@�5      m� -   5        $ ImportCSVMenuSubItem��5      $��
Import CSV��69   $
��Left=�6M   $	��160��6h   
���   �6�   m� 5      -   5        $ ImportExcelMenuSubItem��5      $��Import Excel��6;   $
��Left=�6Q   $	��160��6l   6x   5      m� 5      -   5        $ HelpMenuItem��5      $
��Help��6-   
���   �6;   5      �� 5   
   -   5         ��Name$ AppBarStackPanel��5      $��52��6/   $��0,18,0,0q�6;   $	��Top=�6M   ���	#FF3DB1CB.+�5      �� $��52��6   $��0,0,0,0q�6%   $	��Top=�66   	 �� Orientation$	 
Horizontal=�6N   $��Center=�6g   .+�5      �� .+�5      �� -   5        
 ��Name$
 HomeIcon��5      $��32��6.   $��32��6:   $��Icons/Home.png��6E   $��5,4,5,0q�6]   6n   �� 5      -   5         ��Name$ 	HomeLabel��5      $
��Home��6/   $��8(�6>   $��Center=�6K   
�������$��18��6{   $	��5,2q�6�   6�   5      �� 5       .+�5!      �� -   5        $
 PriorityIcon��5!      $��32��62   $��32��6>   $��Icons/Priority.png��6I   $��5,4,5,0q�6e   6�   �� 5"      -   5        $ PriorityLabel��5"      $��Priority��63   $��8(�6F   $��Center=�6S   
�������$��18��6�   $	��5,2q�6�   6�   5#      �� 5$      .+�5%      �� -   5        $
 
StudioIcon��5%      $��32��60   $��32��6<   $��Icons/Studio.png��6G   $��5,4,5,0q�6a   6�   �� 5&      -   5        $ StudioLabel��5&      $��Studio��61   $��8(�6B   $��Center=�6O   
�������$��18��6   $	��5,2q�6�   6�   5'      5(      5)      ]� 5*   
   -   5         ]�Name$ AppBody��5*      $��0,70,0,0q�6&   }�.  $��Stretch=�5,      $
��Auto��5-      $
��Auto=�5.      $
��Auto=�5/      ��. .+�51      ]� $��0,0,0,0q�6   $��Stretch=�6*   $��Center=�52      }�.  $
��Auto=�55      .+�56      !   NewHorizons.HomeUserControl  -   5          Name$ homeUserControl��56   (   $��0,0,0,0q�57   (   }�.  $
��Auto=�59   (   %   NewHorizons.PriorityUserControl  5:      -   5          Name$ priorityUserControl��5:   ,   $��0,0,0,0q�5;   ,   $	��Top=�5<   ,   $
��Auto=�5=   ,   $
��Auto=�5>   ,   ��. 5?   ,   #   NewHorizons.StudioUserControl  5@      -   5          Name$ studioUserControl��5@   *   }�.  $��0q�5B   *   $��Stretch=�5C   *   $	��Top=�5D   *   $��Stretch=�5E   *   $
��Auto=�5F   *   5G      5H      5I      5J      