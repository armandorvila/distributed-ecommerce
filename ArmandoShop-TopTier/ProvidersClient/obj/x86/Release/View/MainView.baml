   M S B A M L   `   `   `  ���� V  RArmandoShop.ProvidersClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ArmandoShop.ProvidersClient.View ArmandoShop.ProvidersClient.View  /    )ArmandoShop.ProvidersClient.View.MainView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Barmando.clr-namespace:ArmandoShop.ProvidersClient.View     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  ArmandoShop��$	��523��$	��758�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterScreen=�.��]� -   $��
dockPanel1��$	��484��$	��743��.+�� -   $��leftPanelGrid��$	��441��$	��199��.+��� -   $��personalInformationLabel��$��Personal Information��$��28��$
��Left=�$��
10,100,0,0q�$	��Top=�$	��177��$
��Bold"�$��Normal$�$��Maiandra GD)�$��14(��� -   $��	nameLabel��$
��Name��$��24��$
��Left=�$��	0,136,0,0q�$	��Top=�$��60��$
��Bold"�$��Maiandra GD)�$��12(��� -   $��	mailLabel��$
��Mail��$��28��$
��Left=�$��	0,199,0,0q�$	��Top=�$��54��$
��Bold"�$��Maiandra GD)�$��12(��� -   $��nameTextBox��$��23��$
��Left=�$��
66,0,0,282q�$��Bottom=�$	��127�� �� 
IsReadOnly .  {�.  ���� *Name+�� -   $��mailTextBox��$��23��$
��Left=�$��
66,204,0,0q�$	��Top=�$	��127�� .  {�.  ���� *Mail+�� -   $��allowModificationCheckBox��$��Enable Modification��$��24��$
��Left=�$��	6,372,0,0q�$	��Top=�$
��Bold"�$��Maiandra GD)�$��12(��� -	   $��modifyDataButton��$��Modify��$��23��$
��Left=�$��
66,402,0,0q�$	��Top=�$��86��{�.  ���� *ModifyInformationCommand+�� -
   $��armandoImage��$��79��$
��Left=�$��6,14,0,0q�$
��Fill=�$	��Top=�$��94��$A��;/ArmandoShop.ProvidersClient;component/Images/armandorv.jpg���� -   $��label1��$��Surname��$��28��$
��Left=�$��	0,165,0,0q�$	��Top=�$
��Bold"��� -   $��surnameTextBox��$��23��$
��Left=�$��
66,170,0,0q�$	��Top=�$	��127�� .  {�.  ���� *	Surname+�� -   $��label2��$��Address��$��28��$
��Left=�$��	0,230,0,0q�$	��Top=�$
��Bold"��� -   $��addressTextBox��$��23��$
��Left=�$��
66,235,0,0q�$	��Top=�$	��127�� .  {�.  ���� *	Address+�� -   $��label3��$��Phone��$��28��$
��Left=�$��	0,267,0,0q�$	��Top=�$
��Bold"��� -   $��phoneTextBox��$��23��$
��Left=�$��
66,267,0,0q�$	��Top=�$	��127��{�.   .  ���� *Phone+�� -   $��label4��$��Username��$��28��$
��Left=�$��	0,301,0,0q�$	��Top=�$
��Bold"��� -   $��usernameTextBox��$��22��$
��Left=�$��
66,301,0,0q�$	��Top=�$	��127��{�.   .  ���� *
Username+�� -   $��label5��$��Password��$��28��$
��Left=�$��	0,330,0,0q�$	��Top=�$
��Bold"�G� -   $��passwordTextBox��5   /ArmandoShop.ProvidersClient.View.PasswordHelper   Attach . $��23��$
��Left=�$��
66,335,0,0q�$	��Top=�$	��127��{�.     Password ��  �� Path$ Password� �� Mode$ TwoWay=�� -   $��centralPanelGrid��$	��444��$	��519��	 J� OpacityMask	 Z� .+��� -   $��categoriesListView��$	��260��$
��Left=�$��
24,104,0,0q�$	��Top=�$	��280������ *ProviderCategories+
 �� SelectedValue
 �� *MineSelected+ �� View �� .P��� $
��Name�� �� Width$	 129�� �� DisplayMemberBinding �� $
 name��� $��Description��$	 147�� �� $ description��� -   $��restOfCategoriesListView��$	��260��$
��Left=�$��359,104,0,0q�$	��Top=�$	��134������ *RestOfCategories+
 �� *NewSelected+ �� .P��� $
��Name��$	 129�� �� $
 name��� -   $��yourCategoriesLabel��$��Your Categories��$��28��$
��Left=�$��	45,66,0,0q�$	��Top=�$	��184��$
��Bold"�$��Normal$�$��Maiandra GD)�$��16(��� -   $��newCategoriesList��$��New Categories��$��28��$
��Left=�$��
359,66,0,0q�$	��Top=�$
��Bold"�$��Normal$�$��Maiandra GD)�$��16(�$	��175���� -   $��AddCategory��$	��Add��$��23��$
��Left=�$��409,403,0,0q�$	��Top=�$��84��$
��Bold"�$��Maiandra GD)����� *AddCategoryCommand+�� -   $��removeButton��$��Remove��$��22��$
��Left=�$��221,404,0,0q�$	��Top=�$��83��$
��Bold"�$��Maiandra GD)����� *RemoveCategoryCommand+�� -   $��detailsButton��$��Details��$��22��$��Right=�$��0,404,410,0q�$	��Top=�$��85��$
��Bold"�$��Maiandra GD)��� -   $��label6��$ ��Armando Shop for Providers��$��45,0,97,400q�$
��Bold"�$��24(�$��Normal$�$��Maiandra GD)�