FROM ://microsoft.com AS base
WORKDIR /app
EXPOSE 10000

FROM ://microsoft.com AS build
WORKDIR /src
COPY ["Polleria.csproj", "."]
RUN dotnet restore "./Polleria.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Polleria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Polleria.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Polleria.dll"]
