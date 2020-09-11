#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Inicia um estágio com uma imagem base pequena
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# Cria o diretório /app na imagem
WORKDIR /app
# Expõe a porta 80
EXPOSE 80/TCP

# Começa um novo estágio com uma imagem grande para criação/publicação
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# Cria o diretório /src na imagem
WORKDIR /src
# Copia o arquivo de projeto .csproj referenciado para poder restaurar pacotes posteriormente
COPY ["ApiNetCore.csproj", ""]
# Restaura os pacotes para o projeto referenciado
RUN dotnet restore "./ApiNetCore.csproj"
# Copia toda a árvore de diretórios da solução (exceto os arquivos/diretórios incluídos no arquivo .dockerignore ) para o diretório /src na imagem
COPY . .
# Altera a pasta atual para a pasta que contém o projeto
WORKDIR "/src/."
# Compila o projeto (e outras dependências) com a saída para o diretório /build na imagem
RUN dotnet build "ApiNetCore.csproj" -c Release -o /app/build

# Inicia um novo estágio continuando a partir da compilação
FROM build AS publish
# Publica o projeto (e as dependências) com a saída para o diretório /publish na imagem
RUN dotnet publish "ApiNetCore.csproj" -c Release -o /app/publish

# Inicia um novo estágio continuando da base
FROM base AS final
# Altera o diretório atual para /app
WORKDIR /app
# Copia o diretório /publish do estágio publish para o diretório atual
COPY --from=publish /app/publish .
# Define o comando a ser executado quando o container for iniciado
ENTRYPOINT ["dotnet", "ApiNetCore.dll"]
