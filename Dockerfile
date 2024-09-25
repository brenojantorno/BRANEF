# Use the official Microsoft .NET image as the base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the working directory inside the container
    WORKDIR /app

    # Copy the .NET application files from the current directory
    COPY . ./

    # Restore dependencies using NuGet
    RUN dotnet restore

    # Publish the application as a single file (optional)
    # This step can be omitted if your application doesn't require publishing
    RUN dotnet publish -c Release -o out

# # Use the official Microsoft .NET image as the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
    # Set the working directory inside the container
    WORKDIR /app
    COPY --from=build /app/out .
    ENTRYPOINT ["dotnet", "branef.Api.dll"]

    # Expose the port your application listens on (optional)
    # Replace 5000 with the actual port your application uses