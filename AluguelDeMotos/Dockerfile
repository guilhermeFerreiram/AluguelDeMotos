# Imagem base do .NET SDK para compilar a aplica��o
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Diret�rio de trabalho dentro do cont�iner
WORKDIR /src

# Copiar o arquivo .csproj para o diret�rio de trabalho
COPY ["AluguelDeMotos.csproj", "./"]

# Restaurar depend�ncias do projeto
RUN dotnet restore "AluguelDeMotos.csproj"

# Copiar o restante dos arquivos do projeto para o diret�rio de trabalho
COPY . .

# Compilar a aplica��o
RUN dotnet build "AluguelDeMotos.csproj" -c Release -o /app/build

# Etapa de publica��o
FROM build AS publish
RUN dotnet publish "AluguelDeMotos.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem base do runtime para rodar a aplica��o
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Diret�rio de trabalho na imagem final
WORKDIR /app

# Expor as portas que a aplica��o usar�
EXPOSE 80

# Copiar os arquivos publicados da etapa de publica��o para a imagem final
COPY --from=publish /app/publish .

# Configurar o ponto de entrada da aplica��o
ENTRYPOINT ["dotnet", "AluguelDeMotos.dll"]
