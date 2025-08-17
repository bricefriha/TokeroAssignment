## Assignment 
As an assignment, I was tasked to create a Crypto DCA (Dollar Cost Averagering) Calculator with simlulated data using Blazor interactive server:


https://github.com/user-attachments/assets/bd069e75-eeb4-440a-8ebb-c2cf453b9dc2

### My vision for the project
Firstly, as a casual crypto investor myself, this is a solution I would actually be interested in.
Therefore my approach to the problem was not only from a developer point of view, but also from a user one.

My approach of the project was very much production oriented, with scalability in mind. 
Thus I decided to create a Web API that would handles the data, which would allow the solution to extent to other platforms easily.

The idea I had was that the user would create DCA setups, that would be checked everyday by the server and would only trigger orders if the day of the month that is set as trigger would match with the current date.
The Web APP would serve more as a dashboard for the user to see all their DCA setups and track their current investments.

All market data are being fetched from the [CoinMarketCap API](https://coinmarketcap.com/api/), while not mandatory, I thought this would align with my williness to make a production driven scalable solution.
This didn't take much of my time to implement, as I already worked with similar APIs in the past (such as Binance and CoinGecko) when building my own Crypto trading bot.

#### Limitation
Due to the timeframe for the assignment to be delivered, there was no room to set a system to check the DCA setups and run orders monthly.
While this as been left out, I started working on it and saved my progress as a `git stash`.

This was a pure pleasure to work on this project!

# Setup the project

## Import the database via command line
1. open the Terminal in the location the project is stored (`/TokeroAssignment`)
2. To import the run either of the following command
   
   **using Windows Authentication**

   `sqlcmd -S localhost -E -Q "RESTORE DATABASE DCA-db FROM DISK = '.\database\DCA-db.bak' WITH REPLACE"`

   **using User login**

   `sqlcmd -S localhost -U <Username> -P <Password> -Q "RESTORE DATABASE DCA-db FROM DISK = '.\database\DCA-db.bak' WITH REPLACE"`
   
## Import the database via SSMS
1. Open **SSMS** and connect to your SQL Server instance.
2. In **Object Explorer**, right-click on **Databases**.
3. Select **Restore Database...**
4. Under **Source**, choose:
   - **Device**
   - Click the **...** button and browse to
   - Press the **Add** button
   - select the `\database\DCA-db.bak` file from the project
   - Press **OK**
5. Once your back on the previous page, press **OK**.


## Get the Web API up and running

#### import the secrets
1. Rename `\WebAPI\config\secrets_temp.json` to `\WebAPI\config\secrets.json`
 > Alternatively, if I sent you a `secrets.json` just move that one to `\WebAPI\config` and skip step 1 and 2

2. Open this file and and fill it up with with your secrets
3. import the environment variables from  `secrets.json` by running this command in the Terminal:
   ```Bash
   dotnet user-secrets init
   ```
   then
   on Windows:
   ```Bash
   type .config\secrets.json | dotnet user-secrets set
   ```

   on Linux/Mac:
   ```Bash
   cat ./input.json | dotnet user-secrets set
   ```

   For more on secrets: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-9.0&tabs=linux

#### DataBase setup
1. Open the Terminal (Make sure the path is pointing at the WebAPI, `C:\..\TokeroAssignment\WebAPI\`)
2. Run the following command:
      ```Bash
      dotnet ef database update
      ```
      > If EntityFramework is not installed on your machine, you can install it with this command:
      ```Bash
      dotnet tool install --global dotnet-ef
      ```

#### Run the API
      
1. open the terminal (again make sure the path is pointing at the WebAPI, `C:\..\TokeroAssignment\WebAPI\`)
2. Run the following command
```Bash
   dotnet run   
```

## Get the Web APP up and running

### Server Setup
> ⚠️ If you intent to run the Web API on the same machine as the Web App adn you didn't change the port in which it runs, please skip this step. As the `appsettings.json` already include default values, you won't need to change anything.
1. Open the `appsettings.json` file
2. Change the following field, with the relative data
   ```Json
   {
      "ServerHost":  "localhost",
      "ServerPort": 5259,
      "ServerSSL": false,
      ...
   }
   ```
   **Tip:** These data should show up in the console when you are running the Web API with `dotnet run`:
   <img width="383" height="32" alt="image" src="https://github.com/user-attachments/assets/47e67787-f958-4c1a-9038-ef68987a5612" />

#### Run the Web App
You have two ways of doing it.

##### Via Visual Studio
1. Select the project `TokeroAssignment`
2. Press the play button or F5:
   <img width="209" height="37" alt="image" src="https://github.com/user-attachments/assets/37259c73-89fa-443b-8bdb-e0ecbf598a3f" />
3. The browser should open and open the App

##### Via command line
1. Open the terminal
2. Run `dotnet run`
3. Copy the http address returned by the console under `Now listening on: [the url should be here]`, and paste it to your browser:
   
   <img width="344" height="33" alt="image" src="https://github.com/user-attachments/assets/26388474-92b1-438d-a2ea-79a3bcfb2798" />
   
5. To terminate the app: go to the terminal and do CTRL+C




   


