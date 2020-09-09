FROM node:14.9.0-alpine3.10 AS builder

COPY package.json package-lock.json ./
RUN npm install && mkdir /app && mv ./node_modules ./app

WORKDIR /app
COPY . .
RUN npm run ng build -- --prod --output-path=dist

FROM nginx:1.19.2-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=builder /app/dist/* /usr/share/nginx/html/
EXPOSE 4200