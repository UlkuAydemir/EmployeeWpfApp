   M S B A M L   `   `   `  ????G  CEmployee.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Employee.Wpf.ViewModelsEmployee.Wpf.ViewModels  5      )    #Employee.Wpf.Views.ListEmployeeView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;	viewmodel%clr-namespace:Employee.Wpf.ViewModels     5      .??5	      ? 
???????  ? RowDefinitions  5
   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?? $??0??6   
???????$??3q?66   ._?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??1??6   $??0 0 0 0q?6*   $	??800??6;   
?????????5      ?? *	SearchKey+?? 5      $??5 0 0 0q?6   $??Search??6s   $
??Left=?6?   ??6*   ?? *SearchCommand+??6L   ?? *	SearchKey+6?   5      5      ? 5   
   $??1??6   .+?5      ?? 
???????$??5q?6-   ._?5      &   System.Windows.Controls.DataGrid  <my-http://schemas.microsoft.com/wpf/2008/toolkit     6.   -   5        $??dgEmployees??5         CanUserAddRows$
 True??6g      AutoGenerateColumns$ False??6?   ??6}   ?? *EmployeeModels+ ?? Mode$ TwoWay=? ?? SelectedItem 6?   ?? *SelectedEmployee+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee Id??6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   ?? 	 ?? Path$	 Id?  5      $ Employee Name??6-    6D   ?? $
	 Name?  5      $ Employee Email??6-    6E   ?? $	 Email?  5      $ Employee Gender??6-    6F   ?? $	 Gender?  5      $ Employee Status??6-    6F   ?? $	 Status?4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Update Action??61   
   CellTemplate
 5       ?? 5!   "   .R?5"   &   ?? $??Update??6-   $??Update??6M  ??6<   ?? *DataContext.UpdateCommand+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType"  ??6?   ?? *DataContext.SelectedEmployee+$ TwoWay=? ?? *FindAncestor+"  6M  5#   #   5%        5&      $ Delete Action??61   
 5'      ?? 5(   "   .R?5)   &   ?? $??Delete??6-   $??Delete??6L  ??6;   ?? *DataContext.DeleteCommand+ ?? *FindAncestor+"  ??6?   ?? *DataContext.SelectedEmployee+$ TwoWay=? ?? *FindAncestor+"  6L  5*   #   5,      5.      5/      50      ?? 51   
   $??10q?6   
???????$??2??6>   ._?52      ? 
???????.+?53      ?? $ 
Horizontal=?6   $??Center=?66   
???????.+?54      ?? $??Previous??6   $??10q?6\   $??previous??6?   {?60   ?? *ButtonPreviousEnabled+??6i   ?? *PagingCommand+6?   ?? 55      $??2q?6   
???????._?56      ??  ?? Padding$ 10q?6?   ??6$   ?? *	PageCount+6?   57      ?? 58      $
??next??6?   $??   Next    ??6W   $??10q?6m   ??6   ?? *PagingCommand+6m   59      5:      5;      5<      5=      