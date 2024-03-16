// ef commands templates for the Rider's terminal

// change migration name
dotnet ef migrations add Initial --verbose --project Visit.DAL --startup-project Visit.API


dotnet ef database update --verbose --project Visit.DAL --startup-project Visit.API