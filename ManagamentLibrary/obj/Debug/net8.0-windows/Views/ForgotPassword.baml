   M S B A M L   `   `   `  ����L  HManagamentLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ManagamentLibraryManagamentLibrary  5   	   &     ManagamentLibrary.ForgotPassword   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ManagamentLibrary     5   	     � WindowStyle$  SingleBorderWindow=�5   	    � 
ResizeMode$ NoResize=�6*    � Title$ ForgotPassword��5	   	   $	��500��6    $	��349��6-   ���	#FF232423.��5
      � .+�5   
   �� -   5         ��Name$ btnArrow��5      $
��Left=�6:   $��	10,10,0,0q�6U   $	��Top=�6h   ��6�   Z� ��6�   Z� ��6�   Z� .��5      �� $*��$pack://application:,,,/img/arrow.png��6   $��25��6B   $��25��6N   5      �� 5   
   $��Center=�6   $	��100��6-   $��0,22,0,0q�6:   $	��Top=�6L   $	��100��6d   $4��.pack://application:,,,/img/forgot-password.png��6p   �� 5   
   -   5        $��Label_EnterEmail��5      $ ��Nhập email xác thực :��6(   $��Center=�6H   $��	0,149,0,0q�6e   $	��Top=�6x   $��29��6�   $	��145��6�   
�������$��14(�6�   �� 5   
   -   5         ��Name$ EmailTextBox��5   
   $��Center=�5      $��	0,209,0,0q�6/    �� TextWrapping$
 Wrap=�6B   $	��Top=�6V   $	��182��6n   $��21��6z   
����������	#FFACAAAA
���   �$��1,1,1,1q�5   4   $��12(�5       �� 5   
   -   5        $��btn_NextForgotPassword��5      $��Tiếp theo��6P   $��Center=�6d   $��	0,274,0,0q�6�   $	��Top=�6�   $��34��6�   $	��139��6�   $��16(�6�   
�������6�   �� 5   
   -   5        $��Label_NewPassWord��5      $��Nhập mật khẩu mới��6)   $
��Left=�6E   $��
84,154,0,0q�6`   $	��Top=�6t   $��26��6�   $	��140��6�   
�������$
��Bold"�6�   $y�	Collapsed=�6�   G� 5   
   -   5         G�Name$ PasswordBox_NewPassWord��5      $��Center=�5      $��	0,185,0,0q�64   $	��Top=�6H   $	��182��6`   $��21��6l   
����������	#FFACAAAA
���   �$��1,1,1,1q�5   8   $��12(�5   .   $y�	Collapsed=�6<   �� 5   
   -   5        $ TextBox_NewPassWord��5      $��Center=�5      $��	0,185,0,0q�60   $
 Wrap=�6C   $	��Top=�6W   $	��182��6o   $��21��6{   
����������	#FFACAAAA
���   �$��1,1,1,1q�5   8   $��12(�5   *   $y�	Collapsed=�68   �� 5   
   -   5        $$ TogglePasswordVisibilityButton��5      $��Right=�69   $��
0,186,83,0q�6U   $	��Top=�5      $��23��6%   $��18��60   
�������$y�	Collapsed=�5    c   ��5   <   Z� ��5    M   Z� .��5!      �� $-��'pack://application:,,,/img/eye_open.png��6   $��15��6E   $��15��6P   5"      �� 5$   
   -	   5        $��Label_Re_enterNewPassWord��5$      $��Nhập lại mật khẩu��61   $
��Left=�6M   $��
84,206,0,0q�6h   $	��Top=�6|   $��26��6�   $	��140��6�   
�������$
��Bold"�6�   $y�	Collapsed=�6�   G� 5%   
   -
   5        $&�� PasswordBox_Re_Enter_NewPassWord��5'      $��Center=�5%      $��	0,237,0,0q�64   $	��Top=�6G   $	��182��6_   $��21��6k   
����������	#FFACAAAA
���   �$��1,1,1,1q�5&   8   $��12(�5'   5   $y�	Collapsed=�6C   �� 5(   
   -   5        $!��TextBox_Re_enterNewPassWord��5*      $��Center=�5(      $��	0,237,0,0q�60   $
 Wrap=�6C   $	��Top=�6W   $	��182��6o   $��21��6{   
����������	#FFACAAAA
���   �$��1,1,1,1q�5)   8   $��12(�5*   0   $y�	Collapsed=�6>   �� 5+   
   -   5        $. (Toggle_Re_Enter_PasswordVisibilityButton��5+      $��Right=�6C   $��
0,237,83,0q�6_   $	��Top=�5,      $��23��6%   $��21��60   
�������$y�	Collapsed=�5-   m   ��5,   <   Z� ��5-   W   Z� .��5.      �� $-��'pack://application:,,,/img/eye_open.png��6   $��15��6E   $��15��6P   5/      �� 50   
   -   5        $��btn_ChangePassWord��50      $��Đổi mật khẩu��6H   $��Center=�6_   $��	0,296,0,0q�6|   $	��Top=�6�   $��34��6�   $	��139��6�   $��16(�6�   
�������$y�	Collapsed=�6�   51      52      