#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Inicia um est�gio com uma imagem base pequena
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# Cria o diret�rio /app na imagem
WORKDIR /app
# Exp�e a porta 80
EXPOSE 80/TCP

# Come�a um novo est�gio com uma imagem grande para cria��o/publica��o
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# Cria o diret�rio /src na imagem
WORKDIR /src
# Copia o arquivo de projeto .csproj referenciado para poder restaurar pacotes posteriormente
COPY ["ApiNetCore.csproj", ""]
# Restaura os pacotes para o projeto referenciado
RUN dotnet restore "./ApiNetCore.csproj"
# Copia toda a �rvore de diret�rios da solu��o (exceto os arquivos/diret�rios inclu�dos no arquivo .dockerignore ) para o diret�rio /src na imagem
COPY . .
# Altera a pasta atual para a pasta que cont�m o projeto
WORKDIR "/src/."
# Compila o projeto (e outras depend�ncias) com a sa�da para o diret�rio /build na imagem
RUN dotnet build "ApiNetCore.csproj" -c Release -o /app/build

# Inicia um novo est�gio continuando a partir da compila��o
FROM build AS publish
# Publica o projeto (e as depend�ncias) com a sa�da para o diret�rio /publish na imagem
RUN dotnet publish "ApiNetCore.csproj" -c Release -o /app/publish

# Inicia um novo est�gio continuando da base
FROM base AS final
# Altera o diret�rio atual para /app
WORKDIR /app
# Copia o diret�rio /publish do est�gio publish para o diret�rio atual
COPY --from=publish /app/publish .
# Define o comando a ser executado quando o container for iniciado
ENTRYPOINT ["dotnet", "ApiNetCore.dll"]