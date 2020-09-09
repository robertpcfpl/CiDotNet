FROM node:14.9.0-alpine3.10 AS builder

WORKDIR /app

COPY . .

RUN npm install
RUN npm run ng build -- --prod --output-path=dist

FROM nginx:1.19.2-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=builder /app/dist/* /usr/share/nginx/html/
EXPOSE 4200