
# Central de Erros ErrorCenterCodenation

## Objetivo

Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

A arquitetura do projeto é formada por:

## Backend - API

-   criar _endpoints_ para serem usados pelo frontend da aplicação
-   criar um _endpoint_ que será usado para gravar os logs de erro em um banco de dados relacional
-   a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

## Informações adicionais

### Tecnolgias utilizadas no desenvolvimento

- C# .NET Core 3.1
- Entity Framework Core 3.1
- AutoMapper 
- Swagger
- Azure SQL Database
- JSON Web Tokens (JWT)
- Docker
- Heroku

### Ferramentas utilizadas no desenvolvimento

- Jetbrains Rider IDE
- Visual Studio Code


### Rotas

- Error Controller - Endpoints para log de errors

	- **GET**​ /api​/Errors - Lista todos os erros registrados.

	- **GET**​ /api​/Errors​/{errorId} - Retorna um erro específico, através de seu ID do erro.

	- **GET​** /api​/Errors​/level​/{levelId} - Retorna todos os logs que possuem um nível de erro específico, através do ID do nível.
	
	- **GET**​ /api​/Errors​/env​/{envId} - Retorna todos os logs que possuem um ambiente de erro específico, através do ID do ambiente.

	- **GET**​ /api​/Errors​/env​/searchField​/searchString - Busca filtrada através de um ambiente, campo a ser buscado e termo a ser buscado.
	
	- **POST** ​/api​/Errors - Registar um novo erro.
	
	- **PUT**​ /api​/Errors​/{errorId} - Atualiza informações de um erro específico, através de seu ID do erro.

	- **DELETE** ​/api​/Errors​/{errorId} - Remove um erro específico, através de seu ID do erro.
	
	


- Level Controller

	- **GET**​ /api​/Levels - Lista todos os níveis de erro registrados.
	
	- **GET​** /api​/Levels​/{levelId} -  Retorna um nível de erro específico, através de seu ID do nível.

	- **POST** ​/api​/Levels - Registra um novo nível de erro.

	- **DELETE** ​/api​/Levels​/{levelId} - Remove um nível de erro específico, através de seu ID do nível.
	

- Environment Controller

	 - **GET​** /api​/Environments - Lista todos os ambientes de erro registrados.

	- **GET**​ /api​/Environments​/{envId} - Retorna um ambiente de erro específico, através de seu ID do ambiente.

	-  **POST** ​/api​/Environments - Registra um novo ambiente para erro.

	- **DELETE** ​/api​/Environments​/{envId} - Remove um ambiente de erro específico, através de seu ID do ambiente.
	
- User Controller

	- **GET**​ /api​/Users - Lista todos os usuários registrados.

	- **GET**​ /api​/Users​/{id} - Retorna um usuário específico, através do ID do usuário.
	
	- **POST**​ /api​/Users​/authenticate - Autentica um usuário, através de nome de usuário e senha.

	- **POST​** /api​/Users​/register - Registra um novo usuário.

	- **PUT​** /api​/Users​/{id} - Atualiza as informações de um usuário específico, através do ID do usuário.

	- **DELETE**​ /api​/Users​/{id} - Remove um usuário, através do ID do usuário.
	
	
## Deploy

[Backend Heroku](https://error-center-rest-api.herokuapp.com/swagger/index.html)

## Vídeo Demonstração e slides

(https://www.youtube.com/watch?v=ZDNxD7Zj6YU&feature=youtu.be)

(https://docs.google.com/presentation/d/1i8qYTvFoN74oENO8GrOURar0Gn7kp4tnO3RWEuN0X3A/edit?usp=sharing)

P.S: Desculpem se o vídeo ficou corrido. Espero que tenha sido compreensível. Qualquer dúvida, à disposição  ^^


