# LitExplorer
BDSA2021 - Project: LitExplorer

Login:

user = Guest@jacobsonneoutlook.onmicrosoft.com
password = Bdsa2021

To run the program and setup database, run the PowerShell script "Start-applications.ps1" from inside the LitExplorer folder with docker running. 
This can be done by navigating to the folder in a PowerShell terminal (e.g. inside Visual Studio Code) and run the script by typing ".\Start-applications.ps1".
If the script is succesful, you should be able to navigate to the given localhost port and interact with the Blazor Webassembly app. 

Should there be an issue with using the script, you can open Start-applications.ps1 in an editor or with notepad and manually copy paste the commands one by run into your terminal:
- cd ..\LitExplorer\iLit.API\
- $password = New-Guid
- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
- $database = "iLit"
- $connectionString = "Server=localhost;Database=$database;User Id=sa;Password=$password;Trusted_Connection=False;Encrypt=False"
- dotnet user-secrets init
- dotnet user-secrets set "ConnectionStrings:iLit" "$connectionString"
- dotnet ef database update -p ..\iLit.Infrastructure
- dotnet run





