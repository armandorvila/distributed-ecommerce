   M S B A M L   `   `   `  ���� W  SArmandoShop.ManagementClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:ArmandoShop.ManagementClient.View!ArmandoShop.ManagementClient.View  0    *ArmandoShop.ManagementClient.View.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Alocal/clr-namespace:ArmandoShop.ManagementClient.View       � Title$  ArmandoShop Management��$	��570��$	��856�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=�$
��Bold"�.��]� -   $��
dockPanel1��$	��534��$	��829��.+�� -   $��
headerGrid��$��91��$	��823��$	��Top=�$y�Visible=� � UseLayoutRounding .  � RowDefinitions �� $	��52* ��� $	��39* � � ColumnDefinitions �� $	��86* ��� $
��515* �.+��� -   $
��logo��$��74��$
��Left=�$��16,6,0,0q�$
��Fill=�$	��Top=�$��95��$B��</ArmandoShop.ManagementClient;component/Images/armandorv.jpg��$��2��$��2���� -   $��label1��$��Armando Shop Managment��$��50��$
��Left=�$��
113,16,0,0q�$	��Top=�$	��331��$��24(�$
��Bold"�$��Italic$�$��1��$��2��
��������� -   $��border1��
�������$��1q�$��74��$
��Left=�$��16,6,0,0q�$	��Top=�$��95��$��2��$��2������  �� ImageSource$B </ArmandoShop.ManagementClient;component/Images/header_bg.jpg��� -   $��contentGrid��$	��381��$	��659��$��Right=�
������� �� $	��62* ��� $
��328* �.+��� -   $��border4��
�������$��1q�$��6q�
�������$��2��._��� -   $��tabbedPanel��$	��365��$	��643������ .@��� -	   $��Statics��$��Statics��.��6   0ArmandoShop.ManagementClient.View.StaticsSection   � DataContext �� *StaticsViewModel+�� -
   $��Products��$��Products��.��7   1ArmandoShop.ManagementClient.View.ProductsSection   �� *ProductsViewModel+�� -   $��
Categories��$��
Categories��.��9   3ArmandoShop.ManagementClient.View.CategoriesSection   �� *CategoriesViewModel+�� -   $��	Providers��$��	Providers��.��8   2ArmandoShop.ManagementClient.View.ProvidersSection   �� *ProvidersViewModel+�� -   $��	Customers��$��	Customers�� �� *CustomersViewModel+.��8   2ArmandoShop.ManagementClient.View.CustomersSection  �� -   $��Transactions��$��Transactions��.��;   5ArmandoShop.ManagementClient.View.TransactionsSection   �� *TransactionsViewModel+� -   $��buttonsGrid��$	��381��$	��161��$
��Left=� �� $	��10* ��� $
��371* �.+��� -   $��border2��
�������$��1q�$	��322��$
��Left=�$��9,43,0,0q�$	��Top=�$	��146��$��1��._�� -   $��
wrapPanel1��$	��193��$	��115��.+��� -   $��staticsButton��$��Statics��$��32��$	��115��	 �� 	ClickMode$	 Press=�
 � Cursor$

 Hand������ *GoToStaticsCommand+�� -   $��productsButton��$��Products��$��32��$	��115��$	 Press=�$

 Hand������ *GoToProductsCommand+�� -   $��categoriesButton��$��
Categories��$��32��$	��115��$	 Press=�$

 Hand������ *GoToCategoriesCommand+�� -   $��providersButton��$��	Providers��$��32��$	��115��$	 Press=�$

 Hand������ *GoToProvidersCommand+�� -   $��customersButton��$��	Customers��$��32��$	��115��$	 Press=�$

 Hand������ *GoToCustomersCommand+�� -   $��transactionsButton��$��Transactions��$��32��$	��115��$	 Press=�$

 Hand������ *GoToTransactionsCommand+���� $B </ArmandoShop.ManagementClient;component/Images/header_bg.jpg���� -   $��border3��
�������$��1q�$��36��$
��Left=�$��	9,0,0,335q�$��Bottom=�$	��146��$��1������ $B </ArmandoShop.ManagementClient;component/Images/header_bg.jpg���� -   $��label2��$��Shop Sections��$��28��$	��134��$��16(�$
��Bold"�$��Italic$�
�������$��12,0,16,343q�$��1��