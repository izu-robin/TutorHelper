   M S B A M L   `   `   `  ���� F  BTutorHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TutorHelper.ViewModelTutorHelper.ViewModel      TutorHelper.View.Pricing   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2vm#clr-namespace:TutorHelper.ViewModel        
Page_Style#��[    � DataContext  %  TutorHelper.ViewModel.PricingVM  .��� $��15q�.+���  �� CornerRadius$ 	0,20,20,0������  �� ImageSource$ /Images/imgPricing.png�� j� Stretch$
 Fill=��� $��Тарифы: ��$��20(�$
��Left=�$	��Top=�$��	15,15,0,0q�$	��254��
�������$
��Bold"�� $��15,54,15,15q� � RowDefinitions �� $��3* ��� $��4* �.+�� $	��200��$��0��$	��Top=�$��0,0,0,10q�.+���  �� SelectionMode$ Single=����� *PricingsList+ �� SelectedItem �� *SelectedRating+ �� View �� .P��� $��ID�� �� Width$ 70��	 �� DisplayMemberBinding	 �� *Id+�� $#��Название тарифа��$	 280��	 �� *Title+�� $'��!Стоимость занятия��$	 200��	 �� *Price+� $��1��$	��Top=�$��0q�$	��160��.+��� 
 �� Orientation$
 
Horizontal=�.+���  �� Padding$ 5q����#A5CCE4$��2q�$	��277��$ 0,0,0,15��._��� $	��270��.+��� $,��&Редактировать тариф:��
�������$
��Wrap=�$	��281��$
��Bold"�$
��Left=�$��0,0,0,10q��� $
 
Horizontal=�.+��� $��Название: ��
�������$
��Wrap=�$��84��$
��Bold"�$��Center=�$��	0,8,10,10q��� $��0q�$��20��$	��160������ *CurrentEditableRating.Title+ �� Mode$ TwoWay=��� $
 
Horizontal=�.+��� $)��#Стоимость занятия: ��
�������$
��Wrap=�$��85��$
��Bold"�$��Center=�$��0,5,10,0q��� $��20��$	��160������ *CurrentEditableRating.Price+$ TwoWay=��� -    ��Name$ SaveRedactedTextbook��$B��<Сохранить редактированный тариф��$	��256��$��20��$��0,15,0,0q�$
��Left=����#A5CCE4���� *SaveCommand+�� $ 5q����#A5CCE4$��2q�$	��275��$��10,0,0,0q�$ 0,0,15,0��._��� $	��270��.+��� $"��Добавить тариф:��
�������$
��Wrap=�$	��281��$
��Bold"�$
��Left=�$��0,0,0,10q��� $
 
Horizontal=�.+��� $��Название: ��
�������$
��Wrap=�$��84��$
��Bold"�$��Center=�$��0,8,10,5q��� $��0q�$��20��$	��160������ *NewRate.Title+$ TwoWay=��� $
 
Horizontal=�.+��� $)��#Стоимость занятия: ��
�������$
��Wrap=�$��85��$
��Bold"�$��Center=�$��	0,10,10,0q��� $��0q�$��20��$	��160�� �� 	MaxLength$ 5������ *NewRate.Price+$ TwoWay=��� -   $ SaveNewTextbook��$.��(Сохранить новый тариф��$	��256��$��20��$��0,15,0,0q�$
��Left=����#A5CCE4���� *SaveNewRateCommand+