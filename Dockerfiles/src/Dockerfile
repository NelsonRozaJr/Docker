# $ docker image build -t fibonacci .
# $ docker container run fibonacci

FROM ubuntu
RUN apt-get update
RUN apt-get install build-essential -y
COPY fibonacci.c /
RUN make fibonacci
CMD /fibonacci
