FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
 
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
 
WORKDIR /app
 
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://+:5001

EXPOSE 5001

ENTRYPOINT ["dotnet","ApplyNow.API.dll", "--port", "5001"]