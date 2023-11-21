FROM mcr.microsoft.com/dotnet/sdk:6.0

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN

WORKDIR /app

# Copy csproj and nuget config and restore as distinct layers
COPY ./AssessmentPersonAPI.sln ./
COPY ./AssessmentPersonAPI/AssessmentPersonAPI.csproj ./AssessmentPersonAPI/
COPY ./AssessmentPersonAPI.Tests/AssessmentPersonAPI.Tests.csproj ./AssessmentPersonAPI.Tests/
COPY /NuGet.Config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./AssessmentPersonAPI/AssessmentPersonAPI.csproj
RUN dotnet restore ./AssessmentPersonAPI.Tests/AssessmentPersonAPI.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out AssessmentPersonAPI.Tests/AssessmentPersonAPI.Tests.csproj

CMD dotnet test
