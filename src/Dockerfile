#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BudgetUnderControl.AdminClient.UI/BudgetUnderControl.AdminClient.UI.csproj", "BudgetUnderControl.AdminClient.UI/"]
RUN dotnet restore "BudgetUnderControl.AdminClient.UI/BudgetUnderControl.AdminClient.UI.csproj"
COPY . .
WORKDIR "/src/BudgetUnderControl.AdminClient.UI"
RUN dotnet build "BudgetUnderControl.AdminClient.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetUnderControl.AdminClient.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT Docker
ENTRYPOINT ["dotnet", "BudgetUnderControl.AdminClient.UI.dll"]