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
RUN sed -i '$ d' /usr/lib/ssl/openssl.cnf
RUN echo 'CipherString = DEFAULT:@SECLEVEL=1' >> /usr/lib/ssl/openssl.cnf
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CiDotNet.AngularCalc.dll"]