   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel       TutorHelper.View.Textbooks   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  '  !TutorHelper.ViewModel.TextbooksVM  .��� .+�� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgSettings.png�� j� Stretch$
 Fill=��� $'��!Используемые УМК: ��$��20(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"�� $��15,54,15,15q� � RowDefinitions �� $��3* ��� $��4* �.+�� $	��200��$��0��$	��Top=�$��0,0,0,10q�.+���  �� SelectionMode$ Single=����� *TextbooksList+ �� SelectedItem �� *SelectedTextbook+ �� View �� .P��� $��ID�� �� Width$ 90��	 �� DisplayMemberBinding	 �� *Id+�� $��Название УМК��$	 230��	 �� *Title+�� $��Уровень��$	 230��	 �� *Level+� $��1��$	��Top=�$��0q�$	��160��.+��� 
 �� Orientation$
 
Horizontal=�.+���  �� Padding$ 5q����#A5CCE4$��2q�$	��277��._��� $	��270��.+��� $(��"Редактировать УМК:��
�������$
��Wrap=�$	��281��$
��Bold"�$
��Left=�$��0,0,0,10q��� $
 
Horizontal=�.+��� $��Название: ��
�������$
��Wrap=�$��84��$
��Bold"�$��Center=�$��0,8,0,10q��� $��0q�$��20��$	��171������ *CurrentEditableTextbook.Title+ �� Mode$ TwoWay=��� $
 
Horizontal=�.+��� $��Уровень: ��
�������$
��Wrap=�$��85��$
��Bold"�$��Center=�$��0,8,0,10q��� $��0q�$��20��$	��171������ *CurrentEditableTextbook.Level+$ TwoWay=��� -    ��Name$ SaveRedactedTextbook��$>��8Сохранить редактированный УМК��$	��258��$��20��$��0,15,0,0q�$
��Left=����#A5CCE4���� *SaveEditedTextbookCommand+�� $ 5q����#A5CCE4$��2q�$	��275��$��10,0,0,0q�._��� $	��270��.+��� $��Добавить УМК:��
�������$
��Wrap=�$	��281��$
��Bold"�$
��Left=�$��0,0,0,10q��� $
 
Horizontal=�.+��� $��Название: ��
�������$
��Wrap=�$��84��$
��Bold"�$��Center=�$��0,8,0,10q��� $��0q�$��20��$	��171������ *NewTextbook.Title+$ TwoWay=��� $
 
Horizontal=�.+��� $��Уровень: ��
�������$
��Wrap=�$��85��$
��Bold"�$��Center=�$��0,8,0,10q��� $��0q�$��20��$	��171������ *NewTextbook.Level+$ TwoWay=��� -   $ SaveNewTextbook��$*��$Сохранить новый УМК��$	��258��$��20��$��0,15,0,0q�$
��Left=����#A5CCE4���� *CreateNewTextbookCommand+