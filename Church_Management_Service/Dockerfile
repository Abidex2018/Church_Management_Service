FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app

COPY published/ ./

ENTRYPOINT ["dotnet", "Church_Management_Service.dll", "--environment=Development"]