NORMES DE PROGRAMMATION


•	En-tête du programme 
Encadré incluant le nom du ou des programmeurs, en plus d’une brève description de celui-ci.
Ex : 
/**************************************************************
/Programmeur(s) : John Doe
/Date : 32 janvier 2032
/Fichier: blablabla.txt
/
/Description: 4 à 5 lignes max
/***************************************************************

•	Langue 
Nom des variables, méthodes et fonctions : Anglais

•	Identificateurs
Nom des variables : camel case (laVariableEnExemple)
Nom des constantes : En majuscule avec barre de soulignement entre les mots
Nom des méthodes : Première lettre een majuscule avec une majuscule pour chaque mot subséquent. Un verbe et au moins un nom, sans articles.

•	Déclarations
Les varibles : constitue le spremières lignes de code.
Initialisation des variables lorsqu’elle est déclarée : numérique = 0; string = empty; boolean = false;

•	Espaces
Aucun blanc à l’intérieur des parenthèses () et des crochets [].
Un espace avant et après chaque opérateurs.
Une ligne blanche entre chaque bloc de logique ou chaque méthodes, éviter plus d’une ligne blanche.

•	Commentaires
Les commentaires sont au-dessus de la section qui est concernée.
Chaque bloc logique et méthodes doivent être commentés.

•	Accolade
Délimitent les blocs d’instruction, positionnées une au dessus de l’autre (alignées verticalement 
If (a  >  b)
{
	//code
}

•	Retraits de ligne
À chaque nouveau bloc d’instruction, il faut intégrer un retrait. En cas de if imbriqués, il y a deux retraits.
Lees retraits sont de 4 caratères.
If (a  >  b)
{
	//code
	//code
	
	If (c >= d)
	{
		//code
	}
}
