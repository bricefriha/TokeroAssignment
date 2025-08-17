# Setup

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
3. Copy the http address returned by the console under `Now listening on: [the url should be here]`, and paste it to your browser
   <img width="344" height="33" alt="image" src="https://github.com/user-attachments/assets/26388474-92b1-438d-a2ea-79a3bcfb2798" />
4. To terminate the app: go to the terminal and do CTRL+C




   


