   M S B A M L   `   `   `  ????G  CEmployee.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Employee.Wpf.ViewsEmployee.Wpf.Views  5   	   +    %Employee.Wpf.Views.UpdateEmployeeView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Employee.Wpf.Views     5   	   $	??450??5       $	??800??6-     ? Title  6	   ?? *Name+.??5	      ?? $??25q?6    ?? Padding$ 25q?6   $??Center=?6&      BrushPrimary2#??[  6C   $??4q?6p    ?? CornerRadius$ 10??6?   $??Center=?6?   ._?5
   
   ?  ? RowDefinitions 5      ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    .+?5      ? $??0??6   .+?5      ?? $??Update Employee??6   $??18(?63   $??Center=?6A    ?? Padding$ 15q?6^   5      ? 5      $??1??6   .+?5      ?  ? IsSharedSizeScope$
 True??6    5      ?? 5      $
??auto ?6(   ?? 5      $
??auto ?6(   ?? 5      $
??auto ?6(   ?? 5      $
??auto ?6(   .+?5      ? $??0??6   $
??0 10q?6(    ? ColumnDefinitions 5      ?? 5      $
??auto ?6/    z? SharedSizeGroup$ Label??6<   ?? 5      $	??300 ?6/   .+?5       ?? $??0??6$   $
??Name??64   ?? 5!      $??1??6"   $??20 0 0 0q?62   ??5"      ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?5#      ? 5$      $??1??6   $
??0 10q?6(    5%      ?? 5&      $
??auto ?6/   $ Label??6<   ?? 5'      $	??300 ?6/   .+?5*      ?? $??0??6$   $??Email??64   ?? 5+      $??1??6"   $??20 0 0 0q?62   ??5,      ?? *Email+$ PropertyChanged=?5-      ? 5.      $??2??6    5/      ?? 50      $
??auto ?6/   $ Label??6<   ?? 51      $	??300 ?6/   .+?54      ?? $??0??6$   $??Gender??64   ?? 55      -   5        $??	cmbGender??55   #   $??1??64   $??20 0 0 0q?6D   ??6V   ?? 	 ?? Path$	 Genders?
 ?? SelectedItem
 6{   ?? $	 Gender? ?? Mode$ TwoWay=?56      ?? 57      $??3??6   $
??0 10q?6*   $??Center=?58      $??Update Employee??5:       ?? 	IsDefault$
 True??5;      ??59      ?? *UpdateEmployeeCommand+5;      5<      5=      5>      5?      5@      