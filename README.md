DigiMenu APP
=============


 ## Project Architecture ##

<details>
       <summary>Core Project </summary>
      <p> This is when you define your contract like Domain entities and Interfacies . </p>
       <b> This should never be dependant to any project </b> 
</details>

<details>
         <summary>Infrastructure Project </summary>
         <p>
             This layer hold the dbcontext ,respository, services, migration, extensions , configs etc. In here, we define database access (typically in the shape of                            repositories), integrations with other network services, caches, etc. This project/layer contains the physical implementation of the interfaces defined in our Core                 project
          </p>
          <b> This is dependant to Core Project only </b> 
</details>

<details>
           <summary>Presentaion Project</summary>
           <p>This is where you RestAPI and Angular(ClientApp) is defined </p>
           <b>This is dependant to Infrastructure Project  </b> 
</details>



# Environment Setup #

* Any .Net IDEA [Visual Studio](https://visualstudio.microsoft.com/), [Rader](https://www.jetbrains.com/rider/) or [Visual Studio code](https://code.visualstudio.com/)
* [.NET Core SDK ](https://dotnet.microsoft.com/download)
* [NodeJs (LTS v12.18.4)](https://nodejs.org/en/download)
* [Angular CLI](https://cli.angular.io/) 
 
 <i> when you run project the 1st time it will download node packages defined in </i> `TechNinjaz.DigiMenu.Presentation/ClientApp/package.json`


## Migration #

command 
* add `dotnet ef migrations add newMigrationName -p TechNinjaz.DigiMenu.Infrastructure -s TechNinjaz.DigiMenu.Presentation`
* create script `dotnet ef migrations script newMigrationName -p TechNinjaz.DigiMenu.Infrastructure -s TechNinjaz.DigiMenu.Presentation`
* apply changes to db `dotnet ef database update  -p TechNinjaz.DigiMenu.Infrastructure -s TechNinjaz.DigiMenu.Presentation`

<b><i> currently we using SQLite so we need to drop all migrations/db and add them when changing new db model. you can use anther db but just update <i/></b>
* `StartupExtension.AddDefaultDatabaseContext` 
* `DesignTimeContextFactory`




[git cheat sheet](https://education.github.com/git-cheat-sheet-education.pdf)
