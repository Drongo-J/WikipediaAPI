   M S B A M L   `   `   `  ����G  CWikipediaAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WikipediaAPIWikipediaAPI  5   	       WikipediaAPI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WikipediaAPI     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � Title$ 	Wikipedia��5   	   $	��520��5   	    � Icon$ \Assets\wiki.ico  ��5   	   $	��800��5   	   .��5      � .+�5   
   �� .+�5      � .+�5      ��    SecondColor#���   6   $	��Top=�5      $��Center=�5      $	��100��5      $
��1500��5       �� Orientation$ 
Horizontal=�5      .+�5      �� 
������ $	��100��5      $	��800��6&   .+�5      �� -   5        $��SearchTB��5      $��46��5      $��Search Wikipedia��5      $��	16,7,35,0q�5      $��27(�5         
FifthColor#���  5!       �� Left$	 390��5"      
 �� Top$ 26��5#      $
��Left=�5%      $��Center=�5&      $	��645��5'      |�5$      �� *SearchBoxIsFocused+.��5'   *    J� InputBindings 5(      �� 5)   "   
 �� Key$ Return��6-   	 �� Command	 6:   �� *SearchCommand+6^   .��5*   5   .  (System.Windows.Interactivity.Interaction
   Triggers
 5+      /  )System.Windows.Interactivity.EventTrigger  5,   "      	EventName$ 
MouseEnter��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5-   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *MouseEnterCommand+5.   #     50   "   $ 
MouseLeave��61   . 51   &      6<   �� *MouseLeaveCommand+52   #     54   "   $ GotFocus��61   . 55   &      6<   �� *IsFocusedCommand+56   #     58   "   $ 	LostFocus��61   . 59   &      6<   �� *IsNotFocusedCommand+5:   #   .��5;   6   5<      �� 5>      $��\Assets\clear.png��6     � Cursor$
 Hand��6;   $��23��6I   $��20��6U   $
 1010��6`   $ 48��6s   $
��Left=�6�   $	��Top=�6�    J� RenderTransformOrigin$ 3.3,0.6&�6�    5?      d� 5@   "    d� Gesture$ 	LeftClicka�6/   	 6C   �� *ClearCommand+6f   5B      �� 5D      $��46��5E      $��	16,7,35,0q�5F      $��27(�5G      #���  5H      $��Search Wikipedia . . .��5I      $
 1034��5J      $ 26��5K       �� 
IsReadOnly . $
��Left=�5M      $	��Top=�5N      $��50��5O      .��6)    5P      d� 5Q   "   $ 	LeftClicka�6/   	 6C   �� *SearchCommand+6g   .��5R   5   5S      �� 5T      $��\Assets\Search.png��6    $��32��5U       $��32��5V        �� Right$	 400��5W       $ 44��5X       $
 Hand��5Y       $
��Left=�5Z       $	��Top=�5[       $
 1053��5\       $ 0.344,0.501&�63    5]      d� 5^   "   $ 	LeftClicka�6/   	 6C   �� *SearchCommand+6g   5`      5a      5b      5c      �� 5e      $
��Auto=�6   ��.  $��Disabled=�5g      $	��380��5h      .��5i      �� $��0q�5j        LvItemStyle#��[ 5k      ��5i      �� *	Results+��5m      �� 5n       �� 
TargetType" ��6*   .R�5o      �� #��z��6%   #��z��6Q   ._�5p   "   �� 5q      5r      ��5u      �� 5v      .R�5w      � $
��Auto��6(   $	��780��66   $��0,20,0,0q�6B   6V   5x      5z      5{      5|      5}      5~      