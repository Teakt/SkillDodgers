# SkillDodger

 TRAINing est un jeu que j’ai développé sous Unity(2D) et codé en C#, le but était de créer un jeu mobile de duel entre deux joueurs mais aussi pour m’entrainer sur Unity, j ’ai réalisé le design, et la programmation, mais les assets pris sur le web.

 Le projet n’est pas fini et assez loin de la version voulu. Mais le résultat actuel est intéressant à monter.


# But du jeu

[![pipeline status](https://gitlab.com/Gunteak/SkillDodger/badges/master/pipeline.svg)](https://gitlab.com/Gunteak/SkillDodger/commits/master)
 Nous contrôlons un personnage avec les flèches directionnelles, la caméra le suit peux importe où il va, il peux ramasser des bonus qui l’accélère, il doit esquiver des projectiles que lui tire les ennemis.
 Nous passerons les petits détails, la plus intéressante implémentation à montrer est la génération de map qui a été codé.
 En effet, peu importe la direction que prendra le personnage, la carte se générera sous ses pieds.


## Infinite Map Generator
 A chaque fois que le joueur dépasse une certaine distance sur l’unité de terrain sur laquelle il est, le script va checker tous ce qui il y a autour de l’unite de terrain (terrain déjà present ou pas), et générer un terrain avec des ennemis, bonus, etc …  


