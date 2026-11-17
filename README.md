# Portfolio Web App · ASP.NET Core MVC

A dynamic web application where students, developers or designers can present their professional profile online: skills, projects, experiences and contact details, all managed from a private admin area.

Academic project built in C# with ASP.NET Core MVC, following the MVC pattern with a layered architecture (controllers → services → repositories → Entity Framework Core).

## Features

### Public area (visitors)
- **Home page** listing the available portfolios
- **Portfolio pages** with profile photo, bio and social links (LinkedIn, GitHub)
- **Projects** shown as Bootstrap cards (title, description, image, link)
- **Skills** with a level: Beginner, Intermediate or Expert
- **Experiences** timeline
- **Contact form**: visitors can send a message to the portfolio owner

### Admin area (after login)
- Add, edit and delete **skills**
- Add, edit and delete **projects**
- Manage **experiences**
- Read the **messages** received through the contact form
- Edit **personal information**: name, bio, photo and social links

### Security
- Login with session-based authentication; the admin area is only reachable when signed in
- Server-side and client-side form validation (Data Annotations + jQuery Validation)
- Protection against SQL injection through Entity Framework Core (parameterized queries)

## Tech stack

| | |
|---|---|
| Language | C# |
| Framework | ASP.NET Core MVC, Razor views |
| Data access | Entity Framework Core (code-first, migrations) |
| Database | SQL Server (LocalDB for development) |
| UI | Bootstrap 5, responsive design |
| IDE | Visual Studio Community |

## Data model

| Entity | Main fields |
|---|---|
| **Personne** | Name, email, password, photo, bio, LinkedIn, GitHub |
| **Competence** | Name, level (Beginner / Intermediate / Expert) |
| **Projet** | Title, description, image URL, link, creation date |
| **Experience** | Professional and academic experiences |
| **Message** | Sender name, email, content, date sent |

## Architecture

```
Web_IB/
├── Controllers/   routes and request handling (Account, Portfolio, Projects, Skills, Experiences, Messages, Profil)
├── Services/      business logic (auth, profiles, portfolio, explore, messages)
├── Repository/    data access, one repository per entity
├── Entities/      Personne, Projet, Competence, Experience, Message
├── Models/        view models for the Razor pages
├── Data/          MyDbContextPortfolio (EF Core DbContext)
├── Migrations/    database schema history
└── Views/         Razor pages styled with Bootstrap
```

## To Run it locally

**Requirements:** Visual Studio 2022 with the *ASP.NET and web development* workload (includes SQL Server LocalDB).



