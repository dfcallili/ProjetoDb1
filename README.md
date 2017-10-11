Projeto Avaliação Db1 v1.0.0
================
Solução desenvolvida no VS 2017 Community contendo todos os Exercícios propostos na Avaliação Db1 utilizando ASP.NET CORE 1.1 nos projetos ConsoleApplication e ASP.NET CORE 2.0 nos porjetos WebApi.

Tecnologias Utilizadas
------------------------
* ASP.NET CORE 1.1 e 2.0
* EF Core
* AngularJS 4
* Twitter Bootstrap
* Code First
* SQL Server 2017.

Padrões de Projeto utilizados.
------------------------------------------
* Repository Pattern & Generic Repository
* Unit of Work 
* Dependency Injection

Como rodar os Projetos
-----------------------

1. Abrir a solução utilizando o Visual Studio 2017 Community. 
2. Compilar a solução para que as depêndencias sejam restauradas. Caso seja necessário pode-se utilizar o "Prompt de Comando do Desenvolvedor para VS 2017" e executar o comando "npm install" para que sejam baixados as dependências.
3. O projeto "Rh.Data.Context" possui as classes responsáveis por gerenciar o Repositório e o Contexto. 
   Nele se encontra o arquivo de Migrations inicial para que a aplicação "Rh.Application" funcione.
   Portanto antes de executa-la deve-se rodar o comando  "dotnet ef database update"  com o prompt de comando para que a Base de Dados seja gerada.
   Se julgar necessário altere a conexão com o banco de dados presente no arquivo "RhDbContext.cs".
4. O projeto "Rh.Application" possui uma configuração de conexão ao banco de dados dentro do arquivo "Setup.cs". Troque esta conexão para funcionar no seu ambiente local
5. Os projetos "Rh.Application" e "ApplicationGitHub" foram testados utilizando o navegador Chrome.


## Criado por

* [Diego Fontes Callili](https://github.com/dfcallili) - Desenvolvedor
