   M S B A M L   `   `   `  ����F  BNewHorizons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NewHorizonsNewHorizons  5   	   "    NewHorizons.PriorityStarting   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:NewHorizons     5   	     � Title$  PriorityStarting��5   	   $	��300��6"   $	��400��6/    � WindowStyle$
 None=�6;    � WindowStartupLocation$ CenterScreen=�6N    � 
ResizeMode$ NoResize=�6s    � ShowInTaskbar .  $
��Auto=�6�   $
��Auto=�6�    � 	Resources 5
         MyButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6!   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
���   �#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5      5      5      5      5      .��5       � -   5        ���	#FFFDFBFB.+�5!   
   �� 
���   �$��
0,10,0,265q�6#   $��Select Selection to edit��67   $��Microsoft YaHei Light)�6Z   $��18(�6}   $	��5,0q�6�   �� 5"   
   -   5         ��Name$ selectionListBox��5"      $
��Left=�6,   $	��215��6G   $��	10,45,0,0q�6T   $	��Top=�6g   $	��380��6   ��6�   Z� �� 5#   
   -   5         ��Name$ cancelButton��5#      #��[  6(   $��Cancel��6J   $
��Left=�6[   $��315,265,0,0q�6v   $	��Top=�6�   $��75��6�   ���	#FFE95B4C���	#FF3F3F46
�������$��25��6�   6�   �� 5$   
   -   5        $ newSelectionButton��5$      #��[  6.   $	��New��6P   $
��Left=�6^   $��
315,10,0,0q�6y   $	��Top=�6�   $��75��6�   ���	#FF0CB32D
�������$��25��6�   ���	#FF0F08086�   �� 5%   
   -   5        $ editSelectionButton��5%      #��[  6/   $
��Edit��6Q   $
��Left=�6`   $��233,265,0,0q�6{   $	��Top=�6�   $��75��6�   ���	#FF415B76
�������$��25��6�   ���	#FF0F08086  5&      5(      