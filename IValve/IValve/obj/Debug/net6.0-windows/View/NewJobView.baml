   M S B A M L   `   `   `  ����A  =IValve, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:IValve.ViewIValve.View  5   	       IValve.View.NewJobView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:IValve.View     5   	   A =Stylet, Version=1.3.6.0, Culture=neutral, PublicKeyToken=null)s!https://github.com/canton7/Stylet  5   	     � Icon$.  (C:\dev\c#\IValve\IValve\IValve\valve.png��5       � Title$ IValve��5
   	    � 
ResizeMode$ NoResize=�5   	   $	��600��5      $	��800��6'    � 	Resources 5      &   System.Windows.Controls.DataGrid �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Padding	 �� Triggers
 P� Property P� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell � ColumnDefinitions J� Opacity(  "System.Windows.Controls.DatePicker:  4System.Windows.Controls.Primitives.DatePickerTextBox   ComboBoxToggleButton ��Name �� CornerRadius F�Name  ComboBoxTextBox �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible �� SelectionBoxItem �� SelectionBoxItemTemplate ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth  �� MaxDropDownHeight! K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation"   DirectionalNavigation# �� Triggers$ �� 
TargetName% P� 
SourceName��%�  '        '  �     '  �    '  �    '�� ,    '�� �    '�� '    '  �	    '  �	    &	  1    &	 =    '�� �    7   7  �� 5   
   "  6   .�5      ��  � �� �#27241D6+   �� 5       � �� �#FAF9F76+   �� 5        �@ AlternatingRowBackground �#423D3369   �� 5       � ��$ 0q�60   5      �� 5   
   "  6   .�5      ��  � �� 5      �� 5      "  6&   .R�5      �� ���#423D33$��0q�66   ._�5      �� #��z��6(   $	 0,5q�6I   $��20(�6W   $��Center=�6e   $��Center=�6�   5      5      5      	 5      P� 5      
 �@ SortDirection 	Ascending63   . �5       ��  � ��$ Medium"�63   5!      P� 5"      
 �@ SortDirection 
Descending63   . �5#      ��  � ��$ Medium"�63   5$      5&      �� 5'   
   "  6   .�5(      ��  � �� �#423D336+   �� 5)       � �� �#FAF9F76+   �� 5*       � ��$ 18(�6)   �� 5+       � ��$ 0q�60   	 5,      P� 5-      
 �@J�IsMouseOver$
 True��61   . �5.      ��  � �� �#504A4063   5/      51      �� 52   
   "  6   .�53      ��  � �� �#423D336+   �� 54       � ��$ 0q�60   �� 55       � ��
 �  ��6,   	 56      P� 58      
 �@ 
IsSelected$
 True��60   . �59      ��  � �� �#504A4063   �� 5:       � ��
 �   �64   5;      5=      �� 5>   
   " ��6   .�5?      ��  � �� �#4242426>   �� 5@       � �� �#FAF9F76=   �� 5A       � �� 5B      �� 5C      " ��6&   .R�5D      �  5E      �� 5F   "   $��* �63   .+�5H      �� #��z��6%   $	 0.5Q�6O   $��0��6]   ���#857F72$	��1,0q�6�   ._�5I   "   �� #��z��6(   $��24(�6L   $��Normal$�6Z   $��Verdana)�6m   $��Center=�6�   $��Center=�6�   #��z��6�   5J      5K      5L      5N      	 5O      P� 5P      
 �@J�IsMouseOver$
 True��61   . �5Q      ��  � �� �#504A4063   �� 5R       �@�Cursor$
 Hand��6/   5S      5U      �� 5V   
   " ��6   .�5W      ��  � �� �#B8B2A76+   �� 5X       � ��$ 32(�6)   5Y      �� 5Z   
   " ��6   .�5[      ��  � �� �#504A406+   �� 5\       � ��
 �   �6,   �� 5]       � ��$ 26(�6)   �� 5^       � ��$ 0,0,40,0q�6'   �� 5_       � �� �#FAF9F76+   	 5`      P� 5a      
 �@J�	IsFocused$
 True��6/   . �5b      ��  � �� �#42424263   5c      5e      �� 5f   
   "  6   .�5g      ��  � ��$ 0q�60   �� 5h       � �� �#FAF9F76+   5i      �� 5j   
   "  6   .�5k      ��  � �� �#504A406+   �� 5l       � ��
 �   �6,   �� 5m       � ��$ 26(�6)   �� 5n       � ��$ Select a date��6%   	 5o      P� 5p      
 �@J�	IsFocused$
 True��6/   . �5q      ��  � �� �#42424263   5r      5t      �� 5u   
   " d�67   .R�5v      �  5w      �� 5x      �� 5y      $��20 �6'   .+�5{      �� $ Border��5|      $��2��5}      $ 0��5~      ���#504A40���#000$��1q�5�      �� 5�      $��0��5�      $ 0��5�      $��1q�5�      ���#504A40���#000$��0,0,1,0q�5�      F� 5�      $ Arrow��5�      $��1��5�      
�������$��Center=�5�      $��Center=�5�      =����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	5�      5�      5�      �� 5�   
   " ��62   .R�5�      �� $ PART_ContentHost��6   $|�False��6/   #��z��6A   5�      �� 5�   
   " ��6*   .�5�      ��  �@J�SnapsToDevicePixels$
 true��64   �� 5�       � ��$ 26(�6)   �� 5�       � ��$ 0,0,40,0q�6'   �� 5�       �@�OverridesDefaultStyle$
 true��66   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � ��$
 true��6>   �� 5�       � ��$	 120��6)   �� 5�       � ��$ 20��6*   �� 5�       � ��
 �����6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      � .+�5�      d� $��ToggleButton��5�      8��  $��2��5�      $|�false��5�      $ Press=�5�       5�      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5�      �� 5�      $��ContentSite��6/   $ False��6B   #��z 6\   #��z 5�      #��z��5�      $��3,3,23,3q�5�      $��Center=�5�      $
��Left=�5�      �� 5�      $ PART_EditableTextBox��6&   8�� $
��Left=�5�      $��Center=�5�      $��3,3,23,3q�5�      $��26(�5�      $
|�True��5�      ���#504A40
��� � �$y�Hidden=�5�      # z 5�      ��5�      Z� 5�      � 5�      $��Popup��5�      $��Bottom=�5�      #��z 5�      $
 True��5�      $|�False��5�      $��Slide=�5�      .��5�   "   � $��DropDown��6'   $
 True��5�      #��z 5�      #��z  5�      .+�5�   &   �� $ DropDownBorder��5�   !   ���#504A40$��1q�5�   !   ���#8888885�   !   �� 5�   &   $��4,6,4,6q�63   $
 True��6D   .��5�   *   �� $
! True��65   $" 	Contained=�6H   5�   '   5�   #   5�      5�      # 5�      P� 5�      
 �@��HasItems$ false��6:   . �5�   "   �� $$ DropDownBorder��6)    � ��$ 95��6Z   5�      P� 5�      
 � {�$ false��6;   . �5�   "   ��  � �� �#8888886?   5�      P� 5�      
 �@��
IsGrouping$
 true��6<   . �5�   "   ��  � ��$ false��6R   5�      P� 5�      $% Popup��6&   
 �@�AllowsTransparency$
 true��6]   . �5�   "   �� $$ DropDownBorder��6)    �@��CornerRadius$ 0��6]   �� 5�   "   $$ DropDownBorder��6)    � ��$ 0,2,0,0q�6W   5�      P� 5�      
 �@��
IsEditable$
 true��6=   . �5�   "   ��  � ��$ false��6>   �� 5�   "   $$ PART_EditableTextBox��6)    � y�$ Visible=�6a   �� 5�   "   $$ ContentSite��6)    � y�$ Hidden=�6X   5�      5�      5�      5�      5�      .��5�      � ���#121212 5�   
   �� 5�      $��* �6   �� 5�      $��* �6   & � RowDefinitions& 5�   
   �� 5�      $��* �6   �� 5�      $��* �6   �� 5�      $��* �6   �� 5�      $��* �6   �� 5�      $��2* �6   .+�5  
   �� $��2��6   $��New Job��6(   $��Center=�5     $��Center=�5     $��56(�5     ���#FAF9F7$��Medium"�5     �� 5  
   $��1��6   .+�5     �� $��Title��6   �� 5
     ��6   �� *NewJob.Name+$ TwoWay=�5     �� 5  
   $��1��6   $��1��5     .+�5     �� $��Deadline��6     5     '   Text' 6   �� *NewJob.Deadline+$ TwoWay=�5     �� 5  
   $��2��6   $��2��6"   .+�5     �� $��Description��6   �� 5     $��0q�6   ��6!   �� *NewJob.Description+$ TwoWay=�5     �� 5  
   $��3��6   $��0��5     .+�5     �� $
��Type��6   �� 5     ��6   �� *	JobType+( �� SelectedItem( 68   �� *NewJob.Type+$ TwoWay=���5     �� 5     .R�5     �� ��6$   �� *Name+5     5      5!     �� 5"  
   $��3��6   $��1��5#     .+�5$     �� $��Person��6   � 5&      5'     �� 5(     $��8* �6'   �� 5)     $��1* �6'   .+�5+     �� $��0q�6   ��6'   �� *AvaliablePersons+( 6P   �� *SelectedPerson+$ TwoWay=���5,     �� 5-     .R�5.     �� ��5/  "   `� 50  &   ) �� StringFormat$) {0} {1}��63   .1�51  *   �� $ 	Firstname�62   �� 52  *   $ Lastname�62   53  '   55     56     58     �� 59     $��+��6   $��2��6D   ��6%   !  Stylet.Xaml.ActionExtension  *	AddPerson+6D   5:     5;       5<  
   *   AutoGenerateColumns$* False��5=     +   CanUserAddRows$+ False��5>     ,   
IsReadOnly$
, True��5?     $��	0,5,2.5,0q�5@     -   CanUserSortColumns$- False��5A     $��0��5B     $��4��6#   ��5<     �� *SelectedPersons+.   RowHeaderStyle. 5C     �� 5D     :	  4System.Windows.Controls.Primitives.DataGridRowHeader" 	 6   .�5E     ��  � ��$  ��60   �� 5F      � ��$ 0��6.   5G     /   Columns/ 5I     0
  *System.Windows.Controls.DataGridTextColumn
  5J     ,  &System.Windows.Controls.DataGridColumn0   Header$0 ID��6%   1   Width5  /System.Windows.Controls.DataGridLengthConverter$1 * 61   2   SortDirection2 	Ascending6Y   1  +System.Windows.Controls.DataGridBoundColumn3   Binding3 6;   �� *	Person_ID+6u   
  5K     $0 
First name��6%   $1 3* 69   2 	Ascending6b   3 6D   �� *	Firstname+6~   
  5L     $0 	Last name��6%   $1 2* 68   2 	Ascending6`   3 6C   �� *
Lastname+6|   5N     �� 5P  
   $��4��6   $��1��5Q     $��Bottom=�6%   .+�5R     �� ���#f00$��14(�6H   ${�False��6V   ��6   �� *ErrorMessage+6V   �� 5S     $	��Add��6   ��6#     *Add+�� 5T     $��Clear/Close��6   ��6+     *Clear+5U     5V     5W     