   M S B A M L   `   `   `  ����L  HManagamentLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ManagamentLibrary.ViewsManagamentLibrary.Views  5   	   )    #ManagamentLibrary.Views.ViewStudent   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ManagamentLibrary.Views     5   	   -   5          � Title$  ViewStudent��5	   	   $	��450��6   $	��800��6*   .��5
      �� -   5         ��Name$ scrollViewer��5
      $
��Auto=�6)   $��0,0,0,-6q�6M   .��5   
   � $��0,0,0,0q�6   ���	#FFFFC080$	��835��67   .+�5      �� $��Center=�6   $	��139��65   $	��Top=�6B   $	��986��6Z   
���   �
�������6u   �� 5      $;��5pack://application:,,,/img/icons8-student-male-50.png��6   $
��Left=�6S   $	��134��6n   $��	250,3,0,0q�6{   $	��Top=�6�   $	��145��6�   $��UniformToFill=�5       J� RenderTransformOrigin$ 0.5,0.5&�6)   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -0.749Q�6(   �� 5      T� 5       T� X$ -0.654Q�6-   5      5      �� 5      $��View Student��6   $
��Left=�6+   $��
380,49,0,0q�6F   $	��Top=�6Z   ���	#FF0FB1EF$��24(�6�   $
��Bold"�6�   �� 5      $	��MSV��6   $��250,139,0,0q�6"   $��14(�67   $
��Bold"�6E   $��36��6W   $
��Left=�6c   $	��Top=�6~   $��5,7,5,5q�6�   �� 5      -   5         ��Name$ TextBox_Search��5      $
��Left=�6/   $��300,148,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��183��6�   �� 5      -   5        $��Refresh��5      $
��Left=�6'   $��500,146,0,0q�6B   $	��Top=�6W   $��70��6o   6z   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridView1��5      $��Center=�6.   $	��278��6K   $��	0,175,0,0q�6X   $	��Top=�6k   $	��500��6�   ���	#FFB8B4B4   AutoGenerateColumns$
 True��6�   6�   � 5      -   5        	 �Name$	 panel2��5      $��Center=�6#   $��	0,498,0,0q�6@   $	��Top=�6S   .+�5      �� $��Center=�6   $	��320��69   
���   �$	��Top=�6U   $	��922��6m   ���	#FFB8B4B46y   �� 5      $	��MSV��6   $
��Left=�6&   $��
85,102,0,0q�6A   $	��Top=�6U   $��14(�6m   �� 5       $
��Name��6   $
��Left=�6'   $��
85,209,0,0q�6B   $	��Top=�6V   $��14(�6n   �� 5!      $��Class��6   $
��Left=�6(   $��
85,153,0,0q�6C   $	��Top=�6W   $��14(�6o   �� 5"      -   5        $��Update��5"   1   $
��Left=�6B   $��556,267,0,0q�6]   $	��Top=�6r   $
��Bold"�6�   $��14(�6�   $��	12,6,12,6q�6�   �� 5#      -   5        $��Delete��5#   1   $
��Left=�6B   $��688,267,0,0q�6]   $	��Top=�6r   $
��Bold"�6�   $��14(�6�   $��	12,6,12,6q�6�   �� 5$      -	   5        $��Cancle��5$   4   $
��Left=�6E   $��818,267,0,0q�6`   $	��Top=�6u   $
��Bold"�6�   $��14(�6�   $��	12,6,12,6q�6�   �� 5%      -
   5        $	 MSV��5%      ${�False��6'   $
��Left=�69   $��232,100,0,0q�6T   $
 Wrap=�6i   $��TextBox��6}   $	��Top=�6�   $	��229��6�   $��14(�6�   �� 5&      -   5        $
 Name��5&      $
��Left=�6(   $��232,157,0,0q�6C   $
 Wrap=�6X   $��TextBox��6l   $	��Top=�6{   $	��229��6�   $��14(�6�   �� 5'      -   5        $ Class��5'      $
��Left=�6)   $��232,213,0,0q�6D   $
 Wrap=�6Y   $��TextBox��6m   $	��Top=�6|   $	��229��6�   $��14(�6�   5(      5)      5*      5+      