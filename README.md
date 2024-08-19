# <h1 align="center">Aluguel de Motos com ASP.NET Core MVC</h1>

<p align="center">
  <a href="https://github.com/guilhermeFerreiram/AluguelDeMotos/blob/master/LICENSE.txt"><img src="https://img.shields.io/github/license/guilhermeFerreiram/Tamagotchi?Color=323330&style=for-the-badge"/></a>  
  <img src="https://img.shields.io/static/v1?label=Visual+Studio&message=community+2022&color=5C2D91&style=for-the-badge&logo=VisualStudio"/> 
</p>

<br>
<h2 align="center">Tópicos</h2>

<p align="center">
  <a href="#objective">:dart: Descrição</a> &bull;
  <a href="#techs">:pushpin: Tecnologias</a> &bull;
  <a href="#executar">:open_file_folder: Como executar o aplicativo</a> &bull;
  <a href="#testar">:open_file_folder: Como testar o aplicativo</a> &bull;
  <a href="#problemas">:open_file_folder: Problemas</a> &bull;
  <a href="#author">:bust_in_silhouette: Autor</a> &bull; 
  <a href="#license">:page_with_curl: Licença</a>
</p>

<br>
<h2 id="objective" align="center">:dart: Descrição</h2>

<p align="center">Este projeto tem o objetivo de gerenciar aluguel de motos e entregadores. A aplicação foi desenvolvida com o framework ASP.NET Core, com modelagem MVC.</p>

<br>
<h2 id="techs" align="center">:pushpin: Tecnologias</h2>

<p align="center">
  C# &bull;
  ASP.NET Core MVC &bull;
  Login de usuários (sessão HTTP) &bull;
  Requisições HTTP &bull;
  Serialização de objetos JSON &bull;
  CRUD &bull;
  JQuery DataTable &bull;
  Bootsrap &bull;
  PostregreSQL &bull;
  Entity Framework &bull;
  Docker
</p>

<br>
<h2 id="executar" align="center">:open_file_folder: Como executar o aplicativo</h2>

<h3 align="center">Clone o repositório</h3>

<p align="center">Para clonar o repositório, certifique-se de possuir o <kbd><a href="https://git-scm.com/downloads">Git</a></kbd> instalado em seu em seu computador...</p>

``` bash
# Clone todo o repositório
$ git clone https://github.com/guilhermeFerreiram/ControleDeContatosMVC.git
```
<h3 align="center">Docker</h3>

<p align="center">Dentro do diretório que o arquivo docker-compose.yml está contido, abra o terminal e execute o seguinte comando:</p>

```
docker-compose up
```
<h3 align="center">Acessando o app</h3>

<p align="center">Em seu navegador, digite o seguinte endereço: <strong>http://localhost:5000/</strong></p>

<h3 align="center">Atenção</h3>

<p align="center">O aplicativo cria por conta própria um perfil administrador com email <strong>"admin@example.com"</strong> e senha <strong>"1234"</strong>. No primeiro run do projeto, você pode logar como administrador utilizando este login.</p>

<h2 id="testar" align="center">:open_file_folder: Como testar o aplicativo</h2>

<p align="center">Dentre as funcionalidades da aplicação, as principais são:</p>

- Existem dois tipos de usuários: admin e entregador.
- Existe restrição de acesso a páginas específicas para cada tipo de usuário.
- O usuário admin pode cadastrar uma nova moto.
  - Os dados obrigatórios da moto são Identificador, Ano, Modelo e Placa
  - A placa é um dado único e não pode se repetir.
  - Quando a moto for cadastrada a aplicação deverá gerar um evento de moto cadastrada
    - A notificação deverá ser publicada por mensageria.
    - Um consumidor será notificado quando o ano da moto for "2024". (Verifique a notificação no mesmo terminal que iniciou o Docker)
``` bash
# A notificação aparecerá dessa forma no console
consumidor-1        |  [x] Recebida: Nova moto 2024 cadastrada!
```
- O usuário admin pode consultar as motos existentes na plataforma e consegue filtrar pela placa, ano, modelo e situação de aluguel.
- O usuário admin pode modificar uma moto alterando qualquer dado que foi cadastrado indevidamente
- O usuário admin pode remover uma moto que foi cadastrada incorretamente, desde que não tenha registro de locação.
- O usuário entregador pode se cadastrar na plataforma para alugar motos.
    - Os dados do entregador são( identificador, nome, cnpj, data de nascimento, número da CNHh, tipo da CNH)
    - Os tipos de cnh válidos são A, B ou ambas A+B.
    - O cnpj é único e não pode se repetir.
    - O número da CNH é único e não pode se repetir.
- O usuário entregador pode alugar uma moto por um período.
    - Os planos disponíveis para locação são:
        - 7 dias com um custo de R$30,00 por dia
        - 15 dias com um custo de R$28,00 por dia
        - 30 dias com um custo de R$22,00 por dia
        - 45 dias com um custo de R$20,00 por dia
        - 50 dias com um custo de R$18,00 por dia
    - A locação obrigatóriamente tem uma data de inicio e uma data de término e outra data de previsão de término.
    - O inicio da locação obrigatóriamente é o primeiro dia após a data de criação.
    - Somente entregadores habilitados na categoria A ou AB podem efetuar uma locação
- O usuário entregador pode informar a data que irá devolver a moto e consultar o valor total da locação.
    - Quando a data informada for inferior a data prevista do término, será cobrado o valor das diárias e uma multa adicional
        - Para plano de 7 dias o valor da multa é de 20% sobre o valor das diárias não efetivadas.
        - Para plano de 15 dias o valor da multa é de 40% sobre o valor das diárias não efetivadas.
    - Quando a data informada for superior a data prevista do término, será cobrado um valor adicional de R$50,00 por diária adicional.
    
<br>

<h2 id="testar" align="problemas">:open_file_folder: Problemas</h2>

<p align="center">
  Ao iniciar o conteiner do projeto 'Consumidor', algumas excessões são geradas sinalizando falhas de conexão com RabbitMQ. A solução imediata foi incluir um comando no arquivo <strong>docker-compose.yml</strong> para dar restart no projeto sempre que fechar.
  Outro problema, também relacionado ao consumidor, é a visibilidade das mensagens de confirmação de recebimento. As mensagens são escritas no console onde você rodou o comando <strong>docker-compose up</strong>, junto com as mensagens do Entity Framework da aplicação web.
</p>


<h2 align="center" id="author">:bust_in_silhouette: Autor</h2>

<p align="center">:pencil: by <a href="https://github.com/guilhermeFerreiram">guilhermeFerreiram</a></p>
<p align="center"><a href="https://www.linkedin.com/in/guilherme-f-souza/"><img src="https://img.shields.io/static/v1?label=+&message=Guilherme+Ferreira&color=0A66C2&style=flat&logo=linkedin&logoColor=white"/></a> <img src="https://img.shields.io/static/v1?label=+&message=guil.ferreiram@gmail.com&color=EA4335&style=flat&logo=gmail&logoColor=white"/></p>

<br>
<h2 align="center" id="license">:page_with_curl: Licença</h2>

<p align="center"><a href="https://github.com/guilhermeFerreiram/AluguelDeMotos/blob/master/LICENSE.txt">MIT License</a> &nbsp;&bull;&nbsp; &copy; guilhermeFerreiram</p>
 
