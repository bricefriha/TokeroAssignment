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


