#NORMES DE PROGRAMMATION


###**En-tête du programme** 
>Encadré incluant le nom du ou des programmeurs, en plus d’une brève description de celui-ci.
**Ex :** 
/**************************************************************
/Programmeur(s) : John Doe
/Date : 32 janvier 2032
/Fichier: blablabla.txt
/
/Description: 4 à 5 lignes max
/***************************************************************

###**Langue** 
Nom des variables, méthodes et fonctions : Anglais

###**Identificateurs**
1. Nom des variables : camel case (laVariableEnExemple)
2. Nom des constantes : En majuscule avec barre de soulignement entre les mots
3. Nom des méthodes : Première lettre een majuscule avec une majuscule pour chaque mot subséquent. Un verbe et au moins un nom, sans articles.

###**Déclarations**
1. Les varibles : constitue le spremières lignes de code.
2. Initialisation des variables lorsqu’elle est déclarée : numérique = 0; string = empty; boolean = false;

###**Espaces**
1. Aucun blanc à l’intérieur des parenthèses () et des crochets [].
2. Un espace avant et après chaque opérateurs.
3. Une ligne blanche entre chaque bloc de logique ou chaque méthodes, éviter plus d’une ligne blanche.

###**Commentaires**
1. Les commentaires sont au-dessus de la section qui est concernée.
2. Chaque bloc logique et méthodes doivent être commentés.

###**Accolades**
>Délimitent les blocs d’instruction, positionnées une au dessus de l’autre (alignées verticalement).
 
`If (a  >  b)
{
	//code
}`

###**Retraits de ligne**
1. À chaque nouveau bloc d’instruction, il faut intégrer un retrait. 
2. En cas de if imbriqués, il y a deux retraits.
3. Les retraits sont de 4 caratères.

`If (a  >  b)
{
	//code
	//code
	
	If (c >= d)
	{
		//code
	}
}`
