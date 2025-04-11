FROM node:lts as node
WORKDIR /app
COPY package.json package.json
COPY package-lock.json package-lock.json
RUN npm install
COPY ./src ./src
COPY angular.json angular.json
COPY server.ts server.ts
COPY tsconfig.json tsconfig.json
COPY tsconfig.app.json tsconfig.app.json
COPY ./public ./public
RUN npm run build

FROM node:lts-alpine AS ssr-server
COPY --from=node /app/dist /app/dist/
COPY package.json /app/package.json
COPY package-lock.json /app/package-lock.json
WORKDIR /app
ENTRYPOINT ["npm", "run-script", "serve:ssr:Frontend"]
EXPOSE ${ANGULAR_PORT}

