   M S B A M L   `   `   `  ����  EmailService.WpfApp$    EmailService.WpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Email Sender��5   	   $	��400��6   $	��600��6+   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Recipient Email:��6   �� 5   
   -   5         ��Name$ RecipientTextBox��5      $��1��6   $	��0,5q�69   �� 5   
   $��2��6   $��Message:��6!   �� 5   
   -   5        $ BodyTextBox��5      $��3��6    �� AcceptsReturn$
 True��64   $	��0,5q�6I   �� 5   
   -   5        $��4��5      $��
Send Email��6   $	��100��6K   $��Right=�6W   5      5      