   M S B A M L   `   `   `  ����A  =IValve, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:IValve.ViewIValve.View  5          IValve.View.RoomView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:IValve.View     5      A =Stylet, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null)s!https://github.com/canton7/Stylet  5        � 	Resources  5
       �� 
TargetType �� Property �� Value   MyCheckBoxStyle �� 
TargetType ��Name �� Padding ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName��%  '��       &	  �     �� 5   
   " ��6   .�5      ��  � �� �#B8B2A76+   �� 5       � ��$ 24(�6)   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6(   .�5      ��  � ��$ 25��6&   �� 5       � ��$ 25��6'   �� 5       � ��$ 0,0,10,0q�6'   �� 5       � �� �#4242426+   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ Border��6%   #��z��65   #��z��6_   #��z��6�   # z��6�   ._�5   "   � .+�5   &   �� $ 	CheckMark��60   $y�	Collapsed=�6C   $��X��6Z   $��18(�6c   $��	ExtraBold"�6q   
���   �$��Center=�6�   $��Center=�6�   5   #   5      �� 5      $
��Left=�6/   $��50,0,0,0q�6J   $��Center=�6\   $
��True��6w   5       5       P� 5!      	 �@d�	IsChecked$

 TrueY�6;   . �5"   "   �� $ 	CheckMark��6)    � y�$ Visible=�6V   5#      P� 5$      	 �@J�IsMouseOver$

 True��6=   . �5%   "   �� $ Border��6)    � �� �#504A406S   5&      P� 5'      	 � {�$
 False��6;   . �5(   "   �� $ Border��6)    � ��
 �����6S   �� 5)   "   $ Border��6)    � ��
 �����6T   �� 5*   "    � ��
 �����6?   5+      5-      5/      50      51      .��52      �  � ColumnDefinitions 53   
   �� 54      $��6* �6   �� 55      $��4* �6    � RowDefinitions 57   
   �� 58      $��2* �6   �� 59      $��3* �6   .+�5;   
   &   System.Windows.Controls.DataGrid  $��2��6      AutoGenerateColumns$ False��5<         CanUserAddRows$ False��5=         
IsReadOnly$
 True��5>      $��0,0,5,0q�5?         CanUserSortColumns$ False��5@      $��Disabled=�5A         SelectedCellsChanged 5B      !  Stylet.Xaml.ActionExtension  *ChangeSelectedPerson+��5C      �� *Rooms+   RowHeaderStyle 5E      �� 5F      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5G      ��  � ��$  ��60   �� 5H       � ��$ 0��6.   5I         Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Room number��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6:      FontSize$ 24Q�6D      SortDirection 	Ascending6n   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *	Room_ID+6�     5M      $ Section��6%   $ 2* 66   $ 24Q�6A    6O   �� *Section.Name+6r     5N      $ Capacity��6%   $ 2* 67   $ 24Q�6B    6P   �� *FullCapacity+6s   5P      � 5R   
   $��1��6    5S      �� 5T      $��3* �6#   �� 5U      $��* �6#    5W      �� 5X      $��* �6    �� 5Y      $��* �6    �� 5Z      $��* �6    �� 5[      $��* �6    .+�5]      �� $��
Statistics��6   $��0��5^      $��48(�5_      �� 5`       �� Orientation$ 
Horizontal=�6   $��1��62   .+�5a      �� $��1��6   $��Center=�5c      $
��Left=�5d      #��[  5e       d� Checked 5b        *HandleChecked+ d� 	Unchecked 5f        *HandleUnchecked+�� 5g      $��	Hide full��6   $��Center=�6-   5h      �� 5j      $��Number of rooms:��6   $��0��5k      $��1��5l      �� 5m      $��1��6   $��1��5n      ��5o      �� *CountOfRooms+�� 5p      $#��Percentage of occupied rooms:��6   $��0��5q      $��2��5r      �� 5s      $��2��6   $��1��5t      ��5u      �� *PercentOfOccupied+ �� StringFormat$ {0:F1} %���� 5w      $��Available rooms:��6   $��0��5x      $��3��5y      �� 5z      $��3��6   $��1��5{      ��5|      �� *CountOfAvaliable+5}        5   
   $��2��6   $��1��5�      $ False��5�      $ False��5�      $
 True��5�      $ False��5�      $��Disabled=�5�      ��5�      �� *PersonInRoom+ 5�      �� 5�      "  6   .�5�      ��  � ��$  ��60   �� 5�       � ��$ 0��6.   5�       5�        5�      $ 	Person ID��6%   $ * 68    	Ascending6`    6B   �� *	Person_ID+6|     5�      $ 
First name��6%   $ 2* 69    6D   �� *	Firstname+6d     5�      $ 	Last name��6%   $ 2* 68    6C   �� *
Lastname+6b   5�      5�      5�      