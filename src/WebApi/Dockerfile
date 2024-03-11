FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ./Directory.Packages.props ./
COPY ./Directory.Build.props ./
COPY ./src/WebApi/WebApi.csproj ./WebApi/
COPY ./src/Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY ./src/Application/Application.csproj ./Application/
COPY ./src/Domain/Domain.csproj ./Domain/
COPY ./src/Common/Common.csproj ./Common/
RUN dotnet restore "./WebApi/WebApi.csproj"
COPY ./src/Common ./Common/
COPY ./src/Domain ./Domain/
COPY ./src/Application ./Application/
COPY ./src/Infrastructure ./Infrastructure/
COPY ./src/WebApi ./WebApi/
WORKDIR "/src/WebApi/"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
EXPOSE ${API_PORT}