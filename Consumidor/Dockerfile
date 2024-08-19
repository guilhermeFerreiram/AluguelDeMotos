# Use a base image para o .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Use a imagem do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo .csproj e restaure as dependências
COPY ["Consumidor.csproj", "./"]
RUN dotnet restore "./Consumidor.csproj"

# Copie todos os arquivos do projeto e compile
COPY . .
RUN dotnet build "Consumidor.csproj" -c Release -o /app/build

# Publique a aplicação
FROM build AS publish
RUN dotnet publish "Consumidor.csproj" -c Release -o /app/publish

# Use a imagem base para a execução da aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Define o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "Consumidor.dll"]
