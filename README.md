Vous trouverez le fichier exécutable ainsi que le fichier de configuration dans le dossier JobOverview\bin\Release

Avant de lancer l'application veuillez effectuer les étapes suivantes : 
  - modifier le paramètre de connection à la base de données en remplaçant l'attribut connectionString dans la balise Add par votre paramètre de connection dans le fichier JobOverview.exe.config
  - si vous voulez importer des taches de production, placer ce fichier dans le dossier principal et nommez le "TachesProd.xml"
  - ouvrer un new query dans SqlServer et éxécuter le script "Création des tables.sql"

En cliquant sur le menu "Logiciels et version", cette application vous permettra d'observer les modules d'un logiciel et de modifier les versions de ce logiciel si ces versions de sont plus référencés.

Le menu "Taches"->"Tache de production" vous permettra d'observer les taches liées à une personnes et une version ainsi que d'ajouter des taches.
Le bouton "Ajouter Tache" vous permettra de d'ajouter plusieurs taches à la suite puis de toutes les enregistrer en une fois

Le menu "Import/Export"->"Import" Vous permettra de chager le fichier "TachesProd.xml".

Le reste de cette application est pour l'instant toujours en développement.
