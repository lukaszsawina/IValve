   M S B A M L   `   `   `  ����A  =IValve, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:IValve.ViewIValve.View  5          IValve.View.SupplyView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:IValve.View     5      A =Stylet, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null)s!https://github.com/canton7/Stylet  5        � 	Resources  5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � �� �#B8B2A76+   �� 5       � ��$ 24(�6)   �� 5       � ��$ Center=�62   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7* �6   �� 5      $��2* �6   .+�5   
   �� $��Drinks��6   $��28(�5      $��Center=�5       $��Center=�5!      &   System.Windows.Controls.DataGrid  5"   
   $��1��5#         AutoGenerateColumns$ False��5$         CanUserAddRows$ False��5%         
IsReadOnly$
 True��5&      $��	0,0,2.5,0q�5'      	   CanUserSortColumns$	 False��5(      $��Disabled=�5)      
   SelectedCellsChanged
 5*      !  Stylet.Xaml.ActionExtension  *ChangeSelectedSupplyDrink+��5+      �� *Drinks+   RowHeaderStyle 5-      �� 5.      :  4System.Windows.Controls.Primitives.DataGridRowHeader"  6   .�5/      ��  � ��$  ��60   �� 50       � ��$ 0��6.   51         Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      FontSize$ 24Q�6;      SortDirection 	Ascending6f   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *
Drink_ID+6�     55      $
 Name��6%   $ 2* 63   $ 24Q�6>    6L   �� *Name+6g     56      $ Liters��6%   $ * 65   $ 24Q�6?    6M   �� *Amount+6j     57      $
 Type��6%   $ 2* 63   $ 24Q�6>    6L   �� *	Type.Name+6l   59      �� 5;   
   $
��Food��6   $��1��5<      $��28(�5=      $��Center=�5>      $��Center=�5?        5@   
   $��1��6   $��1��5A      $ False��5C      $ False��5D      $
 True��5E      $��2.5,0q�5F      $	 False��5G      $��Disabled=�5H      
 5I        *ChangeSelectedSupplyFood+��5J      �� *Food+ 5L      �� 5M      "  6   .�5N      ��  � ��$  ��60   �� 5O       � ��$ 0��6.   5P       5R        5S      $ ID��6%   $ * 61   $ 24Q�6;    	Ascending6e    6I   �� *	Food_ID+6�     5T      $
 Name��6%   $ 2* 63   $ 24Q�6>    6L   �� *Name+6g     5U      $ Amount��6%   $ * 65   $ 24Q�6?    6M   �� *Amount+6j     5V      $
 Type��6%   $ 2* 63   $ 24Q�6>    6L   �� *	Type.Name+6l   5X      �� 5Z   
   $��Items��6   $��2��5[      $��28(�5\      $��Center=�5]      $��Center=�5^        5_   
   $��2��6   $��1��5`      $ False��5b      $ False��5c      $
 True��5d      $��	2.5,0,0,0q�5e      $	 False��5f      $��Disabled=�5g      
 5h        *ChangeSelectedSupplyItem+��5i      �� *Items+ 5k      �� 5l      "  6   .�5m      ��  � ��$  ��60   �� 5n       � ��$ 0��6.   5o       5q        5r      $ ID��6%   $ * 61   $ 24Q�6;    	Ascending6e    6I   �� *	Item_ID+6�     5s      $
 Name��6%   $ 2* 63   $ 24Q�6>    6L   �� *Name+6g     5t      $	 PCS��6%   $ * 62   $ 24Q�6<    6J   �� *Amount+6g     5u      $
 Type��6%   $ 2* 63   $ 24Q�6>    6L   �� *	Type.Name+6l   5w      �� 5x   
   $��0��6   $��2��5y      $��Add new��5z      ��5{        *ShowNewSupplyWindow+�� 5}   
   $��1��6   $��2��5~      $��	Statistic��5      ��5�        *ShowStatisticWindow+� 5�   
   $��2��6   $��2��6    5�      �� 5�      $��* �6#   �� 5�      $��2* �6#   �� 5�      $��* �6#    5�      �� 5�      $��* �6    �� 5�      $��* �6    �� 5�      $��* �6    .+�5�      �� $��0��6   $��3��5�      $��-��5�      $��	ExtraBold"�5�      ��5�        *
Decrease+�� 5�      $��1��5�      $��Bottom=�5�      $��NoWrap=�5�      $��CharacterEllipsis=�6*   $��Center=�5�      �� 5�      $�Name:��6    �� 5�      �6   �� *Selected.Name+5�      �� 5�      $��1��6   $	��Top=�5�      $��Center=�5�      $��1��5�      ��5�      �� *Selected.Amount+5�      �� 5�      $��1��6   $��2��5�      $��Confirm��5�      ��5�        *	Confirm+�� 5�      $��2��6   $��3��5�      $��+��5�      $��	ExtraBold"�5�      ��5�        *
Increase+5�      5�      5�      