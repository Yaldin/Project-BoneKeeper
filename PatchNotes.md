Patch Notes v0.1 - 23/02/24

Comecei o projeto seguindo um tutorial de como criar um Metroidvania, meu principal objetivo é aprender noções de C# e me familiarizar com a Unity. Descobri como fazer a movimentação do personagem, criar Tilemaps com colission e tambpem só como cenário de fundo.

Aprendi um pouco também sobre o animator.

També comecei a utilizar o Github para ir atualizando o andamento do projeto, ainda não sei direito como usar, mas parece uma ferramenta interessante para projetos desse estilo.


Patch Notes v0.2 - 24/02/24

Montei o primeiro .exe e mandei para meus amigos testarem, ainda está bem no início, fiz isso para aprender a compilar os arquivos para conseguir mandar para eles.

O cenário está começando a tomar forma, montei a parte inicial que é o cemitério e também um pouco da próxima parte.

Montando o cenário tive muitos problemas com o Collider2D, no tutorial mostrava para criar um box e circle, mas percebi que usar capsule dá muito menos bug e travamentos nas plataformas.

Patch Notes v0.3 - 26/02/24

Resolvi abandonar o tutorial que estava seguindo pois ele não estava completo, aprendi várias coisas, algumas noções de OOP. Portanto achei um novo tutorial mais completo e com as ideias que estava querendo para o meu game.

Removi os scripts da Unity e então reescrevi tudo desde o início, fazendo isso várias coisas do código já ficaram muito mais claras e estou entendendo melhor a lógica de como funciona essa parte da programação em C# na Unity.

Patch Notes v0.4 - 01/03/24

Ainda estou tendo bastante dificuldade de entender como funciona o Animator, mas consegui resolver a movimentação esquerda e direita, a animação do pulo ainda não está completa.

Agora temos como pegar itens do chão, como a primeira espada que habilita ao personagem conseguir atacar, mais uma vez a animação não está completa pois trava logo depois de utilizar o ataque.


Patch Notes v0.5 - 04/03/24

Adicionado o sistema de inventário, agora os itens que o jogador pegar irão ficar com ele. A princípio está em forma de lista, foi criado somente dois tipos de itens, na verdade as duas chaves para conseguir entrar no primeiro e segundo chefe.


Patch Notes v0.6 - 10/03/24

Agora já conseguimos adicionar uma porta que para abrir precisamos ter o pergaminho(itens) para conseguir abri-lá. Está funcionando corretamente, foi feito um script para as portas, assim dá para copiar o modelo e utilizar outras chaves(itens) para abrir cada uma delas. Tem um sprite para a porta fechada e também outro quando ela está aberta, foi modificado a ordem das camadas para que o personagem fique na posição certa ao passar pela porta aberta.

Foi criado também um sistema de uso de poções, que cura HP, MP e também uma elixir que cura as duas(HP e MP). É possível agora através do botão do meio do mouse usar uma poção mais rapidamente, que no caso vai ser possível escolher qual poção utilizar nesse "kick slot" assim que for implementado o menu.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PS.:  A animação do personagem ainda continua apresentando erros, ele não está voltando para a posição "idle" quando a gente pula e também a animação de "atack" está congelando no final da animação. Pesquisar como fazer para arrumar esses erros.

