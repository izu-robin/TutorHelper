   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Lessons   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  %  TutorHelper.ViewModel.LessonsVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgLessons.png�� j� Stretch$
 Fill=��� $��20(�
�������$
��Left=�$	��254��$��30��$��15,45,0,495q�$
��Bold"����� *TableStatus+ �� Mode$ TwoWay=�� $��15,54,15,15q�.+�d� -    d�Name$ DataToggleBtn��$
��Left=�$	��Top=�$	��281��$��30��$N��HПрошедшие/предстоящие занятия за месяц��$��
281,-9,0,0q����� *LoadDataToggleCommand+����  �� 
TargetType" d�.���  �� Property � �� �� Value �� 	 �� 
TargetType"	 d�.R��� #��z��#��z��#��z��._��� $��Center=�$��Center=���  � �� �#549DC2
 �� Triggers
 P�  P� Property �@d�	IsChecked P� Value$
 TrueY�. ���  � ��$C =Вернуться к предстоящим занятиям����  � �� �#80ABD8� $��200  ��$	��Top=�.+��� $��
0,32,0,-32q����� *FutureLessonsList+ �� SelectedItem �� *SelectedLesson+ �� View �� .P��� $��№ группы�� �� Width$ 70�� �� DisplayMemberBinding �� *	GroupID+�� $��Дата��$ 80�� �� *Date+�� $��
Время��$ 80�� �� *Time+�� $��Детали��$	 200�� �� *Notes+�� $��Длит. (мин.)��$	 105�� �� *
Duration+�  � ColumnDefinitions �� $��* ��� $��* ��� $��2* �.+��� $��0��$	��200��$	��125��$
��Left=�$��Bottom=� �� Padding$ 10q����#A5CCE4$��2q�$��5,0,0,50q�._��� .+��� $��ID занятия:��
��������� $��3��$��0,0,0,10q�${�False���� $��ID группы:��
��������� $��6��$��0,0,0,10q��� $��Длительность:��
��������� $��60��$��0,0,0,10q��� $��1��$	��200��$	��130��$
��Left=�$��Bottom=�$ 10q����#A5CCE4$��2q�$��0,0,0,50q�._��� .+��� $��Время:��
��������� $
��0:00��$��0,0,0,10q��� $��	Дата:��
��������� $��
2025/12/31��$��0,0,0,10q��� $��Заметки:��
��������� $��60��$��0,0,0,10q� �� TextWrapping$
 Wrap=�$��40���� $��2��$	��199��$	��268��$��Center=�$	��Top=�$ 10q����#A5CCE4$��2q�$��	0,252,0,0q�._��� .+��� $��Присутствие: ��
��������� $	��150�� �� .P��� $��Ученик��$	 110���� $��Присутст.��$ 70���� $��Оплачено��$ 60���� $+��%Сохранить изменения��$
��10,5q�$��30��$	��268�����#A5CCE4$	��Top=�$
��Left=�$��	3,467,0,0q�$��2���� $#��Удалить занятие��$
��10,5q�$��30��$	��268�����#A5CCE4$��2��$	��Top=�$
��Left=�$��	5,467,0,0q�