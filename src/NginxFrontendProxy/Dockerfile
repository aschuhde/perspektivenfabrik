FROM nginx:stable
RUN rm -R /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/mysite.template

ARG NGINX_PORT
ARG ANGULAR_NAME
ARG ANGULAR_PORT
ENV NGINX_PORT $NGINX_PORT
ENV ANGULAR_PORT $ANGULAR_PORT
ENV ANGULAR_NAME $ANGULAR_NAME
ENV DOLLAR $
RUN envsubst < /etc/nginx/conf.d/mysite.template > /etc/nginx/conf.d/default.conf 
EXPOSE $NGINX_PORT
