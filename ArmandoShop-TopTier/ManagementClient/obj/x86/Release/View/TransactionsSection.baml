   M S B A M L   `   `   `  ����    ArmandoShop.ManagementClient;    5ArmandoShop.ManagementClient.View.TransactionsSection   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -   $��grid4��$	��365��$	��643��.+��� -   $��ordersListView��$	��234��$
��Left=�$��	12,54,0,0q�$	��Top=�$	��306��$
��Bold"����� *Orders+  �� SelectedValue  �� *SelectedOrder+ �� View �� .P��� $��Customer�� �� Width$ 60�� �� DisplayMemberBinding ��  �� Path$ customer.name��� $��Date Of Buy��$ 90�� �� $ 	dateOfBuy��� $��Date Of Deliver��$ 90�� �� $ dateOfDeliver��� $��	Delivered��$ 60�� �� $ 	delivered��� -   $��contractsListView��$	��234��$
��Left=�$��
346,54,0,0q�$	��Top=�$	��285��$
��Bold"����� *	Contracts+  �� *SelectedContract+ �� .P��� $��Provider��$ 60�� �� $ provider.name��� $��Product��$ 70�� �� $ product.name��� $��Stock��$ 40�� �� $ stock��� $
��Date��$ 50�� �� $
 date��� $��Charged��$ 55�� �� $ charged��� -   $��ordersHeaderLabel��$��Orders��$��28��$
��Left=�$��	12,12,0,0q�$	��Top=�$	��193��$
��Bold"��� -   $��contractsHeaderLabel��$��	Contracts��$��28��$
��Left=�$��
306,12,0,0q�$	��Top=�$	��192��$
��Bold"��� -   $��deliverOrderButton��$��Tick Deliver��$��21��$
��Left=�$��157,311,0,0q�$	��Top=�$��66������ *DeliverOrderCommand+�� -   $��deleteContractButton��$��Delete��$��21��$
��Left=�$��564,311,0,0q�$	��Top=�$��67������ *DeleteContractCommand+�� -   $��deleteOrderCommand��$��Delete��$��21��$
��Left=�$��250,311,0,0q�$	��Top=�$��68������ *DeleteOrderCommand+�� -	   $��button4��$��Resolve��$��21��$
��Left=�$��466,311,0,0q�$	��Top=�$��68������ *MarkAsPaidCommand+