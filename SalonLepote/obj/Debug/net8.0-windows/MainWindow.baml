   M S B A M L   `   `   `  ����F  BSalonLepote, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalonLepoteSalonLepote  5   	       SalonLepote.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalonLepote     5   	   $	��450��5   	   $	��800��6   .��5	      � 
�������.+�5
   
   �� $
��Left=�6   $��44��60   $	��Top=�6=   $	��378��6U     �� Orientation$  
Horizontal=�6a   $��303,331,0,0q�6z   .+�5      �� -   5         ��Name$ btnDodaj��5      $��Dodaj��6'   $	��120��67   $��16(�6Z   $��Century Gothic)�6h   $��40��6�   
�������
�������$��Italic$�6�   ��5      �� 5       �� Color$ 	#FF292728��6&   5      �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   $��Century Gothic)�6]   $��16(�6y   $��40��6�   
�������
�������$��Italic$�6�   ��5      �� 5      $ 	#FF292728��6&   5      �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   $	��120��69   $��Century Gothic)�6]   $��16(�6y   $��40��6�   
�������
�������$��Italic$�6�   ��5      �� 5      $ 	#FF292728��6&   5      5      � 5   
   $
��Left=�6   $	��434��6*   $��Center=�67   $	��184��6R   ���	#FF292728.+�5      �� $��Center=�6   $	��436��66   $	��Top=�6D   $	��298��6\   ���	#FF292728$��0,49,0,0q�6   .+�5      �� -   5        $ btnZakazivanja��5      $��Zakazivanja��61   $��Center=�6G   $��45��6d   $	��110��6p   $��18(�5      $��Century Gothic)�6'   $��Center=�6C   
���������6^   Z� ��6�   Z� �� 5      -   5        $ btnKlijenti��5      $��Klijenti��6.   $��Center=�6A   $��45��6^   $��Center=�6j   $	��110��6�   $��18(�5       $��Century Gothic)�6'   
���������6V   Z� ��6l   Z� �� 5!      -   5        $ btnZaposleni��5!      $��	Zaposleni��6/   $��Center=�6C   $��45��6`   $��Center=�6l   $	��110��6�   $��Century Gothic)�5"      $��18(�65   
���������6C   Z� ��6Z   Z� 6p   �� 5#      -   5        $ 	btnUsluge��5#      $��Usluge��6,   $��Center=�6=   $��45��6Z   $��Center=�6f   $	��110��6�   $��Century Gothic)�5$      $��18(�65   
���������6C   Z� ��6Y   Z� 6p   �� 5%      -   5        $ btnVrsteUsluga��5%      $��Vrste usluga��61   $��Center=�6H   $��45��6e   $��Center=�6q   $	��110��6�   $��Century Gothic)�5&      $��18(�65   
���������6V   Z� ��6l   Z� �� 5'      -	   5        $ btnProizvodi��5'      $��	Proizvodi��6/   $��Center=�6C   $��45��6`   $��Center=�6l   $	��110��6�   $��Century Gothic)�5(      $��18(�65   
���������6C   Z� ��6m   Z� �� 5)      -
   5        $ 
btnNabavke��5)      $��Nabavke��6-   $��Center=�6?   $��45��6\   $��Center=�6h   $	��110��6�   $��Century Gothic)�5*      $��18(�65   
���������6C   Z� ��6Y   Z� 6p   �� 5+      -   5        $ 
btnTermini��5+      $��Termini��6-   $��Center=�6?   $��45��6\   $��Center=�6i   $	��110��6�   $��Century Gothic)�5,      $��18(�65   
���������6C   Z� ��6Y   Z� 6p   5-      5.      �� 5/   
   $
��Left=�6   $	��108��6/   $��	184,0,0,0q�6<   $	��Top=�6O   $	��616��6g   
�������6s   �� 50   
   $
��Left=�6   $	��108��6/   $��	184,0,0,0q�6<   $	��Top=�6O   $	��216��6g   ��51      �� 52       �� ImageSource$+ %/1909bb80e75b089254e44a8ee0ccc0cd.jpg��6   54      &   System.Windows.Controls.DataGrid  55   
   -   5          Name$ dataGridCentralni��55      $
��Left=�60   $	��Top=�6K   $
��auto��6e   $
��auto��6s      
IsReadOnly$
 True��6�      AlternatingRowBackground
 �����   CanUserAddRows$ False��56   ,      SelectionUnit$ FullRow=�6C   	   SelectionMode$	 Single=�6[   $��254,130,0,0q�6r   
���   �6�   57      58      