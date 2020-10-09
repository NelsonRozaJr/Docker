FROM python:3.7-alpine
WORKDIR /code
COPY app.py /code
COPY requirements.txt /code
RUN pip install -r requirements.txt
CMD [ "python", "app.py" ]
