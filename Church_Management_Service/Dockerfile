FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app

# Ensure the data directory exists for SQLite persistence
RUN mkdir -p /app/data

COPY published/ ./

# Mount the database folder as a volume to persist data
VOLUME [ "/app/data" ]

ENTRYPOINT ["dotnet", "Church_Management_Service.dll", "--environment=Development"]