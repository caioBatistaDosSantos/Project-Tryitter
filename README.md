# Boas Vindas ao Projeto Tryitter!

Este repositório contêm a API de um Blogs e seus testes, desenvolvidos com C# .NET.

---

## <i>Projeto em desenvolvimento...</i>

  - Trello: https://trello.com/c/9tutsbgi/11-link-do-escalidraw-https-excalidrawcom-json6iooox5zdvz4of7xxzyny7vcx0bqpjbjhsoorrjftta
  - Escalidraw: https://excalidraw.com/#json=6IooOx5zDVZ4OF7XXzyny,7vCx0bQpJBJHSoOrRJfTtA

---

## Como rodar:

1. Clone o repositório com o comando:
  - `git clone git@github.com:caioBatistaDosSantos/Project-Tryitter.git`;
    - Entre na pasta do repositório:
      - `cd Project-Tryitter`
2. Suba o banco de dados com o comando:
  - `docker-compose up -d --build`
3. Entre na pasta da API com o comando:
  - `cd Backend/Tryitter.Web`
4. Instale as dependências com o comando:
  - `dotnet restore`
5. Inicie a aplicação com o comando:
  - `dotnet run`
    - *Obs: Este comando será responsável por criar o db e as tabela*