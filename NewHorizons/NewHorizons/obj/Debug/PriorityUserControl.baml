   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5      F BNewHorizons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NewHorizonsNewHorizons 5      %   NewHorizons.PriorityUserControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      +localclr-namespace:NewHorizons     5      $	��800��5      $	��400��5	      $	��800��6   $
��Auto��6,   ��. $
��Auto=�5      $
��Auto=�5        � 	Resources  5         MyButton �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6!   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5       5!      .��5#      � .+�5$   
   �� .��5%      �� $	��800��6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   .+�5'      �� $��36(�6   
���   �$��Microsoft YaHei UI Light)�6=   $	��Top=�6c   $��Priority��6{   $��
10,0,318,0q�6�   �� 5(      -   5        	 ��Name$	 
SaveButton��5(      #��[  62   $
��Save��6T   $
��Left=�6c   $��5,15,5,5q�6~   $	��Top=�6�   $��75��6�   ���	#FF415B76
�������$��25��6�   ���	#FF0F08086  �� 5)      -   5        $	 SaveAsButton��5)      #��[  64   $��Save As��6V   $
��Left=�6h   $��5,15,5,5q�6�   $	��Top=�6�   $��75��6�   ���	#FF0CB32D
�������$��25��6�   ���	#FF0F08086  �� 5*      -   5        $	 
ExitButton��5*      #��[  62   $
��Exit��6T   $
��Left=�6c   $��5,15,5,5q�6~   $	��Top=�6�   $��75��6�   ���	#FFE95B4C���	#FF3F3F46
�������$��25��6�   6  5+      �� 5,      -   5        
 ��Name$
 priorityNameLabel��5,      $��8(�63   
���   �$��Microsoft YaHei UI Light)�6S   $��selection name��6y   �� 5-      -   5        $
 statusLabel��5-      $��Label��6-   $
��Left=�6=   $��10,0,0,0q�6X   $	��Top=�6j   $	��365��6�   $	��118��6�   �� 5/      $ 
Horizontal=�6   $��Center=�66   .+�50      �� -   5         ��Name$ PrioritySlider��50      $
��Left=�65   $��50,0,0,0q�6P   $	��Top=�6b   $	��620��6z   $��21��6�    � SmallChange$ 1Q�6�    � Maximum$	 100Q�6�    �� TickPlacement$ BottomRight=�6�    �� IsSnapToTickEnabled . 6�   �� 51      -   5        $
 prioritySliderLabel��51      $��Label��69   $
��Left=�6I   $��0,0,0,0q�6d   $	��Top=�6u   52      �� 54      $ 
Horizontal=�6   .+�55      �� $	��200��6#   .��56      �� -   5         ��Name$ StackPanelAlwaysIncluded��56   %   58      59      �� 5:      $	��200��6#   .��5;      �� -	   5        $ StackPanelIncluded��5;   %   5=      5>      �� 5?      $	��200��6#   .��5@      �� -
   5        $ StackPanelNotIncluded��5@   %   5B      5C      �� 5D      $	��200��6#   .��5E      �� -   5        $ StackPanelNeverIncluded��5E   %   5G      5H      5I      5K      5L      5M      5N      