Create DATABASE date_a_base
go
USE   [date_a_base_test] 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ m a t c h e s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ m a t c h e s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ u s e r 1 _ i d ]   [ i n t ]   N U L L , 
 
 	 [ u s e r 2 _ i d ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ m e s s a g e s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ m e s s a g e s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ s e n d e r _ i d ]   [ i n t ]   N U L L , 
 
 	 [ r e c e i v e r _ i d ]   [ i n t ]   N U L L , 
 
 	 [ b o d y ]   [ v a r c h a r ] (max)   N U L L , 
 
 	 [ v i e w e d ]   [ b i t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ p h o t o s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ p h o t o s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ u s e r _ i d ]   [ i n t ]   N U L L , 
 
 	 [ u r l ]   [ v a r c h a r ] (max)   N U L L , 
 
 	 [ p r o f i l e ]   [ b i t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ s t a t e ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ s t a t e ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ u s e r _ i d ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ t a g s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ t a g s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ n a m e ]   [ v a r c h a r ] ( 5 0 )   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ t a g s _ u s e r s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ t a g s _ u s e r s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ u s e r _ i d ]   [ i n t ]   N U L L , 
 
 	 [ t a g _ i d ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ u s e r s ]         S c r i p t   D a t e :   1 2 / 2 1 / 2 0 1 6   2 : 1 8 : 1 9   P M   * * * * * * / 
 
 S E T   A N S I _ N U L L S   O N 
 
 G O 
 
 S E T   Q U O T E D _ I D E N T I F I E R   O N 
 
 G O 
 
 C R E A T E   T A B L E   [ d b o ] . [ u s e r s ] ( 
 
 	 [ i d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L , 
 
 	 [ f i r s t _ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ l a s t _ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ z i p _ c o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ e m a i l ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ p h o n e _ n u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ a b o u t _ m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ t a g _ l i n e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ u s e r _ n a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ p a s s w o r d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L , 
 
 	 [ g e n d e r _ i d e n t i t y ]   [ i n t ]   N U L L , 
 
 	 [ s e e k i n g _ g e n d e r ]   [ i n t ]   N U L L 
 
 )   O N   [ P R I M A R Y ] 
 
 
 
 G O 
 
 
