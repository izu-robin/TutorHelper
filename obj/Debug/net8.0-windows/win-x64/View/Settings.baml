   M S B A M L   `   `   `  ����F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel  5          TutorHelper.View.Settings   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2vm#clr-namespace:TutorHelper.ViewModel     5         
Page_Style#��[  5
        � DataContext  5      &   TutorHelper.ViewModel.SettingsVM  5   
   .��5      � $��15q�6   .+�5   
   ��  �� CornerRadius$ 	0,20,20,0��6   ��5      �� 5       �� ImageSource$ /Images/imgSettings.png��6    j� Stretch$
 Fill=�5      5      �� 5   
   $%��Удаление данных: ��6   $��20(�5      $
��Left=�5      $	��Top=�5      $��	15,15,0,0q�5      $	��254��5      
�������$
��Bold"�5       � 5#   
   $��15,54,15,15q�6   .+�5%      � $
��0,20q�6    � RowDefinitions 5&      �� 5'      $��3* �6$   �� 5(      $��3* �6$   �� 5)      $��2* �6$   �� 5*      $��2* �6$   �� 5+      $��2* �6$   .+�5/      �� $��0��6   .+�51      �� $'��!Удаление ученика: ��6    $��16(�52      $
��Left=�53      $	��Top=�54      $��	15,15,0,0q�55      $	��254��56      
�������$
��Bold"�58      �� 5;       �� Orientation$ 
Horizontal=�6!   .+�5<      �� $	��200��6#   $
��Left=�5=      $��	15,15,0,0q�5>      �� 5@      $7��1Удалить вместе с занятиями��6#   $��	15,18,0,0q�5A   #   
�������$��14(�5C   #   5D      �� 5F      $ 
Horizontal=�6!   .+�5G      �� $��Удалить��6!   ���#A5CCE4$	��200��5I      $��	15,18,0,0q�5J      $
��Left=�5K      �� 5M      $p��j(повлияет на финансовый отчет, если он еще не сформирован) ��6    $��14(�5N   $   $
��Left=�5O   $   $	��Top=�5P   $   $��50,0,0,0q�5Q   $   $	��254��5R   $   ���#A5CCE4$
��Wrap=�5T   $   5U      5W      �� 5Y      $��1��6   .+�5\      �� $%��Удаление отчета: ��6    $��16(�5]   !   $
��Left=�5^   !   $	��Top=�5_   !   $��	15,15,0,0q�5`   $   $	��254��5a   $   
�������$
��Bold"�5c   $   �� 5e      $ 
Horizontal=�6!   .+�5f      �� .+�5g      �� $	��200��6#   $
��Left=�5h   #   $��	15,15,0,0q�5i   #   �� 5m      $��Удалить��6!   ���#A5CCE4$	��200��5o   !   $��	15,18,0,0q�5p   !   $
��Left=�5q   !   5u      �� 5w      $j��dВ случае удаления отчет может быть сформирован заново ��6$   $��14(�5x   $   $
��Left=�5y   $   $	��Top=�5z   $   $��	50,10,0,0q�5{   $   $	��254��5|   $   ���#A5CCE4$
��Wrap=�5~   $   5      5�      �� 5�      $��2��6   .+�5�      �� $'��!Удаление занятия: ��6    $��16(�5�   !   $
��Left=�5�   !   $	��Top=�5�   !   $��	15,15,0,0q�5�   !   $	��254��5�   !   
�������$
��Bold"�5�   !   �� 5�      $ 
Horizontal=�6!   .+�5�      �� $	��300��6#   $
��Left=�5�   %   $��	15,10,0,0q�5�   %   �� 5�      $��Удалить��6!   ���#A5CCE4$	��200��5�   !   $��	15,10,0,0q�5�   !   $
��Left=�5�   !   5�      5�      �� 5�      $��3��6   .+�5�      �� $%��Удаление тарифа: ��6    $��16(�5�   !   $
��Left=�5�   !   $	��Top=�5�   !   $��	15,15,0,0q�5�   !   $	��254��5�   !   
�������$
��Bold"�5�   !   �� 5�      $ 
Horizontal=�6!   .+�5�      ��  �� DisplayMemberPath$ Title��5�   #    �� SelectedValuePath$ Id��5�   #   $	��300��5�   #   $
��Left=�5�   #   $��	15,10,0,0q�5�   #   ��5�   #   �� *AllRatesList+ �� SelectedItem 5�   #   �� *SelectedRate+5�   #   �� 5�      $��Удалить��6!   ���#A5CCE4$	��200��5�   !   $��	15,10,0,0q�5�   !   $
��Left=�5�   !   ��5�   !   �� *DeleteRateCommand+5�   !   5�      5�      �� 5�      $��4��6   .+�5�      �� $��Удаление УМК: ��6    $��16(�5�   !   $
��Left=�5�   !   $	��Top=�5�   !   $��	15,15,0,0q�5�   !   $	��254��5�   !   
�������$
��Bold"�5�   !   �� 5�      $ 
Horizontal=�6!   .+�5�      �� $	��300��6#   $
��Left=�5�   %   $��	15,10,0,0q�5�   %   �� 5�      $��Удалить��6!   ���#A5CCE4$	��200��5�   !   $��	15,10,0,0q�5�   !   $
��Left=�5�   !   5�      5�      5�      5�      5     5     