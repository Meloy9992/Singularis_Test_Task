#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Singularis_Test_Task/Singularis_Test_Task.csproj", "Singularis_Test_Task/"]
RUN dotnet restore "Singularis_Test_Task/Singularis_Test_Task.csproj"
COPY . .
WORKDIR "/src/Singularis_Test_Task"
RUN dotnet build "Singularis_Test_Task.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Singularis_Test_Task.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Singularis_Test_Task.dll"]