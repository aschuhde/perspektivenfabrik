#!/bin/sh
mkdir -p /var/ssl
echo "$PROXY_CERTIFICATE" > cert.txt; base64 -d cert.txt > /var/ssl/certificate.user.pfx
cd /app & dotnet Proxy.dll