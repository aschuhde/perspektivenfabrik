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
ENV ASPNETCORE_Kestrel__Certificates__Default__Path /var/ssl/certificate.user.pfx
COPY ./src/Proxy/entrypoint.sh /app/entrypoint.sh
RUN chmod +x /app/entrypoint.sh
COPY --from=publish /app/publish .
ENTRYPOINT ["sh", "entrypoint.sh"]
EXPOSE $PROXY_PORT_HTTPS
EXPOSE $PROXY_PORT_HTTP