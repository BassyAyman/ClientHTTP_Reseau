# ClientHTTP_Reseau

## By Ayman Bassy

### Note relative au projet

Dans le front les données sont directement afficher, je dois ajouter un parsing pour bien afficher les elements.
Si quand on lance le serveur on tape directement dans l'url http://localhost:9000/ ensuite question1 ou question2 ou question3
alors on voit afficher correctement la statistique desirer.

### Justification

Dans la question 3, je recuperer non pas l'age car sur la question 2 on la deja, mais le content type et lenght, je suis curieux de voir si la taille des information et
la meme, et de toute evidence non, mais pour savoir en general si ya une tres grosse difference entre le plus petit et le plus grand des taille de donnée renvoyer en byte.

Pour le content type je compte les differents content type pour voir les differents type qui sont renvoyer et a quelle frequence, etant sur le meme serveur a savoir wikipedia, ce serai drole de voir qu'il ya des type de content different alors que dans tout les cas c'est le meme affichage.

### lancement

dans le dossier front ya le code du front qui envoie des requetes http get au serveur qui ecoute localement sur le port 9000. 3 different endpoints, question 1, 2 et 3 en fonction de ce que l'on veut.

Je suis parti du principe qu'il fallait un boutton pour lancer une action, c'est aussi plus simple a faire

Seul probleme je dirai dans l'etat c'est que les données sont afficher mais mal, dans le sens ou elle ne sont pas si facile a lire, juste a parser en json
