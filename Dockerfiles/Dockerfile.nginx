# Define imagem base
FROM debian:8
# Versão e descrição da imagem
LABEL version="1.0" description="Debian/Nginx"
# Atualiza os pacotes do repositório e obtém informações sobre a versão
RUN apt-get update
# Instalar o Nginx no Debian
RUN apt-get install -y nginx
# Limpar os pacotes
RUN apt-get clean
# Expor a porta na qual o Nginx estará atendendo
EXPOSE 80
# Ponto de entrada da aplicação
ENTRYPOINT [ "/usr/sbin/nginx" ]
# Comandos a serem executados na pasta definida no ENTRYPOINT
CMD [ "-g", "daemon off;" ]