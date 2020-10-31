#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ARG USER_DATABASE_URL
ARG STORE_DATABASE_URL
ARG ADMINISTRATOR_ARG
ARG AUTHORIZEID_ARG
ARG AUTHORIZEKEY_ARG
ARG AZUREKEY_ARG
ARG AZURESTORAGEACCOUNT_ARG
ARG IMAGECONTAINER_ARG
ARG PASSWORD_ARG
ARG SENDGRID_API_KEY_ARG
ENV USER_DATABASE_URL_ENV=$USER_DATABASE_URL
ENV STORE_DATABASE_URL_ENV=$STORE_DATABASE_URL
ENV SENDGRID_API_KEY=$SENDGRID_API_KEY_ARG
ENV PASSWORD=$PASSWORD_ARG
ENV IMAGECONTAINER=$IMAGECONTAINER_ARG
ENV AZURESTORAGEACCOUNT=$AZURESTORAGEACCOUNT_ARG
ENV AZUREKEY=$AZUREKEY_ARG
ENV AUTHORIZEKEY=$AUTHORIZEKEY_ARG
ENV AUTHORIZEID=$AUTHORIZEID_ARG
ENV ADMINISTRATOR=$ADMINISTRATOR_ARG



FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ECommerce_Application.csproj", "./"]
RUN dotnet restore "./ECommerce_Application.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ECommerce_Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce_Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ECommerce_Application.dll
