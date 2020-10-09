FROM python:3.9-alpine3.12
WORKDIR /code
COPY app.py /code
COPY requirements.txt /code
RUN pip install -r requirements.txt
CMD [ "python", "app.py" ]
