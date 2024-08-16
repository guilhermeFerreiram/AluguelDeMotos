# Imagem base do .NET SDK para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Diretório de trabalho dentro do contêiner
WORKDIR /src

# Copiar o arquivo .csproj para o diretório de trabalho
COPY ["AluguelDeMotos.csproj", "./"]

# Restaurar dependências do projeto
RUN dotnet restore "AluguelDeMotos.csproj"

# Copiar o restante dos arquivos do projeto para o diretório de trabalho
COPY . .

# Compilar a aplicação
RUN dotnet build "AluguelDeMotos.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "AluguelDeMotos.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem base do runtime para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Diretório de trabalho na imagem final
WORKDIR /app

# Expor as portas que a aplicação usará
EXPOSE 80

# Copiar os arquivos publicados da etapa de publicação para a imagem final
COPY --from=publish /app/publish .

# Configurar o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "AluguelDeMotos.dll"]
