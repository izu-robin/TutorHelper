   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Home   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  "   TutorHelper.ViewModel.HomeVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0��$��2��._��� $��/Images/imgView.png��$
��Fill=��� -   $��DateTextBlock��$��20(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"�$��2������ *	DateToday+� $��
15,40,15,5q�.+�&   System.Windows.Controls.Calendar  -   $��HomeViewCalendar��$
��Left=�$��
374,17,0,0q�$	��Top=�   IsTodayHighlighted$
 True��   SelectedDate �� *SelectedDate+ �� Mode$ TwoWay=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFA3AEB9��� $ 	#FF8399A9�� � Offset$ 0.375Q�� $ 	#FF718597��$ 0.375Q�� $ White��$ 1Q�� $	��165��$	��350��$	��Top=�$��0,20,0,0q�$	��350��$	��162��$��2��$
��Left=�.+��� -   $��DatesLessonsTable��	 �� SelectionMode$	 Single=�$��Center=�$	��350������ *DatesLessonsList+
 �� SelectedItem
 �� *SelectedLesson+ �� View �� .P��� $��
Время�� �� Width$ 60�� �� TextAlignment$ Center=� �� DisplayMemberBinding �� *Time+�� $��Ученик��$	 200�� �� *StudentFullName+�� $��Длительность��$ 85�� �� *
Duration+�  � RowDefinitions �� $��2* ��� $��3* �.+���  �� Orientation$ 
Horizontal=�$��1��.+��� $��5,5,0,5q�$	��342��$
��Left=�.+��� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Ученик: ��$��14(�
�������$
��Wrap=�$	��102��$
��Bold"�$��	0,0,20,10q�$
��Left=�$	��Top=��� $	��202��$	��Top=�
�������$��14(�$��31��$
��Wrap=����� * SelectedLesson.StudentFullName+�� $ 
Horizontal=�.+��� $��Время:��$��14(�
�������$
��Wrap=�$	��102��$
��Bold"�$��	0,0,20,10q�$
��Left=�$��Center=��� $	��130��$��20��$	��Top=�
�������$��14(����� *SelectedLesson.Time+�� $ 
Horizontal=�$��0,0,0,0q�.+��� $��	Дата:��$��14(�
�������$
��Wrap=�$	��102��$
��Bold"�$��	0,0,20,10q�$
��Left=�$	��Top=��� $	��130��$��20��$	��Top=�
�������$��14(����� *SelectedLesson.Date+�� $ 
Horizontal=�$��0,0,0,0q�.+��� $(��"Длительность (мин):��$��14(�
�������$
��Wrap=�$	��102��$
��Bold"�$��	0,0,20,10q�$
��Left=�$	��Top=��� $	��130��$��20��$	��Top=�
�������$��14(����� *SelectedLesson.Duration+�� $ 
Horizontal=�$��0,0,0,0q�.+��� $��Заметки:��$��14(�
�������$
��Wrap=�$	��102��$
��Bold"�$��	0,0,20,10q�$
��Left=�$	��Top=��� $	��202��$	��Top=�
�������$��14(�$	��100��$
��Wrap=����� *SelectedLesson.Notes+�� $��	25,0,0,50q����#A5CCE4$��2q�$	��180��$	��265��$	��Top=�._��� .+��� $&�� Добавить занятие:��
�������$
��Wrap=�$	��180��$
��Bold"�$��5q��� $��Дата��
�������$	��180��$��5q��� $	��160��$��20��$��0q����� *NewLesson.Date+$ TwoWay=��� $��
Время��
�������$	��180��$��5q��� $��0q�$	��160��$��20������ *NewLesson.Time+$ TwoWay=��� $��Ученик��
�������$��5q���  �� DisplayMemberPath$ FullName�� �� SelectedValuePath$ Id��$	��160��$��20������ *StudentsList+
 �� *SelectedStudent+�� $ ��Длительность: ��
�������$��5q��� $��0q�$	��160��$��20������ *NewLesson.Duration+$ TwoWay=��� -    ��Name$ SaveNewLesson��$+��%Сохранить изменения��$��0,15,0,0q�$	��160��$��25�����#A5CCE4���� *SaveNewLessonCommand+