# ������ ����������
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

# �������� ���� .csproj � ��������������� �����������
COPY ["TestTaskSurveys.csproj", "./"]
RUN dotnet restore "./TestTaskSurveys.csproj"

# �������� ��� ����� �������
COPY . .

# ������ �������
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# ��������� ���������
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# �������� ��������� ����������
COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "TestTaskSurveys.dll"]
