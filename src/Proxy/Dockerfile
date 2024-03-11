FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ./Directory.Packages.props ./
COPY ./Directory.Build.props ./
COPY ./src/Common/Common.csproj ./Common/
COPY ./src/Proxy/Proxy.csproj ./Proxy/
RUN dotnet restore "./Proxy/Proxy.csproj"
COPY ./src/Proxy/ ./Proxy/
COPY ./src/Common/ ./Common/
WORKDIR "/src/Proxy/"
RUN dotnet build "Proxy.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "Proxy.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
ARG CERT_LOCAL_PATH
ARG CERT_REMOTE_PATH
COPY $CERT_LOCAL_PATH $CERT_REMOTE_PATH
ENV ASPNETCORE_Kestrel__Certificates__Default__Path $CERT_REMOTE_PATH

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proxy.dll"]
EXPOSE $PROXY_PORT_HTTPS
EXPOSE $PROXY_PORT_HTTP