# Backend API - Análise de Fazendas

Este é o backend do projeto de análise de fazendas, desenvolvido em C# utilizando ASP.NET Core. Ele oferece uma API REST para gerenciar usuários, fazendas e análises, com autenticação via token e integração com o frontend React.

## 🛠 Tecnologias Utilizadas

- ASP.NET Core 6
- Entity Framework Core
- PostgreSQL (ou outro banco compatível)
- JWT (autenticação)
- AutoMapper
- Swagger (para documentação)
- NuGet (gerenciador de pacotes)

## 📁 Estrutura do Projeto

- **Controllers/** - Lida com as requisições HTTP (UserController, FarmController, AnalysisController)
- **Models/** - Contém os modelos de dados
- **DTOs/** - Objetos de transferência de dados entre frontend e backend
- **Services/** - Camada de lógica de negócio
- **Repositories/** - Comunicação com o banco de dados
- **Configurations/** - Configurações de serviços, autenticação, etc.
- **Program.cs / Startup.cs** - Arquivos principais de configuração do projeto

## 🔐 Autenticação

O sistema utiliza **JWT** para autenticação de usuários. O token é gerado no login e deve ser enviado no cabeçalho das requisições protegidas.

## 🔄 Funcionalidades

### Usuários
- `POST /api/users` – Criar novo usuário
- (GET implementado no backend, mas não utilizado no frontend)

### Fazendas
- `POST /api/farms` – Criar nova fazenda
- `GET /api/farms` – Buscar fazendas pelo ID do usuário (extraído do token)
- `PUT /api/farms/{id}` – Atualizar fazenda (com ID da fazenda e usuário)
- `DELETE /api/farms/{id}` – Deletar fazenda

### Análises
- `POST /api/analysis` – Criar nova análise
- `GET /api/analysis/{farmId}` – Buscar análises de uma fazenda
- `PUT /api/analysis/{id}` – Atualizar análise

## ⚠️ Dificuldades e Aprendizados

- Projeto desenvolvido com tempo limitado devido à rotina intensa.
- Desafio com linguagem C# e adaptação ao Visual Studio e NuGet.
- Falta de planejamento inicial dificultou a padronização e integração entre frontend e backend.
- Uso do Git em equipe evidenciou a importância de um fluxo claro de versionamento.
- Experiência muito positiva e de alto aprendizado.

## 📦 Como executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/backend-farm-analysis.git
2. Instale os pacotes NuGet:
   ```bash
    dotnet restore
3. Configure a string de conexão no appsettings.json
4. Aplique as migrations:
   ```bash
    dotnet ef database update
5. Rode a aplicação
   ```bash
   dotnet run
