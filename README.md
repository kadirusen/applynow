# ApplyNow

- ApplyNow is job posting application API project. Written with Asp.net Core 3.1 
- Used Entity Framework Core, PostgreSQL, Redis, Docker
- Moq, Nunit and FluentAssertionlibraries used for test projects.
- Swagger is used and initial endpoints.

# Getting Started

# clone this repo

```
git clone https://github.com/kadirusen/applynow.git
```
# Steps For Run the application
## 1.  Docker Compose Build

```
$ cd applynow
$ docker-compose up --build
```

Started containers list;

```
$ docker container ls
```

## 2.For DB migration

```
$ cd ApplyNow.Data
$ dotnet ef migrations add dbinit
$ dotnet ef database update
```
## 3. Project running ports with docker

```
API Project --> http://localhost:5002/swagger/index.html
Redis --> localhost:6379
PostgreSQL --> localhost:5432
```

