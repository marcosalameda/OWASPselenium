# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Fix for export utils in Genio applications
RUN apt update && apt install libgdiplus -y

# Copy the published files to the Docker image
COPY ./publish-linux/ .

# Set the entry point
ENTRYPOINT ["dotnet", "GenioMVC.dll"]