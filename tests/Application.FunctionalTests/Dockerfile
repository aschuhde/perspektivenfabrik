FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY ./Directory.Packages.props ./
COPY ./Directory.Build.props ./
WORKDIR /src
COPY ./src/Common ./Common/
COPY ./src/Domain ./Domain/
COPY ./src/Application ./Application/
COPY ./src/WebApi ./WebApi/
COPY ./src/Infrastructure ./Infrastructure/
WORKDIR /tests/project
COPY ./tests/Application.FunctionalTests ./
ENTRYPOINT ["dotnet", "test"]