# MinimalAPI em ASP.NET com SQL Server e EF Core

* Aplicação MinimalAPI em C#/ASP.NET com integração SQL Server usando o Entity Framework Core. 
* A aplicação permite realizar operações CRUD (Create, Read, Update, Delete) em um banco de dados SQL Server.

## Demonstração

Insira um gif ou um link de alguma demonstração


## Requisitos

→ Para executar este projeto, você precisará dos seguintes requisitos:

  * Visual Studio ou Visual Studio Code (ou qualquer ambiente de desenvolvimento C#);
  
  * .NET 6 SDK (ou versão superior);
  
  * SQL Server instalado e configurado;

  * Pacotes NuGet do Entity Framework Core.


## Configuração

→ Siga estas etapas para configurar o projeto:

1. Clone este repositório em sua máquina local:
    

    `git clone https://github.com/seu-usuario/minimalapi-sql-server.git`

2. Abra o projeto em seu ambiente de desenvolvimento.

3. Configure a conexão com o banco de dados SQL Server no arquivo appsettings.json.

    `"ConnectionStrings": {
    'DefaultConnection;: "SUA_CONNECTION_STRING_AQUI"
    }`

4. No terminal, navegue até o diretório do projeto e execute as migrações do Entity Framework para criar o banco de dados:

    `dotnet ef database update`

➤ Agora, você está pronto para executar a aplicação! 🥳👍🏻


## Uso da Aplicação

→ Este App MinimalAPI oferece endpoints para realizar operações CRUD em uma entidade simples, como "Livro". Os endpoints incluem:

  * GET /api/livros: Retorna todos os livros.
  * GET /api/livro/{id}: Retorna um livro específico por ID.
    
  * POST /api/livro: Cria um novo livro.
    
  * PUT /api/livro/{id}: Atualiza um livro existente por ID.
  
  * DELETE /api/livro/{id}: Exclui um livro por ID.

➤ Você pode usar um cliente REST como o Postman ou curl para interagir com a API.


## Documentação Swagger

→ Esta API também é documentada usando o Swagger, o que facilita o teste e a exploração da API. Você pode acessar a documentação Swagger da seguinte maneira:

1. Inicie a aplicação.

2. Abra um navegador da web.

3. Acesse a URL `https://localhost:5001/swagger/index.html` (ou a URL onde a API está sendo executada).

A documentação Swagger fornecerá informações detalhadas sobre os endpoints disponíveis e permitirá que você execute solicitações diretamente na interface Swagger.

## Licença

→ Este projeto é licenciado sob a Licença MIT - consulte o arquivo LICENSE para obter detalhes.



