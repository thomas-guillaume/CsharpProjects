   M S B A M L   `   `   `  ����W  SMVC_TDFinal_GUILLAUME_Thomas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MVC_TDFinal_GUILLAUME_ThomasMVC_TDFinal_GUILLAUME_Thomas  5   	   .    (MVC_TDFinal_GUILLAUME_Thomas.V_Recherche   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:MVC_TDFinal_GUILLAUME_Thomas     5   	     � Title$  Recherche de crimes��5   	   $	��500��6%   $	��600��62   .��5	      � .+�5
   
   �� -   5         ��Name$ 
Rechercher��5
      $��
Rechercher��6%   $
��Left=�6:   $��
475,60,0,0q�6U   $	��Top=�6i   $��75��6�   $��90��6�   6�   �� 5   
   -   5         ��Name$ textdate��5      $
��Left=�6$   $��23��6?   $��
300,40,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6�   $	��120��6�   ��6s   ��  �� Path$
 date� �� Mode$ OneWay=�6�   �� 5   
   -   5        $ textquartier��5      $
��Left=�6(   $��23��6C   $��
300,90,0,0q�6O   $
 Wrap=�6c   $	��Top=�6�   $	��120��6�   ��6w   �� $ quartier�$ OneWay=�6�   �� 5   
   -   5        $ textdescription��5      $
��Left=�6+   $��23��6F   $��300,140,0,0q�6R   $
 Wrap=�6g   $	��Top=�6�   $	��120��6�   ��6{   �� $ description�$ OneWay=�6�   �� 5   
   -   5         ��Name$ 	Resultats��5      $
��Left=�6&   $	��250��6A   $��	20,0,0,20q�6N   $��Bottom=�6a   $	��550��6|    �� View 5      �� 5      .P�5      �� $
��Date��6%    �� Width$ 70��63   	 �� DisplayMemberBinding	 6>   �� *date+�� 5      $��Quartier��6%   $ 70��67   	 6B   �� *	borough+�� 5      $��CoordX��6%   $ 60��65   	 6@   �� *	coord_X+�� 5      $��CoordY��6%   $ 60��65   	 6@   �� *	coord_Y+�� 5      $��Description��6%   $	 120��6:   	 6F   �� *description+�� 5      $��Détail��6%   $ 90��65   	 6@   �� *desc_specificity+�� 5      $��Juridiction��6%   $ 70��6:   	 6E   �� *jurisdiction+5      5      �� 5   
   -   5        
 ��Name$

 date��5      $*��$Saisissez une date (ex : jj/mm/aaaa)��6   $
��Left=�6M   $��	40,40,0,0q�6h   $	��Top=�6{   �� 5   
   -   5        $
 quartier��5      $(��"Saisissez un quartier (ex : bronx)��6"   $
��Left=�6O   $��	40,90,0,0q�6j   $	��Top=�6}   �� 5   
   -   5        $
 description��5      $/��)Saisissez une description (ex : burglary)��6%   $
��Left=�6Y   $��
40,140,0,0q�6t   $	��Top=�6�   5      5       