# CiDotNet
Examples for schort CI in .NET presentation

#Run via docker
1. Ensure that image names in `docker compose` match with your images
2. Optional: if you change ports of .net core api in `docker compose`, ensure that variable `api_prod_url` in `CiDotNet.AngularCalc\ClientApp\src\main.ts `match with your changes (you can change it and rebuild image)
3. Run project with command `docker-compose up` when being in root directory of project
4. By default app should be avaiable at http://localhost:4200

#How to build containers manulay
1. Api image:
`docker build -t repo_name/angular-calc-api .`
2. Angualr app image:
`docker build -f Dockerfile-angular -t repo_name/angular-calc-app .`
