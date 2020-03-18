# Easynvest
Projeto onde o objetivo e ler os investimentos de um usuário, aplicar regras de cálculos, e dar informações sobre os investimentos, como valor de resgate data de vencimento, etc.

Para acessar o retorno da api (ja vem como página inicial):  /api/investimentos
Para acessar o HealthCheck: /health

Detalhes e linha de pensamento:


O projeto foi desenvolvido voltada ao domínio, isolando as regras de negócio da aplicação nesta camada.
Foi utilizado também algumas interfaces para melhor manipulação dos objetos, algo legal de se notar, seria a interface IInvestimento, com ela conseguimos uma flexibilidade muito legal de poder adicionar outros tipos de investimentos, tendo como base a implementação desta interface, pois os cálculos e retornos da API são baseados na abstração que essa interface nos dá.

Os testes são simples, um protegendo a regra do domínio sobre o cálculo de resgate, usando dados previamente conhecidos para bater o resultado, e um teste na camada de comunicação com a “API” (mocky.io), na qual testamos a comunicação externa.
Na questão de cache, foi implementado o MemoryCache, porem dependendo do tamanho da escalabilidade que o projeto possa ter no futuro a melhor escolha seria também fazer este cacheamento em um banco NoSQL (mongoDB) ou no Redis como cache distribuído.
Ainda sobre o cache foi criado uma classe utilitária para poder pegar o tempo restante até meia noite para ser inserido na expiração do cache.
A camada de cache foi implementada diretamente na API pensando em um ponto de flexibilidade, por exemplo, se um App mobile, ou canal diferente quisesse utilizar o serviço e o mesmo já tivesse ou precisasse de outra plataforma de cache como a API e desacoplada de todo o resto o funcionamento do sistema seria o mesmo e passaríamos a responsabilidade de cachear as informações para o consumidor.
Isolei toda a orquestração na camada de servisse (possibilitando vários canais para consumo), e toda a regra de negócio no domínio, assim facilitando a manutenção de qualquer ponto do sistema.
Algumas informações como a URL das APIs que retornam os dados de investimento e o horário de expiração de cache, ficariam melhor em arquivos de configuração ou até mesmo em um banco de dados, facilitando a manutenção caso os valores mudem, não precisando fazer deploy de código. Mas por questão de agilidade e praticidade no teste deixei diretamente no código mas fica esta observação.

Coloquei comentarios em locais importantes para melhor identificação do codigo, pois além de um codigo bonito devemos pensar no proximo dev que vai dar manutenção facilitando o trabalho de todo mundo.







