# $ docker image build -t nodejs:v1 -f Dockerfiles/Dockerfile context/
# $ docker container run --name node -d -p 9090:8080 nodejs:v1

FROM node:14.11.0-alpine3.12

WORKDIR /app

COPY package.json .

RUN npm install

COPY hello.js .

EXPOSE 8080

CMD [ "node", "hello.js" ]
