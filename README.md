# LitExplorer
BDSA2021 - Project: LitExplorer

<h1>Login:</h1>

user = Guest@jacobsonneoutlook.onmicrosoft.com
password = Bdsa2021

<h1>Running the program</h1>

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

<h1>(Very) short guide to navigate the program</h1>

First you need to login with the credentials at the top of the README. After succesfully logging in, the data should be fetched and the graphics should be loaded from the default seed. 

Articles are represented as circles with their title inside the circle as text. By pressing a circle, you are shown which other articles, the article references, and which articles it is referenced by.

At the bottom there are four buttons:
- Add Article: create and add an article to the database
- Add Reference: create and add a reference between two articles in the database. The two buttons next to each article title used should be seen as "start" (left) and "end" (right) of an arrow; you "start" at the article which is referencing some article at the "end". At the bottom the currently selected articles are shown.
- Delete Article: delete articles from database
- Delete Reference: detele a reference between two articles
All four buttons respond with feedback if the requests are succesful or not.

<h3>Graphics</h3>
The graphics don't automatically update when the database is updated. Either refresh the browser window manually by pressing F5 or use the refresh button at the upper-right corner.



