   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Groups   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  $  TutorHelper.ViewModel.ReportVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgGroups.png�� j� Stretch$
 Fill=��� $'��!Доступные отчеты: ��$��20(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"�� $��15,54,15,15q� � RowDefinitions �� $��1* ��� $��2* �.+�� $	��155��$��0��$	��Top=�$��0,0,0,10q�.+��� .+��� $��0��$	��152��$	��562��$
��Left=�$	��Top=� �� Padding$ 5,5,0,0q����#A5CCE4$��2q�$��0,0,0,0q�$ 
0,15,20,20��._��� .+���  �� Orientation$ 
Horizontal=�.+��� $(��"Показать отчет за: ��$��16(�
�������$	��Top=�$��30��$
��Bold"���  �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id��$	��100��$��20��$	��Top=�$��7q����� *Months+	 �� SelectedItem	 �� *SelectedMonth+
 �� Mode$
 TwoWay=��� $	��100��$��20��$	��Top=�$��7q����� *Years+	 �� *SelectedYear+�� $��Найти/Создать��$	��151��$��20��$	��Top=�$��7q����#A5CCE4���� *GetReportCommand+�� $ 
Horizontal=�.+��� $��90��$	��168��$
��Left=�$	��Top=�$ 5,5,0,5q����#A5CCE4$��2q�$��4,10,5,8q�$ 0,0,0,15��._��� .+��� $)��#Проведено занятий: ��$��Center=�$��16(�
�������$	��Top=�$��30���� $��18(�
�������$	��Top=�$��Center=�$��10q����� *CurrentReport.TotalLessons+�� $��90��$	��168��$
��Left=�$	��Top=�$ 5,5,0,5q����#A5CCE4$��2q�$��
13,10,10,8q�._��� .+��� $$��Из них оплачено: ��$��Center=�$��16(�
�������$	��Top=�$��30���� $��18(�
�������$	��Top=�$��Center=�$��10q����� *CurrentReport.PaidLessons+�� $��90��$	��169��$
��Left=�$	��Top=�$ 5,5,0,5q����#A5CCE4$��2q�$��	6,10,10,8q�$ 0,0,15,0��._��� .+��� $��Общая сумма: ��$��Center=�$��16(�
�������$	��Top=�$��30���� $��18(�
�������$	��Top=�$��Center=�$��10q����� *CurrentReport.TotalSum+� $��1��.+�,� $	��288��$	��Top=�$ ,� HorizontalScrollBarVisibility$ Disabled=�" ,� VerticalScrollBarVisibility$ Visible=�$
��Left=�$��0q�$	��700��.��/� -    �Name$ 	docReport�� /� MinPageWidth$	 700�� /� 	PageWidth$	 550��.T��� .r��� .+��� -   $
��hehe��$	��700��$	��Top=�$	��514��$��Center=����� *LessonsList+ �� View �� .P��� $��Дата�� �� Width$ 80�� �� DisplayMemberBinding �� *Date+�� $��
Время��$ 60�� �� *Time+�� $��Ученик��$	 190�� �� *StudentFullName+�� $��	Длит.��$ 80�� �� *
Duration+�� $��Оплачено��$ 85�� �� *
SignPaid+�� $ 
Horizontal=�$��3,0,0,0q�.+��� $��90��$	��165��$
��Left=�$	��Top=�$	 0,5q����#A5CCE4$��2q�$��5,10,5,8q�$ 0,0,0,15��._��� .+��� $)��#Проведено занятий: ��$��Center=�$��16(�
���   �$	��Top=�$��30���� $��18(�
���   �$	��Top=�$��Center=�$��10q����� *CurrentReport.TotalLessons+�� $��90��$	��148��$
��Left=�$	��Top=�$	 0,5q����#A5CCE4$��2q�$��
13,10,10,8q�._��� .+��� $$��Из них оплачено: ��$��Center=�$��16(�
���   �$	��Top=�$��30���� $��18(�
���   �$	��Top=�$��Center=�$��10q����� *CurrentReport.PaidLessons+�� $��90��$	��148��$
��Left=�$	��Top=�$	 0,5q����#A5CCE4$��2q�$��	8,10,10,8q�$ 0,0,15,0��._��� .+��� $��Общая сумма: ��$��Center=�$��16(�
���   �$	��Top=�$��30���� $��18(�
���   �$	��Top=�$��Center=�$��10q����� *CurrentReport.TotalSum+�� $ 
Horizontal=�$��Center=�.+��� $��Отчет  за��$��18(�
���   �$��
10,10,5,10q�$	��Top=��� $��18(�
���   �$��0,15,5,0q�$	��Top=����� *SelectedMonth.Name+�� $��18(�
���   �$��5,15,0,0q�$	��Top=����� *SelectedYear+�� -   $A��;Распечатать/сохранить отчет в PDF�����#A5CCE4$	��Top=�$��131,304,131,0q�$	��300��$��25��