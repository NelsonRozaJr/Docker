FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
LABEL version="1.0" maintaner="Nelson Jr"
COPY dist /app
WORKDIR /app
EXPOSE 80/TCP
ENTRYPOINT [ "dotnet", "NetCoreStudent.dll" ]