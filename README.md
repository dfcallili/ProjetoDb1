Projeto Avalia��o Db1 v1.0.0
================
Solu��o desenvolvida no VS 2017 Community contendo todos os Exerc�cios propostos na Avalia��o Db1 utilizando ASP.NET CORE 1.1 nos projetos ConsoleApplication e ASP.NET CORE 2.0 nos porjetos WebApi.

Tecnologias Utilizadas
------------------------
* ASP.NET CORE 1.1 e 2.0
* EF Core
* AngularJS 4
* Twitter Bootstrap
* Code First
* SQL Server 2017.

Padr�es de Projeto utilizados.
------------------------------------------
* Repository Pattern & Generic Repository
* Unit of Work 
* Dependency Injection

Como rodar os Projetos
-----------------------

1. Abrir a solu��o utilizando o Visual Studio 2017 Community. 
2. Compilar a solu��o para que as dep�ndencias sejam restauradas. Caso seja necess�rio pode-se utilizar o "Prompt de Comando do Desenvolvedor para VS 2017" e executar o comando "npm install" para que sejam baixados as depend�ncias.
3. O projeto "Rh.Data.Context" possui as classes respons�veis por gerenciar o Reposit�rio e o Contexto. 
   Nele se encontra o arquivo de Migrations inicial para que a aplica��o "Rh.Application" funcione.
   Portanto antes de executa-la deve-se rodar o comando  "dotnet ef database update"  com o prompt de comando para que a Base de Dados seja gerada.
   Se julgar necess�rio altere a conex�o com o banco de dados presente no arquivo "RhDbContext.cs".
4. O projeto "Rh.Application" possui uma configura��o de conex�o ao banco de dados dentro do arquivo "Setup.cs". Troque esta conex�o para funcionar no seu ambiente local
5. Os projetos "Rh.Application" e "ApplicationGitHub" foram testados utilizando o navegador Chrome.


## Criado por

* [Diego Fontes Callili](https://github.com/dfcallili) - Desenvolvedor
