   M S B A M L   `   `   `  ����F  BNewHorizons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NewHorizonsNewHorizons  5      #    NewHorizons.StudioUserControl   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:NewHorizons     5      $��Stretch=�5      $
��1000��5	   "   $	��400��62   $
��1000��6A   .��5      � .+�5   
   �� -   5          ��Name$  topStackPanel��5      $��50��6,   $	��Top=�68   ���	#3F742A2A �� Orientation$ 
Horizontal=�6g   .+�5      �� -   5         ��Name$ saveLayoutButton��5      $��1q�6/   $��10,0,0,0q�6;   $��55��6M   $��0q�6X   ���	#00DDDDDD.��5      �� .+�5      �� $��Icons/Save32IconBlack.png��6   $
��None=�6?   �� 5      $��
ExtraLight"�6    $��10(�68   $��Center=�6F   Save Layout6p   5      5      �� 5      -   5        $ editDimensionsButton��5      $��1q�63   $��10,0,0,0q�6?   $��50��6Q   $��0q�6\   ���	#00DDDDDD.��5      �� .+�5      �� $��Icons/Edit32IconBlack.png��6   $
��None=�6?   �� 5      $��
ExtraLight"�6    $��10(�68   $��Center=�6F   	Edit size6n   5      5      ]� 5      -   5        $��ScoreDockPanel��5      $��Center=�6.   ���	#7FB1E29B$��7,0,0,0q�6`   $	��170��6q   .+�5      �� $��
ExtraLight"�6   $��21(�60   $��60��6>   $��Center=�6I   $��Center=�6m   .��6�   Score6�   �� 5      -   5        $��ScoreValueLabel��5      $��
ExtraLight"�6/   $��21(�6G   $	��111��6U   $��Center=�6a   $��Center=�6�   .��6�   1234566�   5       �� 5#      -   5        $ SettingsButton��5#      $��1q�6-   $��	645,0,0,0q�69   $��50��6L   $��0q�6W   ���	#00DDDDDD.��5$      �� .+�5%      �� $#��Icons/Settings32IconBlack.png��6   $
��None=�6C   �� 5&      $��
ExtraLight"�6    $��10(�68   $��Center=�6F   
Settings6m   5'      5(      5*      � 5,   
   $��825,50,0,50q�6   $��Stretch=�6$   $��1��6@   ��5-      ��  �� Path$ ActualHeight� �� RelativeSource �� *FindAncestor+ �� AncestorType" � � RowDefinitions 50      �� 51      $
��Auto �6    �� 52      $��* �6    .+�55      �� -   5        $  rightInfoStackPanel��55      .+�56      �� -   5         ��Name$ objectiveFunctionCanvas��56      $	��140��6:   ��57      �� 58       �� ImageSource$! objectiveFunctionSample.JPG��6%   	 j� Stretch$	 Uniform=�6O   5:      �� 5<      -	   5        $��
LayoutList��5<      $��2,2,2,2q�6/   .+�5=      � .+�5>      �� $��Layouts��6    $��18(�62   ���	#FFEFF08E$��Center=�6W   $��Center=�6{   5?      � 5@      .+�5A      �� $��Layout1 (5554332)��6!   
�������$��2,2,2,2q�6O   5B      � 5C      .+�5D      �� $��Layout2 (5324389)��6!   
�������$��2,2,2,2q�6O   5E      5F      5G      5H      ]� 5I   
   -
   5        
 ]�Name$
 bottomStackPanel��5I      ���	#3F195761$��Bottom=�5K      $��2��5L      ��.  $��50��5M      .+�5N      �� .��6   Lenght6   �� 5O      -   5        $��LengthValueLabel��5O      6.   �� 5P      .��6   Width6   �� 5Q      -   5        $��WidthValueLabel��5Q      6-   �� 5R      .��6   Top6   �� 5S      -   5        $��TopValueLabel��5S      6+   �� 5T      .��6   Left6   �� 5U      -   5        $��LeftValueLabel��5U      6,   5W      � 5X   
   -   5        $
��Body��5X      $��0,50,175,50q�6   .+�5Z      �� -   5        $ 
mainCanvas��5Z      $��Stretch=�6)   $��Stretch=�5[      
�������63   5\      5^      5_      