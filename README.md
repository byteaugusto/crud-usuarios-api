# 🚀 MinhaPrimeiraApi

![.NET](https://img.shields.io/badge/.NET-ASP.NET%20Core-blue)
![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![License](https://img.shields.io/badge/license-MIT-green)

API REST desenvolvida com **ASP.NET Core** para gerenciamento de usuários, aplicando boas práticas de desenvolvimento backend, arquitetura em camadas e padrões REST.

---

## 🧠 Visão Geral

Este projeto simula uma API real de cadastro de usuários, com foco em:

* Estrutura profissional (Controller + Service)
* Injeção de dependência
* Boas práticas REST
* Organização de código limpa e escalável

---

## ⚙️ Tecnologias Utilizadas

* 💻 C#
* 🌐 ASP.NET Core
* 📄 Swagger (OpenAPI)
* 🔧 .NET 6+
* 🧠 Programação Orientada a Objetos (POO)

---

## 🔥 Funcionalidades

✔ Criar usuário
✔ Listar usuários
✔ Buscar usuário por ID
✔ Atualizar usuário
✔ Remover usuário

---

## 📡 Endpoints da API

| Método | Endpoint          | Descrição            |
| ------ | ----------------- | -------------------- |
| GET    | /api/usuario      | Lista todos usuários |
| GET    | /api/usuario/{id} | Busca usuário por ID |
| POST   | /api/usuario      | Cria novo usuário    |
| PUT    | /api/usuario/{id} | Atualiza usuário     |
| DELETE | /api/usuario/{id} | Remove usuário       |

---

## 🧱 Estrutura do Projeto

```
MinhaPrimeiraApi/
│
├── Controllers/
│   └── UsuarioController.cs
│
├── Services/
│   └── UsuarioService.cs
│
├── Models/
│   └── Usuario.cs
│
├── Program.cs
```

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:

```bash
git clone https://github.com/byteaugusto/crud-usuarios-api.git
```

2. Acesse a pasta:

```bash
cd MinhaPrimeiraApi
```

3. Execute o projeto:

```bash
dotnet run
```

4. Acesse a documentação Swagger:

```
https://localhost:7245/swagger/index.html
```

---

## 📸 Preview da API

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/1f31a0b4-23e6-418f-8f48-10fdaac9f8a0" />

---

## 🎯 Objetivo

Este projeto faz parte da minha evolução como desenvolvedor backend, com foco em construção de APIs robustas e preparação para o mercado de trabalho.

---

## 👨‍💻 Autor

**Matheus Augusto**
💼 Desenvolvedor Back-end em formação
🚀 Focado em C# / .NET

---

## ⭐ Considerações

Se este projeto te ajudou ou chamou atenção, considere deixar uma ⭐ no repositório!
