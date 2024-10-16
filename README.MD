Axelle Donot & Gaëtan Corso & Kee-Soon Armand

Bataille Navale

[x] Démarrer une partie avec bateau placé aléatoirement

[x] API attaque joueur + IA

[x] faire une seul api pour l'attaque , joueur attaque si tous les bateaux sont coulés alors fin partie retour info front, sinon ia attaque pareil si gagne retour front , sinon retour front avec result attaque ia et user

[x] Généré un id de partie

[ ] toute les données doivent etre validée (anticorruption layer) et la sécurité avec FluentValidation
pour créer un validateur , faire une classe qui hérite de "AbstractValidaton < Model >" dans le constructeur implementer les regles avec ruleFor
Enregistrer le validator en tant que IValidator dans le conteneur de services et l'importer dans les endpoints concernés pour valider le modele avec la méthode validateur

Valider et faire le nécessaire pour le modèlle AttackRequest

[ ] Communication GRPC entre API et Blazor

[ ] Afficher l'historique des coups de la partie

[ ] Utiliser SignalR  pour un mode 2 joueurs

[ ] Pouvoir relancer la partie sans relancer l'app

[ ] Placer ses bateaux manuellement

[ ] Gestion sécurité et user avec Auth0

[ ] faire 3 niveau : facile petite grille ia conteneur  / Moyen petite grille ia atk perimetre / Difficile grande grille ia perimetre
