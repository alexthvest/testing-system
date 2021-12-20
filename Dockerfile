FROM node:16.13.1-alpine as client-build

WORKDIR /app/build/client

COPY src/client/package*.json src/client/yarn.lock ./

COPY src/client .

RUN npm install

RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS server-build

WORKDIR /app

COPY src/server/*.sln ./
COPY src/server/TestingSystem.Web/*.csproj ./TestingSystem.Web/

COPY src/server .

WORKDIR /app/TestingSystem.Web

RUN dotnet publish -c Release -o /app/build/server/dist

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /app

COPY --from=client-build /app/build/client/dist ./wwwroot
COPY --from=server-build /app/build/server/dist ./

ENTRYPOINT ["dotnet", "TestingSystem.Web.dll"]
