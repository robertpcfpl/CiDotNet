#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CiDotNet.AngularCalc/CiDotNet.AngularCalc.csproj", "CiDotNet.AngularCalc/"]
COPY ["CiDotNet.GpwBenchmarkplWibor/CiDotNet.GpwBenchmarkplWibor.csproj", "CiDotNet.GpwBenchmarkplWibor/"]
COPY ["CiDotNet.Calc/CiDotNet.Calc.csproj", "CiDotNet.Calc/"]
RUN dotnet restore "CiDotNet.AngularCalc/CiDotNet.AngularCalc.csproj"
COPY . .
WORKDIR "/src/CiDotNet.AngularCalc"
RUN dotnet build "CiDotNet.AngularCalc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CiDotNet.AngularCalc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client /app/dist /app/dist
ENTRYPOINT ["dotnet", "CiDotNet.AngularCalc.dll"]