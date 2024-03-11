FROM openjdk:23-slim-bullseye
WORKDIR /
RUN  apt-get update \
  && apt-get install -y wget   
RUN wget -P ./ -O ./codegen.jar https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/3.0.51/swagger-codegen-cli-3.0.51.jar
COPY codegen.conf codegen.conf
EXPOSE 8080
RUN chmod +x codegen.jar
ARG CACHEBUST=1
#CMD java -jar codegen.jar config-help -l typescript-angular
CMD rm -rf /out/* && java -jar codegen.jar generate -i http://api:${API_PORT}/swagger/v1/swagger.json -l typescript-angular -o /out -c codegen.conf && mkdir -p /server && mkdir -p /server/api && mkdir -p /server/model && rm -rf /server/model/* && rm -rf /server/api/* && cp /out/api/* /server/api && cp /out/model/* /server/model && cp /out/encoder.ts /server/encoder.ts && cp /out/variables.ts /server/variables.ts && cp /out/configuration.ts /server/configuration.ts
