   M S B A M L   `   `   `  ����   ArmandoShop.ProvidersClient3    -ArmandoShop.ProvidersClient.View.CategoryView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  CategoryView��$	��449��$	��586�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� $	��436��$	��562�� � ColumnDefinitions �� $
��446* ��� $
��116* �.+��� -   $��productsList��$	��248��$
��Left=�$��	27,72,0,0q�$	��Top=�$	��512��$��2������ *
Products+ �� SelectedValue �� *SelectedProduct+ �� View �� .P��� $
��Name�� �� Width$	 150�� �� DisplayMemberBinding �� 	 �� Path$
	 name��� $��Description��$	 247�� �� $	 description��� $��Price��$ 60�� �� $	 price��� $��Stock��$ 60�� �� $	 stock��� -   $��categoryLabel��$��
Category: ��$��39��$
��Left=�$��	27,27,0,0q�$	��Top=�$
��Bold"�$��Italic$�$��18(�$	��121���� -   $��categoryName��$��39��$
��Left=�$��
154,27,0,0q�$	��Top=�$
��Bold"�$��Italic$�$��18(�$	��208������ *CategoryName+�� -   $��provideButton��$��Provide��$��23��$
��Left=�$��
27,346,0,0q�$	��Top=�$��97������ *ProvideCommand+�� -   $��amountSlider��$��23��$
��Left=�$��154,346,0,0q�$	��Top=�$	��252��
 �� Interval$
 10�� � Maximum$	 500Q� �� SelectionEnd$	 100Q� �� TickPlacement$ BottomRight=� � SmallChange$ 1Q� � LargeChange$ 10Q� �� IsSelectionRangeEnabled .   �� IsSnapToTickEnabled .  �� Ticks$* $1,10,20,30,40,50,100,200,300,400,500R� � Value �� *Amount+�� -   $��AmountLabel��$��28��$
��Left=�$��420,346,0,0q�$	��Top=�$��70��$��2������  �� ElementName$ amountSlider��$	 Value��� -   $��amountDecoratorLabel��$��units��$��1��$��28��$
��Left=�$��	8,346,0,0q�$	��Top=�$��54��