   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Students   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  &   TutorHelper.ViewModel.StudentsVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgStudents.png�� j� Stretch$
 Fill=�� $��0��.+��� $��Все ученики: ��$��20(�$
��Left=�$	��Top=�$��	15,20,0,0q�$	��254��
�������$
��Bold"�� $��15,54,15,15q�.+�� $	��200��$	��Top=�.+���  �� Orientation$ 
Horizontal=�.+���  �� SelectionMode$ Single=����� *StudentsList+ �� SelectedItem �� *SelectedStudent+ �� View �� .P��� $��Фамилия�� �� Width$	 180��	 �� DisplayMemberBinding	 �� *
FullName+�� $��УМК��$	 145��	 �� *TextbookTitle+�� $	��200��$	��206��$��21,0,0,0q�$��Right=�$	��Top=����#A5CCE4$��2q�
 �� Padding$
 10q�._��� .+��� $&�� Добавить ученика:��
�������$
��Wrap=�$	��180��$
��Bold"�$��0,0,0,0q��� $��Имя��
�������$	��180��$��4q��� $��Имя��$��0q��� $��Фамилия��
�������$	��180��$��4q��� $��Фамилия��$��0q��� $��
Тариф��
�������$��4q��� $	��180��$��20���� -    ��Name$ SaveNewStudent��$+��%Сохранить изменения��$��0,10,0,0q����#A5CCE4� $��0,220,0,187q�$	��335��$
��Left=�.+��� $��Center=�$��Center=�$��95��$	��335�����#A5CCE4$��2q�$
 10q�._��� $6��0Найти все занятия ученика:��
�������$
��Wrap=�$	��180��$
��Bold"�$��0,0,0,10q�$
��Left=��� $ 
Horizontal=�.+��� $��Оплаченные��$
��Left=�$��Center=�$��10,0,0,0q�
�������$��12(��� $��Оплаченные��$
��Left=�$��Center=�$��10,0,0,0q�
�������$��12(��� $��Посещенные��$
��Left=�$��Center=�$��10,0,0,0q�
�������$��12(��� $��
Найти��$��20��$��10,60,10,10q����#A5CCE4� $��
 0,330,0,0q� � ColumnDefinitions �� $��3* ��� $��2* �.+��� -    ��Name$ StudentsLessonsView��$ Single=����� *	Lessons+ �� .P��� $��
ID зан.��$ 42��	 �� *Id+�� $��Дата��$ 47��	 �� *Id+�� $��
Время��$ 47��	 �� *Id+�� $��Группа��$ 50��	 �� *Id+�� $��Присутствие��$ 75��	 �� *Id+�� $��Оплачено��$ 70��	 �� *Id+�� $	��281��$	��205��$��Right=�$��Bottom=����#A5CCE4$��2q�$
 10q�._��� .+��� .+��� $0��*Редактировать ученика:��
�������$
��Wrap=�$	��180��$
��Bold"�$��0,0,0,5q��� $��Имя��
�������$	��180��$	��5,8q��� $��0q����� *CurrentEditableStudent.Name+ �� Mode$ TwoWay=��� $��Фамилия��
�������$	��180��$	��5,8q��� $��0q����� * CurrentEditableStudent.Surname+�� $��
Тариф��$
��Wrap=�
�������$	��180��$	��5,8q���  �� DisplayMemberPath$ Title�� �� SelectedValuePath$ Id��$��20������ *	RatesList+ �� *SelectedRating+�� $+��%Сохранить изменения��$��0,15,0,0q����#A5CCE4���� *SaveEditedStudent+