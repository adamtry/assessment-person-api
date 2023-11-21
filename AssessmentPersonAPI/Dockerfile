FROM mcr.microsoft.com/dotnet/sdk:6.0

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN

WORKDIR /app

# Copy csproj and nuget config and restore as distinct layers
COPY ./AssessmentPersonAPI/AssessmentPersonAPI.csproj ./
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./AssessmentPersonAPI.csproj

# Copy everything else and build
COPY ./AssessmentPersonAPI ./
RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o out

EXPOSE ${PORT:-5000}
CMD ASPNETCORE_URLS=http://+:${PORT:-5000} dotnet ./out/AssessmentPersonAPI.dll
