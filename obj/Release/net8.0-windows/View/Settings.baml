   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Settings   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  &   TutorHelper.ViewModel.SettingsVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgSettings.png�� j� Stretch$
 Fill=��� $%��Удаление данных: ��$��20(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"�� $��15,54,15,15q�.+�� $
��0,20q� � RowDefinitions �� $��3* ��� $��2* ��� $��2* ��� $��2* ��� $��2* �.+��� $��0��.+��� $'��!Удаление ученика: ��$��16(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"���  �� Orientation$ 
Horizontal=�.+���  �� DisplayMemberPath$ FullName�� �� SelectedValuePath$ Id��$	��200��$
��Left=�$��	15,15,0,0q����� *AllStudentsList+ �� SelectedItem �� *SelectedStudent+�� $7��1Удалить вместе с занятиями��$��	15,18,0,0q�
�������$��14(�	 d� 	IsChecked	 �� *DeleteWithLessons+
 �� Mode$
 TwoWay=��� $ 
Horizontal=�.+��� $��Удалить�����#A5CCE4$	��200��$��	15,18,0,0q�$
��Left=����� *DeleteStudentCommand+�� $)��#(повлияет на отчет) ��$��14(�$
��Left=�$	��Top=�$��50,0,0,0q�$	��254�����#A5CCE4$
��Wrap=��� $��1��.+��� $'��!Удаление занятия: ��$��16(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"��� $ 
Horizontal=�.+��� $ DateAndName��$ Id��$	��300��$
��Left=�$��	15,10,0,0q����� *AllLessonsList+ �� *SelectedLesson+�� $��Удалить�����#A5CCE4$	��200��$��	15,10,0,0q�$
��Left=����� *DeleteLessonCommand+�� $��2��.+��� $%��Удаление тарифа: ��$��16(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"��� $ 
Horizontal=�.+��� $ Title��$ Id��$	��300��$
��Left=�$��	15,10,0,0q����� *AllRatesList+ �� *SelectedRate+�� $��Удалить�����#A5CCE4$	��200��$��	15,10,0,0q�$
��Left=����� *DeleteRateCommand+�� $��3��.+��� $��Удаление УМК: ��$��16(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"��� $ 
Horizontal=�.+��� $ Title��$ Id��$	��300��$
��Left=�$��	15,10,0,0q����� *AllTextbooksList+ �� *SelectedTextbook+�� $��Удалить�����#A5CCE4$	��200��$��	15,10,0,0q�$
��Left=����� *DeleteTextbookCommand+