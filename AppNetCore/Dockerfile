FROM mcr.microsoft.com/dotnet/core/runtime:3.1
LABEL version="1.0.0" description="NetCore Sample Hello World"
COPY dist /app
WORKDIR /app
ENTRYPOINT [ "dotnet", "AppNetCore.dll" ]

# Comandos para build da imagem, criação e execução do container:
# docker image build -t netcorehelloworld:1.0.0 .
# docker container run --name netcorehelloworld netcorehelloworld:1.0.0
