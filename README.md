# PropertySystem API

## Descrição
A **PropertySystem API** permite gerenciar o cadastro de imóveis de forma simples e eficaz. Com esta API, os usuários podem criar, editar, listar e excluir imóveis.

## Tecnologias Usadas
- ASP.NET Core 8
- Entity Framework Core
- JWT para autenticação
- SqlInMemory como banco de dados. Há a possibilidade de usar o SQL Server com banco de dados, basta ir na classe ConfigureDataBase.cs e descomentar o código e comentar o código atual, além de configurar a connection strings no arquivo appsettings.json, e rodar as migrations.

## Pré-requisitos
- [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0)

## Instalação
1. Clone o repositório:
   git clone https://github.com/allanlourenco/PropertySystemProject.git
2. Navegue até o diretório do projeto:
   cd PropertySystemProject\PropertySystemProject.Application
3. Restaure os pacotes(caso necessário):
   dotnet restore

## Execução
Para executar, basta apenas dar o comando dotnet run.
A api estará disponível na url https://localhost:7262/.
Para rodar os endpoints de cadastro, alteração e remoção de imóveis, o usuário deve estar autenticado.
Para se autenticar no sistema, o usuário deve criar um usuário através do endpoint de registro, e após o usuário criado, deve se autenticar atraves do endpoint login.

## Endpoints
1. Login: Atráves do usuário e senha, retorna um token de autenticação.
2. Register: Insere um novo usuário
3. Get/Properties: Trás a lista de imóveis cadastrados
4. Get/Properties/Id: Trás o imóvel cadastrado por Id
5. Post/Properties: Cadastra um novo imóvel
6. Put/Properties/Id: Altera o imóvel cadastrado por Id
7. Delete/Properties/Id: Remove o imóvel cadastrado por Id 

## Contato
Autor: Allan Lourenço
Email: allan.lourenco@outlook.com
