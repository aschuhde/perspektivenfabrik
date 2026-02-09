#!/bin/sh
mkdir -p /var/ssl
if [ -n "$PROXY_CERTIFICATE" ]; then echo "$PROXY_CERTIFICATE" > cert.txt; base64 -d cert.txt > /var/ssl/certificate.user.pfx; fi
cd /app & dotnet Proxy.dll