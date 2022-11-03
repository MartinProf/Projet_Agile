#  **Projet de session `Git Agile`**

## Travail présenté à: **Sylvain Labranche**
>##### Travail réalisé par ***Martin Vézina*** ***Martin Forget*** ***Anthony Menard-Boucher*** ***Guillaume Tremblay*** ***Sebastian Toledo***

![Logo_Rosemont](/images/logo_college_rosemontReduit.png)

# **Présentation du Sprint 1**


## **Mise en contexte**
>Le but du cours est de vous faire développer une application informatique du début à la fin, soit de la rencontre
client à la livraison de l’applications et au support technique.
Le sprint 1 consiste en la première demande du client.
À noter que la mise en situation est facultative : vous pouvez me présenter un projet de plus longue haleine qui
s’étalera sur toute la session et que vous diviserez en trois sprints. Nous prendrons rendez-vous ensemble pour
confirmer le projet.


### **Demande du client 1**
>L’application à développer est un logiciel qui effectuera la validation du temps travaillé par des employés dans le
respect des règles de l’entreprise.

>Dans l’organisation du client, chaque employé doit remplir une feuille de temps hebdomadaire. Les employés doivent
suivre plusieurs règles par rapport à leur temps travaillé qui sont dictées par l’entreprise. En fait, il y a tellement
de règles à valider que les responsables de l’entreprise n’arrivent plus à s’y retrouver. Ils ont besoin d’un logiciel qui
leur permettra de valider les règles de l’entreprise et qui génèrera les messages d’erreurs appropriés si une feuille de
temps viole les règles.

>Le logiciel possèdera évenutellement une interface utilisateur, mais ce n’est pas dans les priorités de l’entreprise
(ça pourrait le devenir dans deux semaines...). Le contrat ne consiste donc qu’au développement du "back-end" de
l’application.


### **Fonctionnalités**

_Voir le fichier FeuilleTempExemple.json pour un exemple de fichier d’entrée._

_Voir le fichier sortieExemple.json pour le fichier de sortie correspondant._

>Le programme devra prendre ce fichier comme argument lors de l’exécution du logiciel dans une console. Le fichier
où devra être placé le résultat devra également être spécifié à la console. Exemple :
java -jar TimeSheet.jar inputfile.json result.json

**Voici ce que vous devez savoir en premier lieu :**

1.Les codes de projet supérieurs à 900 sont des codes de télétravail.
2.Si l’employé ne travaille pas durant une journée, elle est présente dans la feuille de temps mais vide, comme
jours et weekend1 dans le fichier d’exemple.
3.Il est possible qu’un employé travaille la fin de semaine.
4.Un employé dont le numéro est inférieur à 1000 est un employé de l’administration.
5.Un employé dont le numéro est supérieur ou égal à 1000 est un employé normal.
6.jour1 à jour5 correspondent au lundi à vendredi ; weekend1 correspond à samedi et weekend2 correspond à
dimanche.

**Voici les règles que vous devez vérifier :**

1.Les employés de l’administration doivent travailler au moins 36 heures au bureau par semaine (excluant le
télétravail).
2.Les employés normaux doivent travailler au moins 38 heures au bureau par semaine (excluant le télétravail).
3.Aucun employé n’a le droit de passer plus de 43 heures au bureau.
4.Les employés de l’administration ne doivent pas faire plus de 10 heures de télétravail par semaine.
5.Les employés normaux peuvent faire autant de télétravail qu’ils le souhaitent.
6.Les employés normaux doivent faire un minimum quotidien de 6 heures au bureau pour les jours ouvrables
(lundi au vendredi). Les employés doivent travailler même les journées de congé férié.
7.Les employés de l’administration doivent faire un minimum quotidien de 4 heures au bureau pour les jours
ouvrables (lundi au vendredi). Les employés doivent travailler même les journées de congé férié.

_Le client s’attend à ce qu’un fichier JSON montre le fonctionnement de chacune des règles._

### **Contraintes technologiques**

1.Les fichiers d’entrées et de sorties doivent être des documents JSON.
2.Les sources doivent être entreposées dans un dépôt GIT sous github.

