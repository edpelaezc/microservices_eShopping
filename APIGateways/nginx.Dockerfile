FROM nginx

COPY APIGateways/nginx.local.conf /etc/nginx/nginx.conf
COPY APIGateways/id-local.crt /etc/ssl/certs/id-local.eshopping.com.crt
COPY APIGateways/id-local.key /etc/ssl/private/id-local.eshopping.com.key