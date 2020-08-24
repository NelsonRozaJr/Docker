FROM node
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . ./
EXPOSE 3000/tcp
ENTRYPOINT [ "npm", "start" ]

# Usa uma imagem do node a partir do docker hub
# Define qual diretório será usado para nossa aplicação no container
# Copia todos os arquivos que começam com package e tem extensão .json para a pasta definida em WORKDIR
# Instala todas as dependências declaradas no package.json
# Copia todos os arquivos da raiz da nossa aplicação para a pasta definida no WORKDIR
# Expõe a porta 3000 do container
# Roda o comando 'npm start'

# Comandos para build da imagem, criação e execução do container:
# docker image build -t appnode:1.0.0 .
# docker container run --name appnode -p 4000:3000 appnode:1.0.0
# Acessar http://192.168.99.100:4000/
