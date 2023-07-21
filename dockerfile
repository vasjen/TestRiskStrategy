FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /
COPY ./WebApp/WebApp.csproj ./WebApp/


COPY ./WebApp  ./WebApp/

RUN ls
WORKDIR /WebApp
RUN dotnet restore
RUN dotnet build  -c Development --no-restore ./WebApp.csproj
RUN dotnet publish --no-build -o out --configuration Development

FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Setup working directory for the project
WORKDIR /
COPY --from=build /WebApp/out  .

ENV ASPNETCORE_ENVIRONMENT Development

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "WebApp.dll"]

