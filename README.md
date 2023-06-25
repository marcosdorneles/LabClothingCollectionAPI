# LabClothingCollectionAPI

O LabClothingCollectionAPI é um software desenvolvido pela LABFashion LTDA que permite o gerenciamento de coleções e modelos de vestuários criados por determinados usuários da equipe. O sistema foi desenvolvido utilizando a plataforma .NET e o Entity Framework para criar uma API REST. O banco de dados utilizado é o SQL Server. A API é documentada utilizando o Swagger.

# Modelagem de dados:
bash![modelagem](https://github.com/marcosdorneles/LabClothingCollectionAPI/assets/95898769/65ff2012-e951-483a-aa44-d2febc977c50)


Funcionalidades:
Cadastro, atualização, listagem e exclusão de usuários.
Cadastro, atualização, listagem e exclusão de coleções.
Cadastro, atualização, listagem e exclusão de modelos de vestuários.
Relacionamento entre usuários, coleções e modelos.
Atributos detalhados para usuários, coleções e modelos.

# Requisitos de Sistema
.NET Framework - versão 7.0.32

Entity Framework - versão 7.0.5

SQL Server

# Instalação
Clone o repositório do LabClothingCollectionAPI:

```
git clone https://github.com/marcosdorneles/LabClothingCollectionAPI.git
```	

Abra o projeto utilizando a IDE de sua preferência (por exemplo, Visual Studio).

Restaure os pacotes NuGet utilizados pelo projeto.

Configure a conexão com o banco de dados SQL Server no arquivo ```Program.cs```.

```csharp
 builder.Services.AddDbContext<Repository>(options => options.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
"));

```




Execute o projeto.

```csharp 
dotnet run
```

Utilização
Após a instalação e execução do projeto, você pode utilizar as seguintes rotas da API:

# Usuários
GET - /api/users - Retorna todos os usuários cadastrados.

GET - /api/users/{id} - Retorna os detalhes do usuário com o ID especificado.

POST - /api/users - Cria um novo usuário com os dados fornecidos.

PUT - /api/users/{id} - Atualiza os dados do usuário com o ID especificado.

DELETE - /api/users/{id} - Exclui o usuário com o ID especificado.

# Coleções
GET - /api/collections - Retorna todas as coleções cadastradas.

GET - /api/collections/{id} - Retorna os detalhes da coleção com o ID especificado.

POST - /api/collections - Cria uma nova coleção com os dados fornecidos.

PUT - /api/collections/{id} - Atualiza os dados da coleção com o ID especificado.

DELETE - /api/collections/{id} - Exclui a coleção com o ID especificado.

# Modelos
GET - /api/models - Retorna todos os modelos cadastrados.

GET - /api/models/{id} - Retorna os detalhes do modelo com o ID especificado.

POST - /api/models - Cria um novo modelo com os dados fornecidos.

PUT - /api/models/{id} - Atualiza os dados do modelo com o ID especificado.

DELETE - /api/models/{id} - Exclui o modelo com o ID especificado.

# Metodologia de Desenvolvimento
O desenvolvimento do LabClothingCollectionAPI seguiu a metodologia ágil SCRUM, com a divisão de tarefas em quadros Kanban. Os quadros utilizados foram:

Backlog: Tarefas a serem realizadas no futuro.
To-do: Tarefas a serem realizadas na iteração atual.
Doing: Tarefas em andamento.
Blocked: Tarefas bloqueadas por algum motivo.
Review: Tarefas concluídas aguardando revisão.
Done: Tarefas concluídas e revisadas.
