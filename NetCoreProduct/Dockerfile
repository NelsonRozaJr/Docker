FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
LABEL version="1.0.0" description=".Net Core Mvc Application"
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT [ "dotnet", "NetCoreProduct.dll" ]

# Passos para a criação de um arquivo Dockerfile:

# Definir uma imagem base
# Definir informações para a imagem
# Copiar os arquivos da pasta dist para a pasta do container (/app)
# Definir a pasta de trabalho (/app)
# Expor a pasta do container e definir em qual porta o servidor vai atender
# Definir o ponto de entrada da aplicação

# Pasta /dist criada a partir da publicação da aplicação:
# dotnet publish --configuration Release --output dist

# Comandos para build da imagem, criação e execução do container:
# docker build -t netcoreproduct:1.0.0 .
# docker container run -p 3000:80 --name netcoreproduct netcoreproduct:1.0.0
# Acessar http://192.168.99.100:3000/
