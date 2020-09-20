"# DigiMenu" 
#Add Migration 

dotnet ef migrations add initialCreate -p TechNinjaz.DigiMenu.Infrastructure -s TechNinjaz.DigiMenu.Presentation

* currently we using SQLite so we need to drop all migrations/db and add them when changing new db model. you can use anther db but just update ```StartupExtension.AddDefaultDatabaseContext``` and ```DesignTimeContextFactory```