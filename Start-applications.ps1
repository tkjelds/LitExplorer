[CmdletBinding()]

$password = New-Guid

$project = ".\iLit.API"

Write-Host "Starting iLit SQL Server"
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
    $database = "iLit"
    $connectionString = "Server=localhost;Database=$database;User Id=sa;Password=$password;Trusted_Connection=False;Encrypt=False"

    Write-Host "Configuring Connection String"
    dotnet user-secrets init --project $project
    dotnet user-secrets set "ConnectionStrings:iLit" "$connectionString" --project $project

    Set-Location .\iLit.API\
    dotnet ef database update -p ..\iLit.Infrastructure\

    Write-Host "Starting iLit"
    dotnet run 
