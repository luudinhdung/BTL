   M S B A M L   `   `   `  ����L  HManagamentLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ManagamentLibraryManagamentLibrary  5   	   +    %ManagamentLibrary.EmailAuthentication   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ManagamentLibrary     5   	     � WindowStyle$  SingleBorderWindow=�5   	    � 
ResizeMode$ NoResize=�6*    � Title$ EmailAuthentication��5	   	   $	��500��6%   $	��349��62   ���	#FF232423.��5
      � .+�5   
   �� -   5         ��Name$ btnArrow��5      $
��Left=�6:   $��	10,10,0,0q�6U   $	��Top=�6h   ��6�   Z� ��6�   Z� ��6�   Z� .��5      �� $*��$pack://application:,,,/img/arrow.png��6   $��25��6B   $��25��6N   5      �� 5   
   $��Center=�6   $	��100��6-   $��0,22,0,0q�6:   $	��Top=�6L   $	��100��6d   $8��2pack://application:,,,/img/emailAuthentication.png��6p   �� 5   
   $7��1Mã xác thực sẽ được gửi đếm Email:��6   $��Center=�6=   $��	0,140,0,0q�6Z   $	��Top=�6m   $��29��6�   $	��233��6�   
�������$��14(�6�   �� 5   
   -   5        $"��Email_Authentication_Content��5      $�� ��64   $��	0,174,0,0q�6?   $��29��6R   $	��233��6^   
�������$��14(�6}   $��Center=�6�   $	��Top=�6�   $��Center=�5      $��Center=�64   �� 5   
   -   5        $��txtConfirmCode��5      $
��Left=�6(   $��
58,223,0,0q�6C    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��151��6�   $��27��6�   $��16(�6�   �� 5   
   -   5        $��	Gửi mã��5   (   $
��Left=�69   $��228,223,0,0q�6T   $	��Top=�6i   $��63��6�   $��16(�6�   
�������6�   �� 5   
   -   5        $��Xác nhận��5   +   $��Center=�6>   $��	0,300,0,0q�6[   $	��Top=�6n   $��34��6�   $	��139��6�   $��16(�6�   
�������6�   5      5      